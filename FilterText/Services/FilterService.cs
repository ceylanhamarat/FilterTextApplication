using FilterText.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FilterText.Services
{
    public class FilterService : IFilterService
    {
        private readonly IServiceProvider _serviceProvider;

        public FilterService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public string[] ApplyDefaultFilters(string[] words)
        {
            var vowelFilter = _serviceProvider.GetRequiredService<VowelFilter>();
            var letterFilter = _serviceProvider.GetRequiredService<LetterFilter>();
            var lengthFilter = _serviceProvider.GetRequiredService<LengthFilter>();

            words = lengthFilter.Filter(words);
            words = letterFilter.Filter(words);
            words = vowelFilter.Filter(words);

            return words;
        } 
    }
}
