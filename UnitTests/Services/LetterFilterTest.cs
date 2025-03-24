using FilterText.Enums;
using FilterText.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Services
{
    public class LetterFilterTests
    {
        [Theory]
        [InlineData('p', new string[] { "an", "is", "an", "animal", "but", "a", "tree", "isn't" })]
        [InlineData('a', new string[] { "is", "but", "tree", "isn't" })]
        [InlineData('\'', new string[] { "an", "elephant", "is", "an", "animal", "but", "a", "tree" })]
        public void LetterFilterType_NotContainsLetter_ShouldReturns_WordsDontContainInputCharCharacter(char excludeWordsWithCharacter, string[] expectedoutput)
        {
            //arrange
            var input = new string[] { "an", "elephant", "is", "an", "animal", "but", "a", "tree", "isn't" };

            //execute???
            var filter = new LetterFilter(LetterFilterType.NotContainsLetter, excludeWordsWithCharacter);
            var result = filter.Filter(input);
            //assert
            Assert.Equal(expectedoutput.Length, result.Length);
            for (int i = 0; i < expectedoutput.Length; i++)
                Assert.Equal(expectedoutput[i], result[i]);
        }



        [Fact]
        public void LetterFilterType_NotContainsLetter_WhenInputIsEmpty_ShouldReturns_EmptyArray()
        {

            //arrange
            var input = Array.Empty<string>();
            var filter = new LetterFilter(LetterFilterType.NotContainsLetter,'h');

            //art
            var result = filter.Filter(input);

            //assert
            Assert.Equal(0, result.Length);

        }
    }
}
