package com.example;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        
        // Getting directory path and user input
        Scanner myScanner = new Scanner(System.in);

        System.out.print("Enter Data Folder Path: ");
        final String directoryPath = myScanner.nextLine();

        System.out.print("Enter Search Query: ");
        final String userInput = myScanner.nextLine();
        
        myScanner.close();
        
        // Finding name of all files that are in EnglishData directory
        ArrayList<String> fileNamesInFolder = FileReader.getFileNames(directoryPath);
        
        // Reading files that are in data direcotry and constructing inverted index table
        Map<String, Set<String>> invertedIndex = new HashMap<>();

        for (String fileName : fileNamesInFolder) {
            try {
                File file = new File(directoryPath + "/" + fileName);
                Scanner myReader = new Scanner(file);

                while (myReader.hasNextLine()) {
                    Set<String> documentIds = new HashSet<String>();
                    documentIds.add(fileName);

                    String data = myReader.nextLine();
                    String[] splittedData = data.split(" ");

                    for (String word : splittedData) {
                        // Ignoring empty words
                        if (word == "") {
                            continue;
                        }
                        // Inserting new entry to inverted index table
                        invertedIndex.computeIfAbsent(word, k -> new HashSet<>()).addAll(documentIds);
                    }
                }
                myReader.close();
            } catch (FileNotFoundException e) {
                System.out.println("An error occurred.");
                e.printStackTrace();
            }
        }
        
        // Categorizing command words into or_words, necessary and forbidden groups
        ArrayList<String> necessaryWords = WordCategorizer.categorizer(userInput, "");
        ArrayList<String> orWords = WordCategorizer.categorizer(userInput, "+");
        ArrayList<String> notWords = WordCategorizer.categorizer(userInput, "-");
        
        // Initializing some sets for forming final answer
        Set<String> necessaryFiles = FileNameCategorizer.categorizer(invertedIndex, necessaryWords, true);
        Set<String> orFiles = FileNameCategorizer.categorizer(invertedIndex, orWords, false);
        Set<String> forbiddenFiles = FileNameCategorizer.categorizer(invertedIndex, notWords, false);

        // Final answer is intersection between necessary files and orFiles - forbidden files
        Set<String> intersection = new HashSet<>(necessaryFiles);
        intersection.retainAll(orFiles);
        intersection.removeAll(forbiddenFiles);

        //Printing the result
        System.out.println("Results: ");
        for (String entry : intersection) {
            System.out.println(entry);
        }
    }
}