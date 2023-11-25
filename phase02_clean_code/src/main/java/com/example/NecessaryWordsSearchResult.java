package com.example;

import java.util.ArrayList;
import java.util.Set;

public class NecessaryWordsSearchResult {
    public Set<String> getNecessaryWordsSearchResult(String[] splittedSearchQuery, InvertedIndex invertedIndex){
        NecessaryWordCategorizer necessaryWordCategorizer = new NecessaryWordCategorizer();
        ArrayList<String> necessaryWords = necessaryWordCategorizer.categorizer(splittedSearchQuery);
        
        NecessaryFileNameCategorizer necessaryFileNameCategorizer = new NecessaryFileNameCategorizer();
        Set<String> necessaryFiles = necessaryFileNameCategorizer.categorizer(invertedIndex, necessaryWords);

        return necessaryFiles;
    }
}
