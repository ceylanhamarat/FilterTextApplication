namespace FilterTextApplication.Interfaces
{
    public interface ITextHelper
    {
        string[] SplitTextIntoWords(string text);
        string[] FilterOutNonWordCharacters(string[] text);
    }
}
