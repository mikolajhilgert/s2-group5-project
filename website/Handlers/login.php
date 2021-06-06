<?php session_start();?>
<?php

include('../Includes/functions.php');
?>
<html>
    <head><link rel="stylesheet" type="text/css" href="../Styles/Style.css"></head>
    <body>
        <div class = "alert">
        <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
        <?php
        if(LoginUser($_POST['username'], $_POST['password'])){
            header("Location: ../index.php");
        } else {
            echo "Incorect credentials";
        }

        ?>
            <form action="../login.php">
                <input type="submit" value="Click here to try again!" />
            </form>
        </div>
    </body>
</html>