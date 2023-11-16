import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

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
    }
}