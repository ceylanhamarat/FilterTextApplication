using FilterText.Enums;
using FilterText.Interfaces;

namespace FilterText.Services
{
    public class LetterFilter : IFilter
    {
        private readonly LetterFilterType _type;
        private readonly char _letter;

        public LetterFilter(LetterFilterType type, char letter)
        {
            _type = type;
            _letter = letter;
        }

        public string[] Filter(string[] words)
        {
            return _type switch
            {
                LetterFilterType.NotContainsLetter => words.Where(w => !w.Contains(_letter)).ToArray() ,
                _ => throw new InvalidOperationException("Invalid LetterFilterType")
            };
        }
    }
}
