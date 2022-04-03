package com.lavertis;

import javax.jws.WebService;

@WebService(endpointInterface = "com.lavertis.MathOperationsSoapInterface")
public class MathOperationsWS implements MathOperationsSoapInterface {
    @Override
    public double add(double a, double b) {
        return a + b;
    }

    @Override
    public double subtract(double a, double b) {
        return a - b;
    }

    @Override
    public double multiply(double a, double b) {
        return a * b;
    }

    @Override
    public double divide(double a, double b) {
        if (b == 0) {
            throw new ArithmeticException("Division by zero");
        }
        return a / b;
    }
}
