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
    public static Set<String> searchWord(String word, Map<String, Set<String>> invertedIndex) {
        return invertedIndex.getOrDefault(word, Collections.emptySet());
    }

    public static void main(String[] args) {
        
        // Getting directory path and user input
        Scanner myScanner = new Scanner(System.in);

        System.out.print("Enter Data Folder Path: ");
        final String directoryPath = myScanner.nextLine();

        System.out.print("Enter Search Query: ");
        final String userInput = myScanner.nextLine();
        
        // Finding name of all files that are in EnglishData directory
        ArrayList<String> fileNamesInFolder = FileReader.getFileNames(directoryPath);
        
        // Reading files that are in data direcotry and constructing inverted index table
        Map<String, Set<String>> invertedIndex = new HashMap<>();

        for (String fileName : fileNamesInFolder) {
            try {
                File file = new File(directoryPath + "/" + fileName);
                Scanner myReader = new Scanner(file);

                while (myReader.hasNextLine()) {
                    Set<String> documentIds = new HashSet<String>();
                    documentIds.add(fileName);

                    String data = myReader.nextLine();
                    String[] splittedData = data.split(" ");

                    for (String word : splittedData) {
                        // Ignoring empty words
                        if (word == "") {
                            continue;
                        }
                        // Inserting new entry to inverted index table
                        invertedIndex.computeIfAbsent(word, k -> new HashSet<>()).addAll(documentIds);
                    }
                }
                myReader.close();
            } catch (FileNotFoundException e) {
                System.out.println("An error occurred.");
                e.printStackTrace();
            }
        }
        
        // Splitting user input to undrestand the command
        String[] userInputWords = userInput.split(" ");
        
        ArrayList<String> necessaryWords = new ArrayList<String>();
        ArrayList<String> orWords = new ArrayList<String>();
        ArrayList<String> notWords = new ArrayList<String>();
        
        // Categorizing command words into orWords, necessary and forbidden groups
        for (String word : userInputWords) {
            if (word.startsWith("+")) {
                word = word.replace('+', ' ').trim();
                orWords.add(word);
            } else if (word.startsWith("-")) {
                word = word.replace('-', ' ').trim();
                notWords.add(word);
            } else {
                necessaryWords.add(word);
            }
        }
        myScanner.close();

        // Initializing some sets for forming final answer
        Set<String> necessaryFiles = new HashSet<String>();
        Set<String> forbiddenFiles = new HashSet<String>();
        Set<String> orFiles = new HashSet<String>();

        // Finding intersection between necessary words' file names
        for (String nWord : necessaryWords) {
            if(necessaryFiles.isEmpty()){
                necessaryFiles.addAll(searchWord(nWord, invertedIndex));
            }
            else{
                necessaryFiles.retainAll(searchWord(nWord, invertedIndex));
            }
        }

        // Finding all orWords' file names
        for (String orWord : orWords) {
            orFiles.addAll(searchWord(orWord, invertedIndex));
        }

        // Finding all forbidden words' file names
        for (String notWord : notWords) {
            forbiddenFiles.addAll(searchWord(notWord, invertedIndex));
        }

        // Final answer is intersection between necessary files and orFiles - forbidden files
        Set<String> intersection = new HashSet<>(necessaryFiles);
        intersection.retainAll(orFiles);
        intersection.removeAll(forbiddenFiles);

        //Printing the result
        System.out.println("Results: ");
        for (String entry : intersection) {
            System.out.println(entry);
        }
    }
}