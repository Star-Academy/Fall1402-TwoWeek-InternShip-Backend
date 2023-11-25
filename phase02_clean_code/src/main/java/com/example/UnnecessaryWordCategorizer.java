package com.example;

import java.util.ArrayList;

public class UnnecessaryWordCategorizer {
      public ArrayList<String> categorizer(String[] str, String target){

        ArrayList<String> result = new ArrayList<String>();

        for(String word : str){
            if(word.startsWith(target)){
                word = word.replace(target.charAt(0), ' ').trim();
                result.add(word);
            }
        }

        return result;
    }
}
