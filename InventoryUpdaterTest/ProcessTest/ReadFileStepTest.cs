using Core.IO;
using InventoryUpdater.Process;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace InventoryUpdaterTest.ProcessTest
{
    public class ReadFileStepTest
    {
        [Fact]
        public void ReadData_ReturnsListOfStrings_OnSuccessfulRead()
        {
            // Arrange
            List<string> mockData = new List<string>()
            {
                "brie 1 1",
                "cheese 1 1",
                "not cheese 1 1"
            };

            Mock<IReader> reader = new Mock<IReader>();
            reader
                .Setup(x => x.ReadData())
                .Returns(mockData);

            ReadFileStep sut = new ReadFileStep(reader.Object);

            // Act
            var result = sut.ReadFile();

            // Assert
            Assert.Equal(mockData, result);
        }
    }
}
