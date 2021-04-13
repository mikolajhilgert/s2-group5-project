<?php include 'usersession.php'?>
<?php

require_once('Classes/User.php');
include_once ('Includes/dbh.inc.php');
$weekNumber = date("W");
?>
<html>
<script type="text/javascript">
    function chkcontrol(j) {
        var total = 0;
        for (var i = 0; i < 7; i++) {
            if (document.getElementById(i).checked) {
                total = total + 1;
            }
            if (total > 2) {
                document.getElementById(j).checked = false;
                alert("You can only ban a maximum of two days! Unselect one or more first!");
                return false;
            }
        }
    }
</script>

<head>
    <title>Employee dashboard</title>
    <link rel="stylesheet" type="text/css" href="Styles/Style.css">
</head>

<body>
    <?php include 'navbar.html';  
    $id = $_SESSION['userid'];
    $sql = "SELECT * FROM employee WHERE ID = $id;";
    //instantiate a new object of type prepared statement
    $stmt = mysqli_stmt_init($conn); //uses whichever connection variable was used to connect to the db
    //prepare the prepared statement, or rather try to parse the empty placeholder code first
    if (!mysqli_stmt_prepare($stmt, $sql)) //good practice to check for errors with placeholder before binding values to it, but we don't inject data into the SQL statement in this block
    {
        echo "SQL statement failed.";
    }
    else
    {
        //try and run the parameters inside the database
        mysqli_stmt_execute($stmt);
        $result = mysqli_stmt_get_result($stmt);//get the result from the query
        while($row = mysqli_fetch_assoc($result))
        {
            $user = new User();
            $user->set_firstname($row['FirstName']);
        }                        
    }
    ?>



    <div class="contCenter">
        <div class="dashwrapper">
            <div class="containerdash">

                <?php
                if(isset($_GET['weekN'])){ $weekNumber = $_GET['weekN']?>

                    <b>Schedule for week <?php echo $weekNumber;?></b><br><br>
                    <?php } else { ?>
                    <b>Schedule for week <?php echo $weekNumber;?></b><br><br> <?php } ?>

                
                
                <a href='shifts.php?weekN=<?php echo $weekNumber - 1;?>'> <button id="gobackwords" > < </button> </a>
                <a href='shifts.php?weekN=<?php echo $weekNumber + 1;?>'> <button id="goforward"> > </button> </a>
                
                
                <form action="post" action="shifts.php"></form>
        <table>
        <tr>
          <th>Day of week</th>
          <th>Time of day</th>

        </tr>
        <?php
        $year = date("Y");
        $query1 = "SELECT DofW,morning,afternoon,evening FROM shifts where cWeek = $weekNumber and EmpID = $id and Year=$year";
        $result1 = mysqli_query($conn, $query1);
        $rows = mysqli_fetch_all($result1);
       // var_dump($rows);
       $dayOfWeek = ['Monday', 'Tuesday','Wednesday' ,'Thursday', 'Friday', 'Saturday', 'Sunday'];

        
        function CheckKindOfShift($shift){
            if ($shift[1] == 1 and $shift[3] == 1) {
                return "morning and evening";
            } elseif ($shift[1] == 1){
                return "morning";
            }
            elseif ($shift[2] == 1){
                return "afternoon";
            } else if($shift[3] == 1){
                return "evening";
            }
        }
        
        foreach($rows as $shift){
            
            ?>
          <tr>
            <td> <?php echo $dayOfWeek[$shift[0]-1] ?> </td>
            <td> <?php echo CheckKindOfShift($shift); ?> </td>   
          </tr>
        <?php }?>
      </table>
            </div>

            <div class="containerdash">
                <?php
            $query = "SELECT BannedDays FROM employee WHERE ID = $id";
            $result = mysqli_query($conn, $query);
            $row = $result->fetch_row();
            $input = $row[0] ?? false;
            $bannedDays = explode(',', $input);

            function isBanned($i,$bannedDays){
                if($bannedDays[0]==$i){
                    return "checked";
                }else if($bannedDays[1]==$i){
                    return "checked";
                }
                return "";
            }
            ?>


                <b>Select unwanted work days</b>


                <form name=form1 method=post action=Handlers/bandays.php enctype="multipart/form-data">
                    <table>
                        <tr>
                            <td><input type=checkbox id=0 name="formDay[]" value=1 onclick='chkcontrol(0)'
                                    <?php print(isBanned('1',$bannedDays))?>></td>
                            <td>Monday</td>
                        </tr>
                        <tr>
                            <td><input type=checkbox id=1 name="formDay[]" value=2 onclick='chkcontrol(1)'
                                    <?php print(isBanned('2',$bannedDays))?>></td>
                            <td>Tuesday</td>
                        </tr>
                        <tr>
                            <td><input type=checkbox id=2 name="formDay[]" value=3 onclick='chkcontrol(2)'
                                    <?php print(isBanned('3',$bannedDays))?>></td>
                            <td>Wednesday</td>
                        </tr>
                        <tr>
                            <td><input type=checkbox id=3 name="formDay[]" value=4 onclick='chkcontrol(3)'
                                    <?php print(isBanned('4',$bannedDays))?>></td>
                            <td>Thursday</td>
                        </tr>
                        <tr>
                            <td><input type=checkbox id=4 name="formDay[]" value=5 onclick='chkcontrol(4)'
                                    <?php print(isBanned('5',$bannedDays))?>></td>
                            <td>Friday</td>
                        </tr>
                        <tr>
                            <td><input type=checkbox id=5 name="formDay[]" value=6 onclick='chkcontrol(5)'
                                    <?php print(isBanned('6',$bannedDays))?>></td>
                            <td>Saturday</td>
                        </tr>
                        <tr>
                            <td><input type=checkbox id=6 name="formDay[]" value=7 onclick='chkcontrol(6)'
                                    <?php print(isBanned('7',$bannedDays))?>></td>
                            <td>Sunday</td>
                        </tr>
                    </table>
                    <br>
                    <input type="submit" name="formSubmit" value="Update!" />
                </form>
            </div>
        </div>
    </div>


</body>
<footer><?php include 'footer.php'; ?></footer>

</html>