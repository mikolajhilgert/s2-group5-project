<?php
session_start();

    if ( isset( $_SESSION['userid'] ) ) {
    
	
    } else {
    // Redirect them to the login page
    header("Location: login.php");
    }

?>