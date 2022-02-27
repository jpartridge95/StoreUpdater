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
        public void Extract_ReturnsListOfProducts_OnHappyPath()
        {
            // Arrange
            ExtractData extractor = new(Data);

            // Act
            var results = extractor.Extract();

            // Assert
            Assert.IsType<List<Product>>(results);
        }

        
    }
}
