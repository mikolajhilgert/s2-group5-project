<?php
include '../usersession.php';
include('../Includes/functions.php');
$id = $_SESSION['userid'];
$user = GetAllDetails($id);

if(isset($_POST['submit'])){
    if(CheckIfOnTheShift(GetTodayShift($id)[0], $id)==1){
        if(CheckOut(GetTodayShift($id)[0], $id)){
            header("Location: ../attendance.php?outcome=checkedout");
        } else {
            echo "error attendance";
        }
    }else if(CheckIfOnTheShift(GetTodayShift($id)[0], $id)==0){
        header("Location: ../attendance.php?outcome=nCheckedIn");
    }else{
        header("Location: ../attendance.php?outcome=aCheckedout");
    }

}
?>
