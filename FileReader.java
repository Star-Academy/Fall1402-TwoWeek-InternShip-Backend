import java.io.File;
import java.io.FileNotFoundException;
import java.nio.file.*;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class FileReader {
    // Takes a directory's path as argument and return all file names that are in that directory
    public static ArrayList<String> getFileNames(String path){

        ArrayList<String> fileNames = new ArrayList<String>();

        Path folder = Paths.get(path);
        
        if (Files.isDirectory(folder)) {
            try {
                
                DirectoryStream<Path> directoryStream = Files.newDirectoryStream(folder);
                
                
                for (Path filePath : directoryStream) {
                    
                    fileNames.add(String.valueOf(filePath.getFileName()));
                }

                directoryStream.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        } else {
            System.out.println("Specified path is not a directory.");
        }

        return fileNames;
    }

    public static ArrayList<Entry_Structure> readFiles(ArrayList<String> fileNames, String directoryPath){

        ArrayList<Entry_Structure> words_list = new ArrayList<Entry_Structure>();
        for (String path : fileNames) {
            try {
                File file = new File(directoryPath + path);
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

        return words_list;
    }
}
