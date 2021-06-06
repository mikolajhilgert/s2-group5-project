<?php include_once ('../Includes/functions.php'); 
include '../usersession.php';
if (isset($_POST['submit'])){

  $id = $_SESSION['userid'];
  $email = $_POST['email'];
  $password = $_POST['password'];
  $address = $_POST['address'];
  $phone = $_POST['phone'];
  $emergencynr = $_POST['emergencynr'];
  $emergencyc = $_POST['emergencyc'];

  
  UpdateUserDetails($id,$email,$password,$address,$phone,$emergencynr,$emergencyc);
  header("Location: ../index.php"); 

}
?>   