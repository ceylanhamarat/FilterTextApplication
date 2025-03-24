using FilterText.Interfaces;
using FilterTextApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterTextApplication.Helpers
{
    public class ProcessorHelper : IProcessorHelper
    {
        private readonly IFileHelper _fileHelper;
        private readonly ITextHelper _textHelper;
        private readonly IFilterService _filterService;

        public ProcessorHelper(IFileHelper fileHelper, ITextHelper textHelper, IFilterService filterService)
        {
            _fileHelper = fileHelper;
            _textHelper = textHelper;
            _filterService = filterService;
        }
        public List<string> ProcessText(string filePath)
        {
            List<string> filteredWords = new List<string>();

            foreach (var line in _fileHelper.GetLineContent(filePath))
            {
                var words = _textHelper.SplitTextIntoWords(line.ToLower());
                var filterOutWords = _textHelper.FilterOutNonWordCharacters(words);
                var currentFilteredWords = _filterService.ApplyDefaultFilters(filterOutWords);
                filteredWords.AddRange(currentFilteredWords);
            }

            return filteredWords;
        }
    }
}
