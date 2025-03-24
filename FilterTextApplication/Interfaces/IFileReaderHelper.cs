namespace FilterTextApplication.Interfaces
{
    public interface IFileReaderHelper
    { 
        string ReadFileStream(string filePath);
        IEnumerable<string> ReadLines(string _filePath);
    }
}
