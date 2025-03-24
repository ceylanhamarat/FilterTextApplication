using System.Runtime.InteropServices.ComTypes;
using FilterText.Enums;
using FilterText.Services;

namespace UnitTests.Services
{
    public class LengthFilterTests
    {
        [Theory]
        [InlineData(3, new string[] { "elephant", "animal", "but", "tree", "isn't" })]
        [InlineData(4, new string[] { "elephant", "animal", "tree", "isn't" })]
        [InlineData(5, new string[] { "elephant", "animal", "isn't" })]
        public void LengthFilterType_GreaterThanOrEqual_ShouldReturns_WordsWithLengthGreaterThanOrEqualToInputMinLengthParameter(int minLength, string[] expectedOutput)
        {
            //arrange
            var input = new string[] { "an", "elephant", "is", "an", "animal", "but", "a", "tree", "isn't" };
            var filter = new LengthFilter(LengthFilterType.GreaterThanOrEqual, minLength);

            //art
            var result = filter.Filter(input);

            //assert
            Assert.Equal(expectedOutput.Length, result.Length);
            for (int i = 0; i < expectedOutput.Length; i++)
                Assert.Equal(expectedOutput[i], result[i]);
        }

        [Fact]
        public void LengthFilterType_GreaterThanOrEqual_WhenInputIsEmptyShouldReturns_EmptyArray(){

            //arrange
            var input = Array.Empty<string>();
            var filter = new LengthFilter(LengthFilterType.GreaterThanOrEqual, 3);

            //art
            var result = filter.Filter(input);

            //assert
            Assert.Equal(0, result.Length);
           
        }

    }
}
