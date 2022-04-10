<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../config/Database.php';
include_once '../classes/Cities.php';


if ($_SERVER["REQUEST_METHOD"] !== "DELETE") {
    http_response_code(400);
    echo json_encode(array("message" => "Method not allowed"));
    exit;
}

$database = new Database();
$db = $database->getConnection();
$cities = new Cities($db);
$id = (isset($_GET['id']) && $_GET['id']) ? $_GET['id'] : '0';

if ($error = $cities->deleteById($id)) {
    http_response_code(503);
    echo json_encode(array("message" => $error));
}
else {
    http_response_code(200);
    echo json_encode(array("message" => $id));
}