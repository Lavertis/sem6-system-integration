package com.lavertis;

import com.lavertis.models.City;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.URL;
import java.util.ArrayList;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        try {
            String temp_url = "http://localhost:8000/cities/read";
            URL url = new URL(temp_url);
            System.out.println("Sending request to: " + url);
            InputStream is = url.openStream();
            System.out.println("Getting response from: " + url);
            String source = new BufferedReader(new InputStreamReader(is)).lines().collect(Collectors.joining("\n"));
            System.out.println("Data processing...");
            JSONObject json = new JSONObject(source);
            JSONArray receivedData = (JSONArray) json.get("cities");

            var cities = new ArrayList<City>();
            receivedData.forEach(c -> {
                JSONObject cityObject = (JSONObject) c;
                var id = cityObject.getInt("ID");
                var name = cityObject.getString("Name");
                var country = cityObject.getString("CountryCode");
                var district = cityObject.getString("District");
                var population = cityObject.getInt("Population");
                var city = new City(id, name, country, district, population);
                cities.add(city);
            });

            System.out.println("Cities:");
            cities.forEach(System.out::println);
        } catch (Exception e) {
            System.err.println();
            e.printStackTrace();
        }
    }
}
