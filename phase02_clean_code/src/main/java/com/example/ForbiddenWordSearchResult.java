package com.example;

import java.util.ArrayList;
import java.util.Set;

public class ForbiddenWordSearchResult {
    public Set<String> getForbiddenWordsSearchResult(String[] splittedSearchQuery, InvertedIndex invertedIndex){
        UnnecessaryWordCategorizer unnecessaryWordCategorizer = new UnnecessaryWordCategorizer();
        ArrayList<String> forbiddenWords = unnecessaryWordCategorizer.categorizer(splittedSearchQuery, "-");

        UnnecessaryFileNameCategorizer unnecessaryFileNameCategorizer = new UnnecessaryFileNameCategorizer();
        Set<String> forbiddenFiles = unnecessaryFileNameCategorizer.categorizer(invertedIndex, forbiddenWords);
        
        return forbiddenFiles;
    }
}
