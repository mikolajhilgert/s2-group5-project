<?php include 'usersession.php'?>
<?php
include_once ('Includes/functions.php');
$user = GetUserByID($_SESSION['userid']);
?>
<html>
<head>
    <title>Employee dashboard</title>
<link rel="stylesheet" type="text/css" href="Styles/Style.css">
</head>
<body>
<?php include 'navbar.html'; ?>
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
			<b>Department:</b> <?php echo $user->get_department(); ?>
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
			<div class="updatebutton">
            <button type = "submit" name = "submit" id = "btnupdate" onclick="return  confirm('Are you sure you want to overwrite the current information?')">Save changes</button>
			</div>
			<div class="resetbutton">
			<button type="reset" name = "reset" id = "btnreset" onclick="return  confirm('Are you sure you want to reset your changes?')">Reset</button>
			</div>
            </form>
</div>
</div>
</div>


</body>
<footer><?php include 'footer.php'; ?></footer>
</html>


