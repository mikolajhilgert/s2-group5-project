<?php include 'usersession.php'?>
<html>
<head>
    <title>Employee dashboard</title>
<link rel="stylesheet" type="text/css" href="Styles/Style.css">
</head>
<body>
<?php include 'navbar.html'; ?>

<div class="contCenter">
    <form action="Handlers/contact.php" method="post" enctype="multipart/form-data">
    <b>Send us a message:</b>
    <br><br><br>
    <textarea id="subject" name="subject" placeholder="Write something.." style="height:200px"></textarea>
    <br><br>
    <div class="updatebutton">
            <button type = "submit" name = "submit" id = "btnupdate">Send</button>
	</div>
  </form>
  </div>

</body>

<footer><?php include 'footer.php'; ?></footer>
</html>