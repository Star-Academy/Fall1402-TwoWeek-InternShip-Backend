import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;
import java.util.Map;

public class Main {

    public static Set<Integer> search_word(String word, Map<String, Set<Integer>> invertedIndex) {
        return invertedIndex.getOrDefault(word, Collections.emptySet());
    }

    public static void main(String[] args) {
        ArrayList<Entry_Structure> words_list = new ArrayList<Entry_Structure>();

        Scanner myScanner = new Scanner(System.in);
        String user_input = myScanner.nextLine();

        String[] user_input_words = user_input.split(" ");

        ArrayList<String> necessary_words = new ArrayList<String>();
        ArrayList<String> or_words = new ArrayList<String>();
        ArrayList<String> not_words = new ArrayList<String>();

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

        ArrayList<String> file_names_in_folder = FileReader.getFileNames("./EnglishData/");

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
                        if (word == "") {
                            continue;
                        }
                        Entry_Structure newEntry = new Entry_Structure(word, fileName);
                        words_list.add(newEntry);
                    }
                }
                myReader.close();

            } catch (FileNotFoundException e) {
                System.out.println("An error occurred.");
                e.printStackTrace();
            }
        }

        Collections.sort(words_list, Comparator.comparing(Entry_Structure::getWord));

        Map<String, Set<Integer>> invertedIndex = new HashMap<>();

        for (Entry_Structure entry : words_list) {
            String word = entry.getWord();
            Set<Integer> documentIds = entry.getFile_names();

            invertedIndex.computeIfAbsent(word, k -> new HashSet<>()).addAll(documentIds);
        }

        Set<Integer> necessary_files = new HashSet<Integer>();
        Set<Integer> forbidden_files = new HashSet<Integer>();
        Set<Integer> optional_files = new HashSet<Integer>();

        for (String n_word : necessary_words) {
            Set<Integer> result = search_word(n_word, invertedIndex);
            necessary_files.addAll(result);
        }

        for (String or_word : or_words) {
            Set<Integer> result = search_word(or_word, invertedIndex);
            optional_files.addAll(result);
        }

        for (String not_word : not_words) {
            Set<Integer> result = search_word(not_word, invertedIndex);
            forbidden_files.addAll(result);
        }

        Set<Integer> intersection = new HashSet<>(necessary_files);
        intersection.addAll(optional_files);

        intersection.removeAll(forbidden_files);

        for (Integer entry : intersection) {
            System.out.println(entry);
        }
    }
}