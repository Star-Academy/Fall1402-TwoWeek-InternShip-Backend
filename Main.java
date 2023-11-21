import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

import java.util.Map;

public class Main {

    public static void main(String[] args) {
        ArrayList<Entry_Structure> words_list = new ArrayList<Entry_Structure>();   // An array list for storing words and file name

        // Getting user input
        Scanner myScanner = new Scanner(System.in);
        String user_input = myScanner.nextLine();
        myScanner.close();


        // Categorizing command words into or_words, necessary and forbidden groups
        ArrayList<String> necessary_words = Utils.find_words_start_with(user_input, "");
        ArrayList<String> or_words = Utils.find_words_start_with(user_input, "+");
        ArrayList<String> not_words = Utils.find_words_start_with(user_input, "-");


        // Finding name of all files that are in EnglishData directory
        ArrayList<String> file_names_in_folder = FileReader.getFileNames("./EnglishData/");


        // Reading files that are in EnglishData directory
        words_list = FileReader.readFiles(file_names_in_folder, "./EnglishData/");


        // Initializing inverted index table
        Map<String, Set<Integer>> invertedIndex = new HashMap<>();


        // Constructing inverted index table
        for (Entry_Structure entry : words_list) {
            String word = entry.getWord();
            Set<Integer> documentIds = entry.getFile_names();

            invertedIndex.computeIfAbsent(word, k -> new HashSet<>()).addAll(documentIds);
        }


        // Initializing some sets and forming final answer
        Set<Integer> necessary_files = Utils.file_name_categorizer(invertedIndex, necessary_words, true);
        Set<Integer> or_files = Utils.file_name_categorizer(invertedIndex, or_words, false);
        Set<Integer> forbidden_files = Utils.file_name_categorizer(invertedIndex, not_words, false);


        // Final answer is intersection between necessary files and or_files - forbidden files
        Set<Integer> intersection = new HashSet<>(necessary_files);
        intersection.retainAll(or_files);
        intersection.removeAll(forbidden_files);


        //Printing the result
        Utils.print_results(intersection);
    }
}