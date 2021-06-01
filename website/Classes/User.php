<?php
class User {
  private $id;
  private $email;
  private $firstname;
  private $lastname;
  private $password;
  private $phone;
  private $address;
  private $emergencyc;
  private $emergencynr;
  private $hours;
  private $dob;
  private $bsn;
  private $position;
  private $certificates;
  private $languages;
  private $sdate;
  private $endate;
  private $duration;
  private $department;
  private $salary;
  
  public function __construct($id, $firstname, $lastname, $phone, $address, $email, 
  $password, $emergencyc, $emergencynr, $hours, $dob, $bsn, $position, $certificates, $languages, $sdate, $endate, $salary) {
    $this->$id = $id;
    $this->$firstname = $firstname;
    $this->lastname = $lastname;
    $this->$phone = $phone;
    $this->$address = $address;
    $this->$email = $email;
    $this->$password = $password;
    $this->$emergencyc = $emergencyc;
    $this->$emergencynr = $emergencynr;
    $this->$hours = $hours;
    $this->$dob = $dob;
    $this->$bsn = $bsn;
    $this->$position = $position;
    $this->$certificates = $certificates; 
    $this->$languages = $languages;
    $this->$sdate = $sdate;
    $this->$endate = $endate;
    $this->$salary = $salary;

}

  
  function set_id($id) {
    $this->id = $id;
  }
  function set_firstname($firstname) {
    $this->firstname = $firstname;
  }
  function set_lastname($lastname) {
    $this->lastname = $lastname;
  }
  function set_email($email) {
    $this->email = $email;
  }
  function set_pass($password) {
    $this->password = $password;
  }
  function set_phone($phone) {
    $this->phone = $phone;
  }
  function set_address($address) {
    $this->address = $address;
  }
  function set_emergencyc($emergencyc) {
    $this->emergencyc = $emergencyc;
  }
  function set_emergencynr($emergencynr) {
    $this->emergencynr = $emergencynr;
  }
  function set_hours($hours) {
    $this->hours = $hours;
  }
  function set_dob($dob) {
    $this->dob = $dob;
  }
  function set_bsn($bsn) {
    $this->bsn = $bsn;
  }
  function set_position($position) {
    $this->position = $position;
  }
  function set_certificates($certificates) {
    $this->certificates = $certificates;
  }
  function set_languages($languages) {
    $this->languages = $languages;
  }
  function set_sdate($sdate) {
    $this->sdate = $sdate;
  }
function set_edate($edate) {
    $this->edate = $edate;
  }   
  function set_duration($duration) {
    $this->duration = $duration;
  } 
  function set_department($department) {
    $this->department = $department;
  } 
  
  function set_salary($salary) {
    $this->salary = $salary;
  } 
  
  function get_id($id) {
  $this->id = $id;
  }
  function get_firstname() {
    return $this->firstname;
  }
  function get_lastname() {
    return $this->lastname;
  }
  function get_email() {
    return $this->email;
  }
  function get_pass() {
    return $this->password;
  }
  function get_phone() {
    return $this->phone;
  }
  function get_address() {
    return $this->address;
  }
  function get_emergencyc() {
    return $this->emergencyc;
  }
  function get_emergencynr() {
    return $this->emergencynr;
  }
  function get_hours() {
    return $this->hours;
  }
  function get_dob() {
    return $this->dob;
  }
  function get_bsn() {
    return $this->bsn;
  }
  function get_position() {
    return $this->position;
  }
  function get_certificates() {
    return $this->certificates;
  }
  function get_languages() {
    return $this->languages;
  }
  function get_sdate() {
    return $this->sdate;
  }
  function get_edate() {
    return $this->edate;
  }
  function get_duration() {
    return $this->duration;
  }
  function get_department() {
    return $this->department;
  }
  
  function get_salary() {
    return $this->salary;
  }
  
}
?>