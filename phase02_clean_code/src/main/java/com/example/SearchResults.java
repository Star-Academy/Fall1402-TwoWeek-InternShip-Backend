package com.example;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;

public class SearchResults{
    private InvertedIndex invertedIndex;
    String searchQuery;

    SearchResults(InvertedIndex givenInvertedIndex, String givenSearchQuery){
        this.invertedIndex = givenInvertedIndex;
        this.searchQuery = givenSearchQuery;
    }

    public Set<String> getSearchResult(){
        // Splitting user input to undrestand the command
        String[] splittedSearchQuery = searchQuery.split(" ");

        // Categorizing command words into or_words, necessary and forbidden groups
        NecessaryWordCategorizer necessaryWordCategorizer = new NecessaryWordCategorizer();
        ArrayList<String> necessaryWords = necessaryWordCategorizer.categorizer(splittedSearchQuery);
        
        UnnecessaryWordCategorizer unnecessaryWordCategorizer = new UnnecessaryWordCategorizer();
        ArrayList<String> orWords = unnecessaryWordCategorizer.categorizer(splittedSearchQuery, "+");
        ArrayList<String> notWords = unnecessaryWordCategorizer.categorizer(splittedSearchQuery, "-");

        // Initializing necessary file name categorizer and applying it on invertedIndex
        NecessaryFileNameCategorizer necessaryFileNameCategorizer = new NecessaryFileNameCategorizer();
        Set<String> necessaryFiles = necessaryFileNameCategorizer.categorizer(invertedIndex, necessaryWords);
        
        // Initializing unnecessary file name categorizer and applying it on invertedIndex
        UnnecessaryFileNameCategorizer unnecessaryFileNameCategorizer = new UnnecessaryFileNameCategorizer();
        Set<String> orFiles = unnecessaryFileNameCategorizer.categorizer(invertedIndex, orWords);
        Set<String> forbiddenFiles = unnecessaryFileNameCategorizer.categorizer(invertedIndex, notWords);

        // Final answer is intersection between necessary files and orFiles - forbidden files
        Set<String> intersection = new HashSet<>(necessaryFiles);
        intersection.retainAll(orFiles);
        intersection.removeAll(forbiddenFiles);

        return intersection;
    }
}
