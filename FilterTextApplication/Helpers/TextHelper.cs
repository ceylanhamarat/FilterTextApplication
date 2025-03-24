using FilterTextApplication.Interfaces;
using System.Linq;
using System.Text.RegularExpressions;

namespace FilterTextApplication.Helpers
{
    public class TextHelper : ITextHelper
    {
        public string[] FilterOutNonWordCharacters(string[] text)
        {
           return  text.Where(w => Regex.IsMatch(w, "\\w+")).ToArray();
        }

        public string[] SplitTextIntoWords(string text)
        {
            var words = string.IsNullOrEmpty(text) ? Array.Empty<string>() : Regex.Split(text, "(\\W+)");
            return words.Where(w=> w.Length >0 ).ToArray();
        }
    }
}
