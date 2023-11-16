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
    public static void main(String[] args) {
         ArrayList<Entry_Structure> words_list = new ArrayList<Entry_Structure>();

        Scanner myScanner = new Scanner(System.in);
        String user_input = myScanner.nextLine();

        System.out.println(user_input);
        myScanner.close();

        ArrayList<String> file_names_in_folder = FileReader.getFileNames("./EnglishData/");

        for (String path : file_names_in_folder) {
            try {
                File file = new File("./EnglishData/"+path);
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
        
        Stream<Entry_Structure> result = mergedList.stream().filter(w->user_input.equals(w.getWord()));
        
        ArrayList<Entry_Structure> rl_result = result.collect(Collectors.toCollection(ArrayList::new));

        for (Entry_Structure entry_Structure : rl_result) {
            System.out.print(entry_Structure.getWord() + " : " + entry_Structure.getCount() + " : ");
            for(int file_number : entry_Structure.getFile_names()){
                System.out.print(file_number + ", ");
            }
            System.out.println();
        }
    }
}