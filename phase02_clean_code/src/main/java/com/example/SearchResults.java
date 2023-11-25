package com.example;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;

public class SearchResults {
    private InvertedIndex invertedIndex;
    String searchQuery;

    SearchResults(InvertedIndex givenInvertedIndex, String givenSearchQuery){
        this.invertedIndex = givenInvertedIndex;
        this.searchQuery = givenSearchQuery;
    }

    public Set<String> getSearchResult(){
        // Categorizing command words into or_words, necessary and forbidden groups
        ArrayList<String> necessaryWords = WordCategorizer.categorizer(searchQuery, "");
        ArrayList<String> orWords = WordCategorizer.categorizer(searchQuery, "+");
        ArrayList<String> notWords = WordCategorizer.categorizer(searchQuery, "-");

        // Initializing our categorizers
        NecessaryFileNameCategorizer necessaryFileNameCategorizer = new NecessaryFileNameCategorizer();
        UnnecessaryFileNameCategorizer unnecessaryFileNameCategorizer = new UnnecessaryFileNameCategorizer();
        
        // Initializing some sets for forming final answer
        Set<String> necessaryFiles = necessaryFileNameCategorizer.categorizer(invertedIndex, necessaryWords);
        Set<String> orFiles = unnecessaryFileNameCategorizer.categorizer(invertedIndex, orWords);
        Set<String> forbiddenFiles = unnecessaryFileNameCategorizer.categorizer(invertedIndex, notWords);

        // Final answer is intersection between necessary files and orFiles - forbidden files
        Set<String> intersection = new HashSet<>(necessaryFiles);
        intersection.retainAll(orFiles);
        intersection.removeAll(forbiddenFiles);

        return intersection;
    }
}
