package com.lavertis.models;

public record City(Integer id, String name, String countryCode, String district, Integer population) {
    @Override
    public String toString() {
        return "City{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", countryCode='" + countryCode + '\'' +
                ", district=" + district +
                ", population='" + population + '\'' +
                '}';
    }
}
