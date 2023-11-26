package com.example;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;


public class UnnecessaryFileNameCategorizer {

    public Set<String> categorizer(InvertedIndex invertedIndex, ArrayList<String> words){
        InvertedIndexWordSearch invertedIndexWordSearch = new InvertedIndexWordSearch(invertedIndex);

        Set<String> finalResult = new HashSet<String>();
        for (String word : words) {
            Set<String> searchResult = invertedIndexWordSearch.searchWord(word);
                finalResult.addAll(searchResult);
        }

        return finalResult;
    }
}