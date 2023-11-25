package com.example;

import java.util.ArrayList;
import java.util.Set;

public class Main {

    public static void main(String[] args) {
        // Initializing userInput for getting data folder path from stdin
        UserInput userInput = new UserInput();
        final String directoryPath = userInput.getInput("Enter Data Folder Path: ");
        
        // Finding name of all files that are in EnglishData directory
        FileReader fileReader = new FileReader();
        ArrayList<String> fileNamesInFolder = fileReader.getFileNames(directoryPath);
        
        // Constructing inverted index
        InvertedIndex invertedIndex = new InvertedIndex();
        invertedIndex.constructInvertedIndexFromFolder(directoryPath, fileNamesInFolder);
        
        // Getting search query and closing scanner
        final String searchQuery = userInput.getInput("Enter Search Query: ");
        userInput.closeScanner();

        // Finding result of searching given query in inverted index
        SearchResults result = new SearchResults(invertedIndex, searchQuery);
        Set<String> searchResults = result.getSearchResult();

        //Printing the results
        SearchResultPrinter searchResultPrinter = new SearchResultPrinter();
        searchResultPrinter.printResults(searchResults);
    }
}