<?php include_once ('../Includes/dbh.inc.php'); 
include '../usersession.php';
if(isset($_POST["formSubmit"]))
{
  $id = $_SESSION['userid'];

  if(isset($_POST['formDay']))
  {
    $aDay = $_POST['formDay'];

    if(count($aDay) == 1){
      $final = [$aDay[0],0];
    }else{
      $final = $aDay;
    }
  }else{
    $final = [0,0];
  }
  $sql = "UPDATE employee SET BannedDays = '$final[0],$final[1]' WHERE ID = $id;";
  $conn->query($sql);
  header("Location: ../shifts.php");
}

