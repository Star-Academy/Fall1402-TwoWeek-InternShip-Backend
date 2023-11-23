import java.nio.file.*;
import java.util.ArrayList;

public class FileReader {
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
}
