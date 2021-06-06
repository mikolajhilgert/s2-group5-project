<?php

include('dbh.inc.php');
if(strpos($_SERVER['PHP_SELF'],"Handlers")){
    include("../Classes/User.php");
}else{
    include("Classes/User.php");
}


function LoginUser($email,$password){
  $con = DBc::connect();
  if(CheckDetails($con,$email,$password)){
      $_SESSION['userid'] = GetIDByEmail($con,$email);
      return true;
  }else{
      return false;
  }
}

function CheckDetails($con,$email,$password){
  $query = $con->prepare("select * from employee where email=:email AND password=:password");
  $query->bindParam(":email",$email);
  $query->bindParam(":password",$password);
  $query->execute();


  if($query->rowCount()>0){
      return true;
  }else{
      return false;
  }
}

function GetIDByEmail($con,$email){
  $id = null;
  $query = $con->prepare("select id from employee where email=:email");
  $query->bindParam(":email",$email);
  $query->execute();
  $id = $query->fetch()[0];

  return $id;
}

function GetAllDetails($id){
    $con = DBc::connect();
    $query = $con->prepare("SELECT * FROM employee WHERE ID = $id;");
    //$query =$con->prepare("select * from employee where ID =:id;");
    $query->execute();
    $row = $query->fetch();

    $user = new User($row['ID'], $row['FirstName'], $row['LastName'], $row['PhoneNr'], $row['Address'], $row['Email'], $row['Password'], $row['EmergencyC'], $row['EmergencyNr'], $row['WorkingHours'], $row['DOB'], $row['BSN'], $row['Position'], $row['Certifications'], $row['Languages'], $row['StartDate'], $row['EndDate'], $row['Salary']);

    return $user;
}

function CheckKindOfShift($r){
    //var_dump($r);
    if ($r[1] == 1 and $r[3] == 1) { return "Morning & Evening";
    } elseif ($r[1] == 1){ return "Morning";
    } elseif ($r[2] == 1){ return "Afternoon";
    } else if($r[3] == 1){ return "Evening";}     
}

function GetTodayShift($id){
    $con = DBc::connect();
    $weekNumber = date("W");
    $year = date("Y");  
    $today = date("Y-m-d");
    $day = date('N', strtotime($today));



    $query = $con->prepare("SELECT ShiftID, morning, afternoon, evening FROM shifts WHERE cWeek = $weekNumber and EmpID = $id and Year= $year and DofW = $day");
    $query->execute();
    $row = $query->fetch();

    return $row;
}

function CheckTodayShift($id){
    if(empty(GetTodayShift($id))){
        return false;
    } else {
        return true;
    }
}

function RegisterAttendace($shiftID, $empID){
    $con = DBc::connect();
    $query = $con->prepare("UPDATE shiftattendance SET attendancestatus = 1 WHERE shiftattendance.shiftid = $shiftID AND shiftattendance.empID = $empID");

    $query->execute();
    $result = $query->rowCount();


    if ($result > 0){
        return true;
    } else {
        return false;
    }
    
}

function CheckIfOnTheShift($shiftID, $empID){
    $con = DBc::connect();
    $query = $con->prepare("SELECT attendancestatus FROM shiftattendance WHERE shiftID = '$shiftID' AND shiftattendance.empID = '$empID'");
    $query->execute();
    $row = $query->fetch();

    return $row[0];
} 

function GetDateBounds($week_number,$year){
    for($day=1; $day<=7; $day++)
    {
        if($day==1 || $day==7){
            echo date('d/m/Y', strtotime($year."W".$week_number.$day))."\n";
            if($day==1){
                echo " - ";
            }
        }
    }
}

function isBanned($i,$bannedDays){
    if($bannedDays[0]==$i){
        return "checked";
    }else if($bannedDays[1]==$i){
        return "checked";
    }
    return "";
}

function GetShiftDate($weekNumber,$id,$year){
    $con = DBc::connect();
    $query = $con->prepare("SELECT DofW,morning,afternoon,evening FROM shifts where cWeek = $weekNumber and EmpID = $id and Year= $year");
    $query->execute();
    $rows = $query->fetchAll();

    return $rows;
}

function GetBannedDays($id){
    $con = DBc::connect();
    $query = $con->prepare("SELECT BannedDays FROM employee WHERE ID = $id");
    $query->execute();
    
    $result = $query->fetchAll();
    $input = $result[0] ?? false;
    return explode(',', $input[0]);
}

function SetBannedDays($id,$final){
    $con = DBc::connect();
    $query = $con->prepare("UPDATE employee SET BannedDays = '$final[0],$final[1]' WHERE ID = $id;");
    $query->execute();
}

function GetUserByID($id){
    $con = DBc::connect();
    $query = $con->prepare("SELECT * FROM employee WHERE ID = $id");
    $query->execute();
    
    $row = $query->fetch();

    //var_dump($row);

    $user = new User($row['ID'], $row['FirstName'], $row['LastName'], $row['PhoneNr'],$row['Address'],$row['Email'], $row['Password'], 
    $row['EmergencyC'], $row['EmergencyNr'], $row['WorkingHours'], 
    $row['DOB'], $row['BSN'], $row['Position'], $row['Certifications'], $row['Languages'], $row['StartDate'], $row['EndDate'], $row['Salary']);

    $query = $con->prepare("SELECT Name FROM department INNER JOIN depemp ON depemp.EmpID = $id");
    $query->execute();
    $row = $query->fetch();
    $user->set_department($row[0]);

    return $user;
}
function UpdateUserDetails($id,$email,$password,$address,$phone,$emergencynr,$emergencyc){

    $con = DBc::connect();
    
    $cmd = $con->prepare("UPDATE employee SET Email=:email, Password=:password, Address=:address, PhoneNr=:phone, EmergencyNr=:emergencynr, EmergencyC=:emergencyc WHERE ID=:id;");
    $cmd->bindParam(":id",$id);
    $cmd->bindParam(":email",$email);
    $cmd->bindParam(":password",$password);
    $cmd->bindParam(":address",$address);
    $cmd->bindParam(":phone",$phone);
    $cmd->bindParam(":emergencynr",$emergencynr);
    $cmd->bindParam(":emergencyc",$emergencyc);

    $cmd->execute();
}


