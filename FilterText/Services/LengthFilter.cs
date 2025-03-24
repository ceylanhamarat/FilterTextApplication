using FilterText.Enums;
using FilterText.Interfaces;

namespace FilterText.Services
{
    public class LengthFilter : IFilter 
    {
        private readonly int _lenght;
        private readonly LengthFilterType _type;

        public LengthFilter(LengthFilterType type, int threshold)
        {
            _lenght = threshold;
            _type = type;
        }
        public string[] Filter(string[] words)
        {
            return _type switch
            {
                LengthFilterType.GreaterThanOrEqual => words.Where(word => word.Length >= _lenght).ToArray(), 
                _ => words
            };
        }
    }
}
