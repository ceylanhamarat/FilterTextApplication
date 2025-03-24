using FilterTextApplication.Interfaces;

namespace FilterTextApplication.Helpers
{
    public class FileHelper : IFileHelper
    {
        private readonly IFileReaderHelper _fileReader;

        public FileHelper(IFileReaderHelper fileReader)
        {
            _fileReader = fileReader;
        }
  
        public IEnumerable<string> GetLineContent (string fileName)
        {
            string filePath = FilePathHelper.GetFilePath(fileName);
            return _fileReader.ReadLines(filePath);
        }
    }
}
