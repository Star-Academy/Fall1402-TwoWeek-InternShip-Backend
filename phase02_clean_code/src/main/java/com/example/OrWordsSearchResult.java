package com.example;

import java.util.ArrayList;
import java.util.Set;

public class OrWordsSearchResult {
    public Set<String> getOrWordsSearchResult(String[] splittedSearchQuery, InvertedIndex invertedIndex){
        UnnecessaryWordCategorizer unnecessaryWordCategorizer = new UnnecessaryWordCategorizer();
        ArrayList<String> orWords = unnecessaryWordCategorizer.categorizer(splittedSearchQuery, "+");

        UnnecessaryFileNameCategorizer unnecessaryFileNameCategorizer = new UnnecessaryFileNameCategorizer();
        Set<String> orFiles = unnecessaryFileNameCategorizer.categorizer(invertedIndex, orWords);
        
        return orFiles;
    }
}
