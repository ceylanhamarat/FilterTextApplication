using FilterText.Interfaces;
using FilterTextApplication.Helpers;
using FilterTextApplication.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Helpers
{
    public class ProcessorHelperTests
    {
        private readonly Mock<IFileHelper> _mockFileHelper;
        private readonly Mock<ITextHelper> _mockTextHelper;
        private readonly Mock<IFilterService> _mockFilterService;
        private readonly ProcessorHelper _processorHelper;

        public ProcessorHelperTests()
        {
            _mockFileHelper = new Mock<IFileHelper>();
            _mockTextHelper = new Mock<ITextHelper>();
            _mockFilterService = new Mock<IFilterService>();

            _processorHelper = new ProcessorHelper(
                _mockFileHelper.Object,
                _mockTextHelper.Object,
                _mockFilterService.Object);
        }

        [Fact]
        public void ProcessorHelper_ProcessText_ShouldReturns_FilteredWords()
        {
            // Arrange
            string filePath = "test.txt";
            var firstLine = "processor helper!";
            var secondLine = "return me filtered words.";
            var lines = new List<string> { firstLine, secondLine };
            var words1 = new string[] { "Processor", "helper" };
            var words2 = new string[] { "Return", "me", "filtered", "words" };
            var filteredWords1 = new string[] { "helper" };
            var filteredWords2 = new string[] { "words" };

            _mockFileHelper.Setup(fh => fh.GetLineContent(filePath)).Returns(lines);
            _mockTextHelper.Setup(th => th.SplitTextIntoWords(firstLine)).Returns(words1);
            _mockTextHelper.Setup(th => th.SplitTextIntoWords(secondLine)).Returns(words2);
            _mockTextHelper.Setup(th => th.FilterOutNonWordCharacters(words1)).Returns(words1);
            _mockTextHelper.Setup(th => th.FilterOutNonWordCharacters(words2)).Returns(words2);
            _mockFilterService.Setup(fs => fs.ApplyDefaultFilters(words1)).Returns(filteredWords1);
            _mockFilterService.Setup(fs => fs.ApplyDefaultFilters(words2)).Returns(filteredWords2);

            // Act
            var result = _processorHelper.ProcessText(filePath);

            // Assert
            Assert.Equal(new List<string> { "helper", "words" }, result);
        }

    }
}
