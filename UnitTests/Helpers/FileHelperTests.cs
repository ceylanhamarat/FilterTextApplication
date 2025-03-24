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
    public class FileHelperTests
    {
        private readonly Mock<IFileReaderHelper> _mockFileReaderHelper;
        private readonly FileHelper _fileHelper;

        public FileHelperTests()
        {
            _mockFileReaderHelper = new Mock<IFileReaderHelper>();
            _fileHelper = new FileHelper(_mockFileReaderHelper.Object);
        }

        [Fact]
        public void FileHelper_GetLineContent_ShouldReturns_ExpectedLines()
        {
            // Arrange
            string fileName = "testfile.txt";
            string filePath = FilePathHelper.GetFilePath(fileName);
            var expectedLines = new List<string> { "Line1", "Line2", "Line3" };

            _mockFileReaderHelper.Setup(fr => fr.ReadLines(filePath))
                .Returns(expectedLines);

            // Act
            var result = _fileHelper.GetLineContent(fileName);

            // Assert
            Assert.Equal(expectedLines, result); 
        } 
    }
}
