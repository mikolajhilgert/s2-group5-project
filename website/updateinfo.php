<?php include 'usersession.php'?>
<?php

require_once('Classes/User.php');
include_once ('Includes/dbh.inc.php');

?>
<html>
<head>
    <title>Employee dashboard</title>
<link rel="stylesheet" type="text/css" href="Styles/Style.css">
</head>
<body>
<?php include 'navbar.html'; ?>
<?php
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
						$user->set_id($row['ID']);
                        $user->set_firstname($row['FirstName']);
                        $user->set_lastname($row['LastName']);
                        $user->set_phone($row['PhoneNr']);
						$user->set_address($row['Address']);
						$user->set_email($row['Email']);
						$user->set_pass($row['Password']);
						$user->set_emergencyc($row['EmergencyC']);
						$user->set_emergencynr($row['EmergencyNr']);
						$user->set_hours($row['WorkingHours']);
						$user->set_dob($row['DOB']);
						$user->set_bsn($row['BSN']);
						$user->set_position($row['Position']);
						$user->set_certificates($row['Certifications']);
						$user->set_languages($row['Languages']);
						$user->set_sdate($row['StartDate']);
						$user->set_edate($row['EndDate']);
						//$user->set_department($row['Department']);
						$user->set_salary($row['Salary']);

                        }                        
                    }              
               
        ?>
<div class ="contCenter">
<div class = "dashwrapper">
<div class="containerdash">
            <br>
            <b>Employee profile</b>
            <br>
            <br>
            <b>Name:</b> <?php echo $user->get_firstname() . " " . $user->get_lastname(); ?>
            <br>
			<br>
            <b>Date of birth:</b> <?php echo $user->get_dob(); ?>
            <br>
			<br>
			<b>BSN:</b> <?php echo $user->get_bsn(); ?>
            <br>
			<br>
			<b>Languages:</b> <?php echo $user->get_languages(); ?>
            <br>
			<br>
			<b>Certifications:</b> <?php echo $user->get_certificates(); ?>
            <br>
			<br>
			<b>Position:</b> <?php echo $user->get_position(); ?>
            <br>
			<br>
			<b>Department:</b> <?php //echo $user->get_department(); ?>
            <br>
			<br>
			<b>Employement date:</b> <?php echo $user->get_sdate(); ?>
            <br>
			<br>
			<b>Salary:</b> <?php echo $user->get_salary(); ?>
            <br>
</div>
<div class="containerdash">
            <br>
            <b>Personal info</b>
            <br>
            <form action="Handlers/update.php" method="post" enctype="multipart/form-data">
            <br>
            <label for="email"><b>Email:</b></label>
            <input type="text" name="email" value = <?php echo $user->get_email(); ?>>
            <br>
			<label for="password"><b>Password:</b></label>
            <input type="password" name="password" value = <?php echo $user->get_pass(); ?>>
            <br>
			<br>
            <label for="address"><b>Address:</b></label>
            <input type="text" name="address" value = <?php echo $user->get_address(); ?>>
            <br>
			<br>
            <label for="phone"><b>Phone:</b></label>
            <input type="text" name="phone" value = <?php echo $user->get_phone(); ?>>
            <br>
			<br>
            <label for="emergencynr"><b>Emergency number:</b></label>
            <input type="text" name="emergencynr" value = <?php echo $user->get_emergencynr(); ?>>
            <br>
			<br>
            <label for="emergencyc"><b>Emergency contact:</b></label>
            <input type="text" name="emergencyc" value = <?php echo $user->get_emergencyc(); ?>>
            <br>
			<br>
			<br>
			<br>
			<br>
			<div class="updatebutton">
            <button type = "submit" name = "submit" id = "btnupdate">Save changes</button>
			</div>
            </form>
</div>
</div>
</div>


</body>
<footer><?php include 'footer.php'; ?></footer>
</html>

