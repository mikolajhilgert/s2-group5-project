<?php include 'usersession.php'?>
<?php
include('Includes/functions.php');
$id = $_SESSION['userid'];
$user = GetAllDetails($id);
$outcome="";
if(isset($_GET['outcome'])){
    $outcome = $_GET['outcome'];
}
$ifOnShift = CheckIfOnTheShift(GetTodayShift($id)[0], $id);

if($ifOnShift == 1 && $outcome != "success"){
    $outcome = "fail";
}else if($ifOnShift == 2 && $outcome !="checkedout"){
    $outcome = "aCheckedout";
}
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
            <span class="attendance__buttons">
                <form action="Handlers/registerattendance.php" method="post">
                <div class="updatebutton">
                    <button name="submit">Register attendance!</button>
                </div>
                </form>
                </span>
                <p>
                    <?php if($outcome=="success"){echo "You have checked in at " . date("H:i");} else if ($outcome=="fail"){ echo "you have already checked in, do you want to check out instead?";}?>
                    <?php if($outcome=="checkedout"){echo "You have checked out at " . date("H:i");}else if ($outcome == "aCheckedout"){echo "You have already checked out for this shift";}else if($outcome == "nCheckedIn"){echo "You must first check in!";};?>
                </p>
                </p>

                <form action="Handlers/checkout.php" method="post">
                <div class="updatebutton">
                    <button name="submit">Check out!</button>
                </div>
                </form>         
            </div>
        </div>
    </div>
</body>