package com.lavertis;

import javax.xml.ws.Endpoint;

public class MathOperationsSoapPublisher {
    public static void main(String[] args) {
        var port = System.getenv("PORT");
        if (port == null || port.isEmpty()) {
            port = "80";
        }
        System.out.println("Starting MathOperationsSoapPublisher on port " + port);
        Endpoint.publish("http://0.0.0.0:" + port + "/", new MathOperationsWS());
    }
}
