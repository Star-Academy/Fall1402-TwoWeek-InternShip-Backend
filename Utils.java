import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class Utils {

    // Searchs a word in inverted index then returns name of files that are containing that word
    public static Set<Integer> search_word(String word, Map<String, Set<Integer>> invertedIndex) {
        return invertedIndex.getOrDefault(word, Collections.emptySet());
    }
    
    // Takes two strings, str and target and finds all words in str that starts with target character
    public static ArrayList<String> find_words_start_with(String str, String target){
        // Splitting user input to undrestand the command
        String[] user_input_words = str.split(" ");

        ArrayList<String> result = new ArrayList<String>();

        if(target == ""){
            for(String word : user_input_words){
                if((!word.startsWith("+")) && (!word.startsWith("-"))){
                    result.add(word);
                }
            }
        }
        else{
            for(String word : user_input_words){
                if(word.startsWith(target)){
                    word = word.replace(target.charAt(0), ' ');
                    word = word.trim();
                    result.add(word);
                }
            }
        }

        return result;
    }

    public static Set<Integer> file_name_categorizer(Map<String, Set<Integer>> invertedIndex, ArrayList<String> words, boolean is_necessary){
        Set<Integer> final_result = new HashSet<Integer>();

        if(is_necessary){
            for (String word : words) {
                Set<Integer> search_result = search_word(word, invertedIndex);
                if(final_result.isEmpty()){
                    final_result.addAll(search_result);
                }
                else{
                    final_result.retainAll(search_result);
                }
            }
        }else{
            for (String word : words) {
                Set<Integer> search_result = search_word(word, invertedIndex);
                final_result.addAll(search_result);
            }
        }

        return final_result;
    }

    public static void print_results(Set<Integer> result){
        System.out.println("File Names that are containing given words are listed below: ");
        for(Integer entry : result){
            System.out.println(entry);
        }
    }
}
