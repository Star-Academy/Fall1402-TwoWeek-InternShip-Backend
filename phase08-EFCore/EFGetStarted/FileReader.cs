using System;
using Newtonsoft.Json;

namespace EFGetStarted
{
    class FileReader<T>
    {
        public static List<T> ReadFromFile(string path)
        {
            try
            {
                string studentsJsonContext = File.ReadAllText(path);
                List<T> result = JsonConvert.DeserializeObject<List<T>>(studentsJsonContext)
                ?? new List<T>();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<T>();
            }
        }
    }
}