<?php include 'usersession.php'?>
<?php
include('Includes/functions.php');
$id = $_SESSION['userid'];
$user = GetAllDetails($id);
?>

<html>

<head>
    <title>Register Attendace</title>
    <link rel="stylesheet" type="text/css" href="Styles/Style.css">
</head>

<body>
    <?php include 'navbar.html'; ?>

    <div class="contCenter">
        <div class="dashwrapper">
            <div class="containerdash">
                <p> <?php echo $user->get_firstname() . " " . $user->get_lastname(). "  ";
                echo date("Y/m/d"); ?> </p><p> <?php
                if(CheckTodayShift($id)){
                    echo "You have " . CheckKindOfShift(GetTodayShift($id)) . " shift today";
                } else {
                    echo "You don't have any shifts scheduled for today";
                }
                ?>
            
            </p>
                <form action="Handlers/registerattendance.php" method="post">
                <div class="updatebutton">
                    <button name="submit">Register attendance!</button>
                </div>
                </form>
            </div>
        </div>
    </div>
</body>