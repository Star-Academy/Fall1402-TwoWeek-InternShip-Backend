import java.util.HashSet;
import java.util.Set;

public class EntryStructure {
    private String word;
    private Set<Integer> fileNames = new HashSet<Integer>();

    public EntryStructure(String word, Set<Integer> file_names) {
        this.word = word;
        this.fileNames = file_names;
    }

    public String getWord() {
        return word;
    }

    public Set<Integer> getFile_names() {
        return fileNames;
    }
}