<?php
// example of update actor table, all first_name CHRIS will be updated to ADAM
$serverName = "127.0.0.1";
$username = "sakila2";
$password = "pass";
$database = "sakila";

$conn = new mysqli($serverName, $username, $password, $database);
if ($conn->connect_error) {
    die("Database connection failed: " . $conn->connect_error);
}
echo "Database connected successfully, username " . $username . "<br><br>";

$sql = "UPDATE actor SET first_name = 'ADAM' WHERE first_name = 'CHRIS'";
$conn->query($sql);
echo "Table actor updated";
$conn->close();
