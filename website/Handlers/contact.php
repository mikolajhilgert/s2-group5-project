<?php include_once ('../Includes/dbh.inc.php'); ?>
<?php include '../usersession.php'?>


<!DOCTYPE html>
<html>
<body>


<?php
if (isset($_POST['submit'])){
$id = $_SESSION['userid'];
$subject = $_POST['subject'];


  // Check connection
  if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }
  else
  {

  // sql to update a record
   $sql = "INSERT INTO employee_messages (Empid, Message) VALUES ('$id', '$subject');";

   if ($conn->query($sql) === TRUE) {
   header("Location: ../contact.php");
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