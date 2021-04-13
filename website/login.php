<?php include_once 'Includes/dbh.inc.php'?>
<html>
<head>
    <title>Employee login</title>
<link rel="stylesheet" type="text/css" href="Styles/Style.css">
</head>
<body>
<form action="Handlers/login.php" method="post">

	<div class="container">
	
	<img src="Images/logright.png" id="logi">
	<br>
    <label for="uname"><b>Email</b></label>
    <input type="text" placeholder="Enter email" name="username" required>

    <label for="psw"><b>Password</b></label>
    <input type="password" placeholder="Enter Password" name="password" required>

    <button type="submit">Login</button>
	
	<span class="psw"><a href="#">Forgot password?</a></span>
	</div>
</form>
</body>
</html>