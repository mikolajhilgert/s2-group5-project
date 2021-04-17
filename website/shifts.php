<?php include 'usersession.php';
require_once('Classes/User.php');
include_once ('Includes/dbh.inc.php');

$weekNumber = date("W");
$year = date("Y");
$id = $_SESSION['userid'];
if(isset($_GET['weekN'])){ $weekNumber = $_GET['weekN'];}?>
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

<?php

    $stmt = mysqli_prepare($conn, "SELECT DofW,morning,afternoon,evening FROM shifts where cWeek = ? and EmpID = ? and Year= ?");
    mysqli_stmt_bind_param($stmt, "iii", $weekNumber,$id,$year);
    $stmt->execute();
    $result = $stmt->get_result();
    $rows = mysqli_fetch_all($result);


    $stmt1 = mysqli_prepare($conn,"SELECT BannedDays FROM employee WHERE ID = ?");
    mysqli_stmt_bind_param($stmt1, "i", $id);
    $stmt1->execute();
    $row1 = $stmt1->get_result()->fetch_row();
    $input = $row1[0] ?? false;
    $bannedDays = explode(',', $input);

    // var_dump($rows);
    $dayOfWeek = ['Monday', 'Tuesday','Wednesday' ,'Thursday', 'Friday', 'Saturday', 'Sunday'];


    function CheckKindOfShift($day,$rows){
        foreach($rows as $r){
            if($day == $r[0]){
                if ($r[1] == 1 and $r[3] == 1) {
                    return "Morning & Evening";
                } elseif ($r[1] == 1){
                    return "Morning";
                }
                elseif ($r[2] == 1){
                    return "Afternoon";
                }else if($r[3] == 1){
                    return "Evening";
                }
            }
        }
        return "-";
    }

    function GetDateBounds($week_number,$year){
        for($day=1; $day<=7; $day++)
        {
            if($day==1 || $day==7){
                echo date('d/m/Y', strtotime($year."W".$week_number.$day))."\n";
                if($day==1){
                    echo " - ";
                }
            }
        }
    }

    function isBanned($i,$bannedDays){
        if($bannedDays[0]==$i){
            return "checked";
        }else if($bannedDays[1]==$i){
            return "checked";
        }
        return "";
    }
?>


<head>
    <title>Employee dashboard</title>
    <link rel="stylesheet" type="text/css" href="Styles/Style.css">
</head>

<body>
    <?php include 'navbar.html';?>

    <div class="contCenter">
        <div class="dashwrapper">
            <div class="containerdash">
                <b>Your schedule for week <?php echo $weekNumber;?>: <br> <?php GetDateBounds($weekNumber,$year);?> </b><br><br>

                <form action="post" action="shifts.php"></form>
                <table class="schedule">
                    <tr class="schedule">
                        <th class="schedule">Day of week</th>
                        <th class="schedule">Time of shift</th>
                    </tr>
                
                <?php for($day=1; $day<=7; $day++){?>
                    <tr class="schedule">
                        <td class="schedule"> <?php echo $dayOfWeek[$day-1]?> </td>
                        <td class="schedule"> <?php echo CheckKindOfShift($day,$rows); ?> </td>
                    </tr>
                    <?php }?>
                </table>
            <a href='shifts.php?weekN=<?php echo $weekNumber - 1;?>'> <button id="gobackwords"><</button></a>
            <a href='shifts.php?weekN=<?php echo $weekNumber + 1;?>'> <button id="goforward">></button></a>
            </div>
            
            <div class="containerdash">
                <b>Select unwanted work days:</b>
                <form name=form1 method=post action=Handlers/bandays.php enctype="multipart/form-data">
                    <br>
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
                    <br><br><br><br><br>
                    <input type="submit" name="formSubmit" value="Update!" />
                </form>
            </div>
        </div>
    </div>


</body>
<footer><?php include 'footer.php'; ?></footer>

</html>