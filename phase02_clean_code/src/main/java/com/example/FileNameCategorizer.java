package com.example;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class FileNameCategorizer {
    public static Set<String> categorizer(Map<String, Set<String>> invertedIndex, ArrayList<String> words, boolean isNecessary){
        Set<String> finalResult = new HashSet<String>();

        if(isNecessary){
            for (String word : words) {
                Set<String> searchResult = WordFileNameFinder.searchWord(word, invertedIndex);
                if(finalResult.isEmpty()){
                    finalResult.addAll(searchResult);
                }
                else{
                    finalResult.retainAll(searchResult);
                }
            }
        }else{
            for (String word : words) {
                Set<String> searchResult = WordFileNameFinder.searchWord(word, invertedIndex);
                finalResult.addAll(searchResult);
            }
        }

        return finalResult;
    }
}
