package com.example;

import java.util.HashSet;
import java.util.Set;

public class FinalSearchResult {
    private Set<String> necessaryFiles;
    private Set<String> orFiles;
    private Set<String> forbiddenFiles;

    FinalSearchResult(Set<String> givenNecessaryFiles, Set<String> givenOrFiles, Set<String> givenForbiddenFiles){
        this.necessaryFiles = givenNecessaryFiles;
        this.orFiles = givenOrFiles;
        this.forbiddenFiles = givenForbiddenFiles;
    }

    public Set<String> giveFinalResult(){
        // Final answer is intersection between necessary files and orFiles - forbidden files
        Set<String> intersection = new HashSet<>(necessaryFiles);
        intersection.retainAll(orFiles);
        intersection.removeAll(forbiddenFiles);

        return intersection;
    }
}
