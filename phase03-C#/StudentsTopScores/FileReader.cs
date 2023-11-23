using System;
using Newtonsoft.Json;

namespace StudentsTopScores
{
    class FileReader<T>
    {
        public static List<T> ReadFromFile(string path)
        {
            string studentsJsonContext = File.ReadAllText(path);

            List<T> result = JsonConvert.DeserializeObject<List<T>>(studentsJsonContext)
                ?? new List<T>();

            return result;
        }
    }
}