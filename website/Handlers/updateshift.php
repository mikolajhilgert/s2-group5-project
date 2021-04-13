<?php 
include_once ('../Includes/dbh.inc.php'); 
include '../usersession.php';

if(isset($_POST['submit'])){

$id = $_SESSION['userid'];
$shiftpref = $_POST['shift'];

  // Check connection
  if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }
  else
  {

  // sql to update a record
   $sql = "UPDATE employee SET Shiftpref = '$shiftpref' WHERE ID = $id;";

   if ($conn->query($sql) === TRUE) {
   header("Location: ../shifts.php");
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