package com.example;

import java.util.HashSet;
import java.util.Set;
import lombok.Getter;

public class EntryStructure {
    @Getter
    private String word;
    @Getter
    private Set<String> fileNames = new HashSet<String>();

    public EntryStructure(String word, Set<String> fileNames) {
        this.word = word;
        this.fileNames = fileNames;
    }
}