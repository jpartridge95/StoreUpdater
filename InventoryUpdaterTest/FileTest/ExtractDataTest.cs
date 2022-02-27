using Core.Products;
using InventoryUpdater.File;
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
        public void Extract_ReturnsListOfProducts_OnSuccess()
        {
            // Arrange
            ExtractData sut = new ExtractData(Data);

            // Act
            var result = sut.Extract();

            // Assert
            Assert.IsType<List<Product>>(result);
        }

        [Fact]
        public void Extract_ReturnsListOfProducts_WhenDataContainsNoNumeric()
        {
            // Arrange
            ExtractData sut = new ExtractData(InvalidData);

            // Act
            var result = sut.Extract();

            // Assert
            Assert.IsType<List<Product>>(result);
        }
    }
}