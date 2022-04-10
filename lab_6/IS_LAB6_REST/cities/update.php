<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../config/Database.php';
include_once '../classes/Cities.php';


if ($_SERVER["REQUEST_METHOD"] !== "PUT") {
    http_response_code(400);
    echo json_encode(array("message" => "Method not allowed"));
    exit;
}

$data = json_decode(file_get_contents("php://input"));
$id = (isset($_GET['id']) && $_GET['id']) ? $_GET['id'] : '0';
$name = $data->name;
$country_code = $data->country_code;
$district = $data->district;
$population = $data->population;

$database = new Database();
$db = $database->getConnection();
$cities = new Cities($db);

if ($error = $cities->updateCityById($id, $name, $country_code, $district, $population)) {
    http_response_code(400);
    echo json_encode(array("message" => $error));
}
else {
    http_response_code(200);
    echo json_encode(array("message" => "City was updated."));
}