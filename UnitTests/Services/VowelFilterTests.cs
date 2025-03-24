using FilterText.Enums;
using FilterText.Services;

namespace UnitTests.Services
{
    public class VowelFilterTests
    {
        [Fact]
        public void VowelFilterType_MiddleLetterIsNotVowel_ShouldReturns_WordsWithMiddleLetterIsNotVowel()
        {
            //arrange
            var input = new string[] { "an", "elephant", "is", "an", "animal", "but", "a", "tree", "isn't" };
            var expectedOutput = new string[] { "elephant", "isn't" };

            var filter = new VowelFilter(VowelFilterType.MiddleLetterIsNotVowel);
          

            //execute???
            var result = filter.Filter(input);

            //assert
            Assert.Equal(expectedOutput.Length, result.Length);
            for (int i = 0; i < expectedOutput.Length; i++)
                Assert.Equal(expectedOutput[i], result[i]);

        }


        [Fact]
        public void VowelFilterType_MiddleLetterIsNotVowel_WhenInputIsEmpty_ShouldReturns_EmptyArray()
        {

            //arrange
            var input = Array.Empty<string>();
            var filter = new VowelFilter(VowelFilterType.MiddleLetterIsNotVowel);

            //art
            var result = filter.Filter(input);

            //assert
            Assert.Equal(0, result.Length);

        }

    }
}
