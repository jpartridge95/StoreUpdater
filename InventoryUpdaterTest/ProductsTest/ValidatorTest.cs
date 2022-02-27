using Core.Products;
using InventoryUpdater.Products;
using System.Collections.Generic;
using Xunit;

namespace InventoryUpdaterTest.ProductsTest
{
    public class ValidatorTest
    {
        List<IProductName> Data = new List<IProductName>()
        {
            new Product("Soap", 1, 51),
            new Product("Soap", 1, -1),
            new Product("Soap", 1, 22),
        };

        [Theory]
        [InlineData(0, 50)]
        [InlineData(1, 0)]
        [InlineData(2, 22)]
        public void Validator_BringsQuality_WithinBusinessParams(int index, int expected)
        {
            // Arrange
            Validator sut = new Validator(Data);
            IProductData target = (IProductData)Data[index];

            // Act
            sut.ValidateAllNumeric();

            // Assert
            Assert.Equal(expected, target.Quality);
        }

    }
}
