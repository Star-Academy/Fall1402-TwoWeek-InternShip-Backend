import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;
import java.util.Map;

public class Main {

    // Searchs a word in inverted index then returns name of files that are containing that word
    public static Set<Integer> search_word(String word, Map<String, Set<Integer>> invertedIndex) {
        return invertedIndex.getOrDefault(word, Collections.emptySet());
    }

    public static void main(String[] args) {
        ArrayList<Entry_Structure> words_list = new ArrayList<Entry_Structure>();   // An array list for storing words and file name

        // Getting user input
        Scanner myScanner = new Scanner(System.in);
        String user_input = myScanner.nextLine();

        // Splitting user input to undrestand the command
        String[] user_input_words = user_input.split(" ");

        ArrayList<String> necessary_words = new ArrayList<String>();
        ArrayList<String> or_words = new ArrayList<String>();
        ArrayList<String> not_words = new ArrayList<String>();

        // Categorizing command words into or_words, necessary and forbidden groups
        for (String word : user_input_words) {
            if (word.startsWith("+")) {
                word = word.replace('+', ' ');
                word = word.trim();
                or_words.add(word);
            } else if (word.startsWith("-")) {
                word = word.replace('-', ' ');
                word = word.trim();
                not_words.add(word);
            } else {
                necessary_words.add(word);
            }
        }
        myScanner.close();

        // Finding name of all files that are in EnglishData directory
        ArrayList<String> file_names_in_folder = FileReader.getFileNames("./EnglishData/");

        // Reading files that are in EnglishData directory
        for (String path : file_names_in_folder) {
            try {
                File file = new File("./EnglishData/" + path);
                Scanner myReader = new Scanner(file);

                while (myReader.hasNextLine()) {
                    String data = myReader.nextLine();
                    String[] splitted_data = data.split(" ");

                    Set<Integer> fileName = new HashSet<Integer>();
                    fileName.add(Integer.parseInt(path));

                    for (String word : splitted_data) {
                        // Ignoring empty words
                        if (word == "") {
                            continue;
                        }
                        Entry_Structure newEntry = new Entry_Structure(word, fileName);
                        // Inserting newEntry into words_list
                        words_list.add(newEntry);
                    }
                }
                myReader.close();
            } catch (FileNotFoundException e) {
                System.out.println("An error occurred.");
                e.printStackTrace();
            }
        }

        // Initializing inverted index table
        Map<String, Set<Integer>> invertedIndex = new HashMap<>();

        // Constructing inverted index table
        for (Entry_Structure entry : words_list) {
            String word = entry.getWord();
            Set<Integer> documentIds = entry.getFile_names();

            invertedIndex.computeIfAbsent(word, k -> new HashSet<>()).addAll(documentIds);
        }

        // Initializing some sets for forming final answer
        Set<Integer> necessary_files = new HashSet<Integer>();
        Set<Integer> forbidden_files = new HashSet<Integer>();
        Set<Integer> or_files = new HashSet<Integer>();

        // Finding intersection between necessary words' file names
        for (String n_word : necessary_words) {
            Set<Integer> result = search_word(n_word, invertedIndex);
            if(necessary_files.isEmpty()){
                necessary_files.addAll(result);
            }
            else{
                necessary_files.retainAll(result);
            }
        }

        // Finding all or_words' file names
        for (String or_word : or_words) {
            Set<Integer> result = search_word(or_word, invertedIndex);
            or_files.addAll(result);
        }

        // Finding all forbidden words' file names
        for (String not_word : not_words) {
            Set<Integer> result = search_word(not_word, invertedIndex);
            forbidden_files.addAll(result);
        }

        // Final answer is intersection between necessary files and or_files - forbidden files
        Set<Integer> intersection = new HashSet<>(necessary_files);
        intersection.retainAll(or_files);
        intersection.removeAll(forbidden_files);

        //Printing the result
        for (Integer entry : intersection) {
            System.out.println(entry);
        }
    }
}