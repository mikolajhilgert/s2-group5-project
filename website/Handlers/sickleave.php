<?php include_once ('../Includes/dbh.inc.php'); ?>
<?php include '../usersession.php'?>
<?php require_once('../Classes/User.php');?>

<!DOCTYPE html>
<html>
<body>


<?php
if (isset($_POST['submit'])){
$id = $_SESSION['userid'];

$sql = "SELECT * FROM employee WHERE ID = $id;";
                //instantiate a new object of type prepared statement
                $stmt = mysqli_stmt_init($conn); //uses whichever connection variable was used to connect to the db
                //prepare the prepared statement, or rather try to parse the empty placeholder code first
                if (!mysqli_stmt_prepare($stmt, $sql)) //good practice to check for errors with placeholder before binding values to it, but we don't inject data into the SQL statement in this block
                {
                   echo "SQL statement failed.";
                }
            
                else
                    
                {
                    //try and run the parameters inside the database
                    mysqli_stmt_execute($stmt);
                    $result = mysqli_stmt_get_result($stmt);//get the result from the query
                    while($row = mysqli_fetch_assoc($result))
                    {
                        $user = new User();	
                        $user->set_firstname($row['FirstName']);
                        
						
                        
						
                        }                        
                    }        

$name = $user->get_firstname();
$start = $_POST['start'];
$end = $_POST['end'];


  // Check connection
  if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }
  else
  {

  // sql to update a record
   $sql = "INSERT INTO sickleaves (Name, Empid, Startdate, Enddate) VALUES ('$name', '$id', '$start', '$end');";

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