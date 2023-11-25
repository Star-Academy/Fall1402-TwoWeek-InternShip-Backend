package com.example;

import java.util.Collections;
import java.util.Set;

public class InvertedIndexWordSearch {
    private InvertedIndex invertedIndex;

    InvertedIndexWordSearch(InvertedIndex givenInvertedIndex){
        this.invertedIndex = givenInvertedIndex;
    }
    
    public Set<String> searchWord(String word) {
        return invertedIndex.getInvertedIndex().getOrDefault(word, Collections.emptySet());
    }
}
