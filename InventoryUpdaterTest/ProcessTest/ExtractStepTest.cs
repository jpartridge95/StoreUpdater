using Core.Extraction;
using Core.Products;
using InventoryUpdater.File;
using InventoryUpdater.Process;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace InventoryUpdaterTest
{
    public class ExtractStepTest
    {
        List<string> Data = new List<string>()
        {
            "Brie 1 1",
            "Food 1 1",
            "Bread 1 1"
        };

        [Fact]
        public void Extract_ReturnsListOfIProductName_OnHappyPath()
        {
            // Arrange
            Mock<IExtraction> mock = new Mock<IExtraction>();
            mock
                .Setup(x => x.Extract("Brie 1 1"))
                .Returns(new Product("Brie", 1, 1));
            mock
                .Setup(x => x.Extract("Food 1 1"))
                .Returns(new Product("Food", 1, 1));
            mock
                .Setup(x => x.Extract("Bread 1 1"))
                .Returns(new Product("Bread", 1, 1));
            ExtractData extractor = new(mock.Object);

            // Act
            var results = extractor.Extract(Data);

            // Assert
            Assert.IsType<List<IProductName>>(results);
        }

        
    }
}
