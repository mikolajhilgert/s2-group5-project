<?php

class DBc{


  public static function connect(){
    $host = "studmysql01.fhict.local";
    $username = "dbi456096";
    $password = "logixtic";
    $dbName = "dbi456096";


    try{
      $con = new PDO("mysql:host=$host;dbname=$dbName",$username,$password);
      $con-> setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_WARNING);
      //echo "Connected successfully";
    }catch (PDOException $e){
      echo "Connection failed: " . $e->getMessage();
    }
    return $con;
  }

}
