package com.example;

import java.util.ArrayList;

public class NecessaryWordCategorizer {
      public ArrayList<String> categorizer(String[] str){

        ArrayList<String> result = new ArrayList<String>();

        for(String word : str){
            if((!word.startsWith("+")) && (!word.startsWith("-"))){
                result.add(word);
            }
        }

        return result;
    }
}
