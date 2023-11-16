import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Main {

    public static Entry_Structure search_word(String word, ArrayList<Entry_Structure> words_list) {

        Stream<Entry_Structure> result = words_list.stream().filter(w -> word.equals(w.getWord()));

        ArrayList<Entry_Structure> rl_result = result.collect(Collectors.toCollection(ArrayList::new));

        return rl_result.get(0);
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

        int counter = 0;

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
                        Entry_Structure newEntry = new Entry_Structure(word, 1, fileName);
                        words_list.add(newEntry);
                    }
                }
                myReader.close();

            } catch (FileNotFoundException e) {
                System.out.println("An error occurred.");
                e.printStackTrace();
            }

            if(counter > 5)
            {
                break;
            }
            counter++;
        }

        Collections.sort(words_list, Comparator.comparing(Entry_Structure::getWord));

        ArrayList<Entry_Structure> mergedList = new ArrayList<>();

        for (Entry_Structure entry : words_list) {
            boolean found = false;

            for (Entry_Structure mergedEntry : mergedList) {
                if (mergedEntry.getWord().equals(entry.getWord())) {
                    int new_count = mergedEntry.getCount() + 1;
                    mergedEntry.setCount(new_count);

                    Set<Integer> new_file_names = entry.getFile_names();
                    new_file_names.addAll(mergedEntry.getFile_names());
                    mergedEntry.setFile_names(new_file_names);
                    found = true;
                    break;
                }
            }
            if (!found) {
                mergedList.add(entry);
            }
        }

        Set<Integer> necessary_files = new HashSet<Integer>();
        Set<Integer> forbidden_files = new HashSet<Integer>();
        Set<Integer> optional_files = new HashSet<Integer>();

        for (String n_word : necessary_words) {
            Entry_Structure result = search_word(n_word, words_list);
            necessary_files.addAll(result.getFile_names());
        }

        for (String or_word : or_words) {
            Entry_Structure result = search_word(or_word, words_list);
            optional_files.addAll(result.getFile_names());
        }

        for (String not_word : not_words) {
            Entry_Structure result = search_word(not_word, words_list);
            forbidden_files.addAll(result.getFile_names());
        }
        
        Set<Integer> intersection = new HashSet<>(necessary_files);
        intersection.retainAll(optional_files);

        intersection.removeAll(forbidden_files);

        for (Integer entry : intersection) {
            System.out.println(entry);
        }
    }
}