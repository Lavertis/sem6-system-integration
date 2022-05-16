<?php
// example of update actor table, all first_name ADAM will be updated to CHRIS
$servername = "127.0.0.1";
$username = "sakila2";
$password = "pass";
$database = "sakila";

$conn = new mysqli($servername, $username, $password, $database);
if ($conn->connect_error)
    die("Database connection failed: " . $conn->connect_error);
echo "Database connected successfully, username " . $username . "<br><br>";

$sql = "UPDATE actor SET first_name = 'CHRIS' WHERE first_name = 'ADAM'";
$conn->query($sql);
echo "Table actor updated";
$conn->close();