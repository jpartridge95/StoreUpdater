using Core.Extraction;
using Core.Products;
using InventoryUpdater.File;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace InventoryUpdaterTest
{
    public class ExtractDataTest
    {
        private readonly List<string> Data;
        private readonly List<string> InvalidData;

        public ExtractDataTest()
        {
            Data = new List<string>()
            {
                "Good Data 1 1",
                "Frozen Food 2 2",
                "Fresh Food 24 22"
            };
            InvalidData = new List<string>()
            {
                "No qual",
                "Still",
                "Nothing"
            };
        }

        [Fact]
        public void Extract_ReturnsListOfIProductName_OnSuccess()
        {
            // Arrange
            Mock<IExtraction> mockExtractor = new Mock<IExtraction>();
            mockExtractor
                .Setup(x => x.Extract("Good Data 1 1"))
                .Returns(new Product("Good Data", 1, 1));
            mockExtractor
                .Setup(x => x.Extract("Frozen Food 2 2"))
                .Returns(new Product("Frozen Food", 2, 2));
            mockExtractor
                .Setup(x => x.Extract("Fresh Food 24 22"))
                .Returns(new Product("Fresh Food", 24, 22));
            ExtractData sut = new ExtractData(mockExtractor.Object);

            // Act
            var result = sut.Extract(Data);

            // Assert
            Assert.IsType<List<IProductName>>(result);
        }

        [Fact]
        public void Extract_ReturnsListOfIProductName_WhenDataContainsNoNumeric()
        {
            // Arrange
            Mock<IExtraction> mockExtractor = new Mock<IExtraction>();
            mockExtractor
                .Setup(x => x.Extract("No qual"))
                .Returns(new Product("No qual", 1, 1));
            mockExtractor
                .Setup(x => x.Extract("Still"))
                .Returns(new Product("Still", 1, 1));
            mockExtractor
                .Setup(x => x.Extract("Nothing"))
                .Returns(new Product("Nothing", 1, 1));
            ExtractData sut = new ExtractData(mockExtractor.Object);

            // Act
            var result = sut.Extract(InvalidData);

            // Assert
            Assert.IsType<List<IProductName>>(result);
        }
    }
}