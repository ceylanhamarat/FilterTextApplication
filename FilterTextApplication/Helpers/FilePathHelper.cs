namespace FilterTextApplication.Helpers
{
    public static class FilePathHelper
    {
        public static string GetFilePath(string fileName)
        {
            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            
            return Path.Combine(solutionDirectory, "TextFiles", fileName);
        }
    }
}
