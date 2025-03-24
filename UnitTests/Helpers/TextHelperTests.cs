using FilterTextApplication.Helpers;

namespace UnitTests.Helpers
{
    public class TextHelperTests
    {
        private readonly TextHelper _textHelper;

        public TextHelperTests()
        {
            _textHelper = new TextHelper();
        }

        [Fact]
        public void FilterOutNonWordCharacters_ShouldReturn_FilterOutNonWordCharacters()
        {
            // Arrange
            var input = new[] { "hello", "123", "!@#", "world", " " };
            var expected = new[] { "hello", "123", "world" };

            // Act
            var result = _textHelper.FilterOutNonWordCharacters(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FilterOutNonWordCharacters_WhenInputIsEmpty_ShouldReturn_EmptyArray()
        {
            // Arrange
            var input = Array.Empty<string>();

            // Act
            var result = _textHelper.FilterOutNonWordCharacters(input);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SplitTextIntoWords_ShouldSplitTextIntoWords()
        {
            // Arrange
            var input = "Hello, world! This is a test.";
            var expected = new[] { "Hello", ", ", "world", "! ", "This", " ", "is", " ", "a", " ", "test", "."};

            // Act
            var result = _textHelper.SplitTextIntoWords(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SplitTextIntoWords_ShouldReturnEmptyArray_WhenInputIsEmpty()
        {
            // Arrange
            var input = string.Empty;

            // Act
            var result = _textHelper.SplitTextIntoWords(input);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SplitTextIntoWords_ShouldHandleNullInput()
        {
            // Arrange
          
            var result = _textHelper.SplitTextIntoWords(string.Empty);

            // Assert
            Assert.Empty(result);
           
            Assert.Empty(result);
        }
    }
}
