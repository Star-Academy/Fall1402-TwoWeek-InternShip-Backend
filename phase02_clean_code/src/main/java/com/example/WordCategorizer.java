package com.example;

import java.util.ArrayList;

public class WordCategorizer {
    // Takes two strings, str and target and finds all words in str that starts with target character
    public ArrayList<String> categorizer(String[] str, String target){

        ArrayList<String> result = new ArrayList<String>();

        if(target == ""){
            for(String word : str){
                if((!word.startsWith("+")) && (!word.startsWith("-"))){
                    result.add(word);
                }
            }
        }
        else{
            for(String word : str){
                if(word.startsWith(target)){
                    word = word.replace(target.charAt(0), ' ').trim();
                    result.add(word);
                }
            }
        }

        return result;
    }
}
