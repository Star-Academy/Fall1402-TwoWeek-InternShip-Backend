package com.example;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Scanner;
import java.util.Set;

import lombok.Getter;

public class InvertedIndex {
    @Getter
    private Map<String, Set<String>> invertedIndex;

    InvertedIndex(){
        this.invertedIndex = new HashMap<>();
    }

    public void constructInvertedIndexFromFolder(String directoryPath, ArrayList<String> fileNamesInFolder){
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
    }
}
