import java.util.HashSet;
import java.util.Set;

public class Entry_Structure {
    private String word;
    private int count;
    private Set<Integer> file_names = new HashSet<Integer>();

    public Entry_Structure(String word, int count, Set<Integer> file_names) {
        this.word = word;
        this.count = count;
        this.file_names = file_names;
    }

    public String getWord() {
        return word;
    }

    public void setWord(String word) {
        this.word = word;
    }

    public int getCount() {
        return count;
    }

    public void setCount(int count) {
        this.count = count;
    }

    public Set<Integer> getFile_names() {
        return file_names;
    }

    public void setFile_names(Set<Integer> file_names) {
        this.file_names = file_names;
    }

}