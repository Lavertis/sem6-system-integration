package com.lavertis;

import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.jws.soap.SOAPBinding;

@WebService
@SOAPBinding(style = SOAPBinding.Style.RPC)
public interface MathOperationsSoapInterface {
    @WebMethod
    double add(double a, double b);

    @WebMethod
    double subtract(double a, double b);

    @WebMethod
    double multiply(double a, double b);

    @WebMethod
    double divide(double a, double b);
}
