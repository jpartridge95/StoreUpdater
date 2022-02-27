using Core.Products;
using InventoryUpdater.Products;
using System.Collections.Generic;
using Xunit;

namespace InventoryUpdaterTest.ProductsTest
{
    public class AdvancerTest
    {
        List<IProductName> Data = new List<IProductName>()
        {
            new AgedBrie("Aged Brie", 1, 1),
            new Product("Soap", 5, 5),
            new InvalidProduct("NO SUCH ITEM")
        };

        [Theory]
        [InlineData(0, 2)]
        [InlineData(1, 5)]
        public void Advance_AdvancesAppropriately_ForSubclass(int index, int expected)
        {
            // Arrange
            Advancer sut = new Advancer(Data);
            IProductData target = (IProductData)Data[index]; 

            // Act
            sut.Advance();

            // Assert
            Assert.Equal(expected, target.Quality);
        }
    }
}
