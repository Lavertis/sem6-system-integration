<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../config/Database.php';
include_once '../classes/Cities.php';


if ($_SERVER["REQUEST_METHOD"] !== "POST") {
    http_response_code(400);
    echo json_encode(array("message" => "Method not allowed"));
    exit;
}

$data = json_decode(file_get_contents("php://input"));
$name = $data->name;
$country_code = $data->country_code;
$district = $data->district;
$population = $data->population;

$database = new Database();
$db = $database->getConnection();
$cities = new Cities($db);

if ($error = $cities->create($name, $country_code, $district, $population)) {
    http_response_code(503);
    echo json_encode(array("message" => "$error"));
}
else {
    http_response_code(201);
    echo json_encode(array("message" => "City was created."));
}