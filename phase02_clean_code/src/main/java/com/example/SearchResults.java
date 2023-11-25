package com.example;

import java.util.Set;

public class SearchResults{
    private InvertedIndex invertedIndex;
    String searchQuery;

    SearchResults(InvertedIndex givenInvertedIndex, String givenSearchQuery){
        this.invertedIndex = givenInvertedIndex;
        this.searchQuery = givenSearchQuery;
    }

    public Set<String> getSearchResult(){
        // Splitting user input to undrestand the command
        String[] splittedSearchQuery = searchQuery.split(" ");

        NecessaryWordsSearchResult necessaryWordsSearchResult = new NecessaryWordsSearchResult();
        OrWordsSearchResult orWordsSearchResult = new OrWordsSearchResult();
        ForbiddenWordSearchResult forbiddenWordSearchResult = new ForbiddenWordSearchResult();

        Set<String> necessaryFiles = necessaryWordsSearchResult.getNecessaryWordsSearchResult(splittedSearchQuery, invertedIndex);
        Set<String> orFiles = orWordsSearchResult.getOrWordsSearchResult(splittedSearchQuery, invertedIndex);
        Set<String> forbiddenFiles = forbiddenWordSearchResult.getForbiddenWordsSearchResult(splittedSearchQuery, invertedIndex);

        FinalSearchResult finalSearchResult = new FinalSearchResult(necessaryFiles, orFiles, forbiddenFiles);
        Set<String> finalResult = finalSearchResult.giveFinalResult();

        return finalResult;
    }
}
