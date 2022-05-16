<?php
// example of update actor table, all first_name ADAM will be updated to CHRIS
$serverName = "localhost";
$username = "sakila2";
$password = "pass";
$database = "sakila";

$conn = new mysqli($serverName, $username, $password,
    $database);
if ($conn->connect_error) {
    die("Database connection failed: " . $conn->connect_error);
}
echo "Database connected successfully, username " . $username . "<br><br>";

$conn->begin_transaction();
$sql = "UPDATE actor SET first_name = 'CHRIS' WHERE first_name = 'ADAM'";
$conn->query($sql);
echo "Table actor updated";
sleep(5);
$conn->commit();
$conn->close();