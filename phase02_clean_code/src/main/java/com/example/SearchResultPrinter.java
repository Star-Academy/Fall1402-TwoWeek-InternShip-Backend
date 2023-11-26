package com.example;

import java.util.Set;

public class SearchResultPrinter {
    
    public void printResults(Set<String> results) {
        System.out.println("Results: ");
        for (String entry : results) {
            System.out.println(entry);
        }
    }
}