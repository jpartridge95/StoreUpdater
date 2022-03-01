using Core.Products;
using Xunit;
using System.Collections.Generic;
using InventoryUpdater.Products;

namespace InventoryUpdaterTest.ProductsTest
{
    public class MakeStringListTest
    {
        List<IProductName> Data = new List<IProductName>()
        {
            new InvalidProduct("NoSuchItem"),
            new Product("Soap", 1, 1),
            new ChristmasCracker("Christmas Crackers", 1, 1)
        };

        List<string> Expected = new List<string>()
        {
            "NoSuchItem",
            "Soap 1 1",
            "Christmas Crackers 1 1"
        };

        [Fact]
        public void PrintProducts_ReturnsListOfStrings_OnSuccess()
        {
            // Arrange
            MakeStringList sut = new MakeStringList();

            // Act
            var results = sut.PrintProducts(Data);

            // Assert
            Assert.IsType<List<string>>(results);
        }

        [Fact]
        public void PrintProducts_MatchesExpectedResult()
        {
            // Arrange
            MakeStringList sut = new MakeStringList();

            // Act
            var results = sut.PrintProducts(Data);

            // Assert
            Assert.Equal(Expected, results);
        }
    }
}
