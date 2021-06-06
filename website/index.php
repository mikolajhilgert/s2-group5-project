<?php include 'usersession.php';
include('Includes/functions.php');?>
<html>
<head>
    <title>Employee dashboard</title>
    <link rel="stylesheet" type="text/css" href="Styles/Style.css">
</head>

<body>
    <?php include 'navbar.html'; ?>
    <?php
        $id = $_SESSION['userid'];
        $user = GetAllDetails($id);
    ?>

    <div class="contCenter">
        <div class="dashwrapper">
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
                <b>Contact info</b>
                <br>

                <br>
                <b>Email:</b> <?php echo $user->get_email(); ?>
                <br>
                <br>
                <b>Address:</b> <?php echo $user->get_address(); ?>
                <br>
                <br>
                <b>Phone:</b> <?php echo $user->get_phone(); ?>
                <br>
                <br>
                <b>Emergency number:</b> <?php echo $user->get_emergencynr(); ?>
                <br>
                <br>
                <b>Emergency contact:</b> <?php echo $user->get_emergencyc(); ?>
                <br>
                <br>
                <br>
                <br>
                <br>

                <form action="updateinfo.php">
                    <div class="updatebutton">
                        <button type="submit" name="changeinfo" id="btnupdate">Change information</button>
                    </div>
                </form>
            </div>
        </div>
    </div>


</body>
<footer><?php include 'footer.php'; ?></footer>

</html>