using FilterTextApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterTextApplication.Helpers
{
    public class FileReaderHelper : IFileReaderHelper
    { 

        public string ReadFileStream(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: File not found!");
                return string.Empty;
            }

            return File.ReadAllText(filePath);
        }

        public IEnumerable<string> ReadLines(string _filePath)
        {
            using var fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(fileStream, System.Text.Encoding.UTF8);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line; // Yield each line instead of reading all at once
            }
        }
    }
}
