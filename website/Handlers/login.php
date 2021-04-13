<?php session_start();?>
<?php

require_once('../Classes/User.php');
include_once ('../Includes/dbh.inc.php');

$hasMatch = 0;



?>
<html>
    <head><link rel="stylesheet" type="text/css" href="../Styles/Style.css"></head>
    <body>
        <div class = "alert">
        <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
        <?php
                $sql = "SELECT * FROM employee;";
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
						$user->set_id($row['ID']);
                        $user->set_firstname($row['FirstName']);
                        $user->set_lastname($row['LastName']);
                        $user->set_email($row['Email']);
                        $user->set_pass($row['Password']);

                        if (($user->get_email()==($_POST['username'])) and ($user->get_pass()==($_POST['password'])))
                        {
                            
                            $_SESSION['userid'] = $row['ID'];
                            $hasMatch = 1;
							header("Location: ../index.php");

                        }
                        elseif (($user->get_email()==($_POST['username'])) and !($user->get_pass()==($_POST['password'])))
                        {
                            echo "Please make sure you've entered the correct password.";
                            $hasMatch = 1;
                        }
                    }
                    
                    if ($hasMatch == 0){
                        echo "We couldn't find you in our database. Please make sure you've registered before trying to log in!";
                    }
                
               }
        ?>
            <form action="../login.php">
                <input type="submit" value="Click here to try again!" />
            </form>
        </div>
    </body>
</html>