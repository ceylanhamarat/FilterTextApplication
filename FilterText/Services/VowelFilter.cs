using FilterText.Enums;
using FilterText.Interfaces;

namespace FilterText.Services
{
    public class VowelFilter : IFilter
    {
        private readonly VowelFilterType _type;

        public VowelFilter(VowelFilterType type)
        {
            _type = type;
        }

        public string[] Filter(string[] words)
        {
            return _type switch
            {
                VowelFilterType.MiddleLetterIsNotVowel => words.Where(w => !IsMiddleLetterVowel(w)).ToArray(),
                _ => throw new InvalidOperationException("Invalid VowelFilterType")
            };
        }

        private bool IsMiddleLetterVowel(string word)
        {
            if (word.Length == 0) return false;

            if (string.IsNullOrEmpty(word)) return false;

          
            int len = word.Length;

            if (len % 2 == 1)
            {
                return "aeiouAEIOU".Contains(word[len / 2]);
            }
            else
            {
                return ("aeiouAEIOU".Contains(word[len / 2 - 1]) || "aeiouAEIOU".Contains(word[len / 2]));
            }
        }
    }

}
