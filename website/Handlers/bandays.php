<?php include_once ('../Includes/functions.php'); 
include '../usersession.php';
if(isset($_POST["formSubmit"]))
{
  $final = [0,0];
  $id = $_SESSION['userid'];

  if(isset($_POST['formDay']))
  {
    $aDay = $_POST['formDay'];

    if(count($aDay) == 1){
      $final = [$aDay[0],0];
    }else{
      $final = $aDay;
    }
  }
  SetBannedDays($id,$final);
  header("Location: ../shifts.php");
}

