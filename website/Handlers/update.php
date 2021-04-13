<?php include_once ('../Includes/dbh.inc.php'); ?>
<?php include '../usersession.php'?>

<!DOCTYPE html>
<html>
<body>


<?php
if (isset($_POST['submit'])){

$id = $_SESSION['userid'];
$email = $_POST['email'];
$password = $_POST['password'];
$address = $_POST['address'];
$phone = $_POST['phone'];
$emergencynr = $_POST['emergencynr'];
$emergencyc = $_POST['emergencyc'];

  // Check connection
  if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }
  else
  {

  // sql to update a record
   $sql = "UPDATE employee SET Email = '$email', Password = '$password',Address = '$address', PhoneNr = '$phone', EmergencyNr = '$emergencynr', EmergencyC = '$emergencyc' WHERE ID = $id;";

   if ($conn->query($sql) === TRUE) {
   header("Location: ../index.php");
   } 
   else 
   {
   echo "Error";
   }
  }  
}

?>   
</body>
</html>  