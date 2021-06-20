<?php
include '../usersession.php';
include('../Includes/functions.php');
$id = $_SESSION['userid'];
$user = GetAllDetails($id);

if(isset($_POST['submit'])){

    echo CheckIfOnTheShift(GetTodayShift($id)[0], $id);


    if(CheckTodayShift($id)){
        if(CheckIfOnTheShift(GetTodayShift($id)[0], $id)==0){
        if(RegisterAttendace(GetTodayShift($id)[0], $id)){
            echo "registered";
            header("Location: ../attendance.php?outcome=success");
        } else {
            echo "error attendance";
        }
    } else { header("Location: ../attendance.php?outcome=fail");}


    } else {
        echo 'no shift today';
        header("Location: ../attendance.php");
    }
}
?>
