using FilterTextApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Helpers
{
    public class FileReaderHelperTests
    {
        private readonly FileReaderHelper _fileReaderHelper;
        private readonly string _testFilePath = "testfile.txt";

        public FileReaderHelperTests()
        {
            _fileReaderHelper = new FileReaderHelper();
        } 

        [Fact]
        public void FileReaderHelper_ReadFileStream_WhenFileExists_ShoulReturns_Content()
        {
            // Arrange
            var expectedContent = "Hello, FileReaderHelper!";
            File.WriteAllText(_testFilePath, expectedContent);

            // Act
            var result = _fileReaderHelper.ReadFileStream(_testFilePath);

            // Assert
            Assert.Equal(expectedContent, result);

            // Cleanup
            File.Delete(_testFilePath);
        }

        [Fact]
        public void FileReaderHelper_ReadFileStream_WhenFileNotExists_ShoulReturns_EmptyContent()
        { 
            //Act
            var result = _fileReaderHelper.ReadFileStream("nonexistent.txt");

            // Assert
            Assert.Equal(string.Empty, result);
        }


        [Fact]
        public void FileReaderHelper_ReadLines_WhenFileExists_ShouldReturns_Lines()
        {
            // Arrange
            var lines = new List<string> { "First line", "Second line", "Third line" };
            File.WriteAllLines(_testFilePath, lines);

            // Act
            var result = _fileReaderHelper.ReadLines(_testFilePath).ToList();

            // Assert
            Assert.Equal(lines, result);

            // Cleanup
            File.Delete(_testFilePath);
        }

        [Fact]
        public void FileReaderHelper_ReadLines_WhenFileNotExists_ShouldReturns_EmptyEnumerable()
        {
            // Act
            var result = _fileReaderHelper.ReadLines("nonexistent.txt");

            // Assert
            Assert.Empty(result);
        }

    }
}
