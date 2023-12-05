package com.example;

import java.util.Collections;
import java.util.Map;
import java.util.Set;

public class WordFileNameFinder {
      // Searchs a word in inverted index then returns name of files that are containing that word
    public static Set<String> searchWord(String word, Map<String, Set<String>> invertedIndex) {
        return invertedIndex.getOrDefault(word, Collections.emptySet());
    }
}
