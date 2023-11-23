import java.util.HashSet;
import java.util.Set;

public class EntryStructure {
    private String word;
    private Set<String> fileNames = new HashSet<String>();

    public EntryStructure(String word, Set<String> fileNames) {
        this.word = word;
        this.fileNames = fileNames;
    }

    public String getWord() {
        return word;
    }

    public Set<String> getFileNames() {
        return fileNames;
    }
}