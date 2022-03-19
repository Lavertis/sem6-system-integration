<?php
$servername = "127.0.0.1";
$username = "sakila1";
$password = "pass";
$database = "sakila";

$conn = new mysqli($servername, $username, $password, $database);
if ($conn->connect_error)
    die("Database connection failed: " . $conn->connect_error);

echo "Databse connected successfully, username " . $username . "<br><br>";
$sql = "INSERT INTO actor (first_name, last_name) VALUES ('ADAM', 'MAŁYSZ')";
$conn->query($sql);

$sql = "DELETE FROM actor WHERE (first_name='ADAM' AND last_name='MAŁYSZ')";
$conn->query($sql);

$conn->close();