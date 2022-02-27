using Core.Products;
using Xunit;

namespace CoreTest.ProductTest
{
    public class ProductTest
    {
        [Theory]
        [InlineData("Aged Brie", 1, 2, "Aged Brie 1 2")]
        [InlineData("Christmas Crackers", 2, 1, "Christmas Crackers 2 1")]
        [InlineData("Soap", -3, 1, "Soap -3 1")]
        [InlineData("Fresh Food", 2, 2, "Fresh Food 2 2")]
        public void Print_ReturnsCorrectString_ForValidProducts(string name, int sellIn, int quality, string expected)
        {
            // Arrange
            Product product = new Product(name, sellIn, quality);
            string printed;

            // Act
            printed = product.Print();

            // Assert
            Assert.Equal(expected, printed);
        }

        [Fact]
        public void Print_ReturnsCorrectString_ForInvalidProducts()
        {
            // Arrange
            string expected = "NO SUCH ITEM";
            InvalidProduct product = new InvalidProduct(expected);
            string printed;

            // Act
            printed = product.Print();

            // Assert
            Assert.Equal(expected, printed);
        }

        [Fact]
        public void AgedBrieAdvanceTime_IncreasesQuality()
        {
            // Arrange
            string brieName = "Aged Brie";
            int sellIn = 1;
            int quality = 1;
            AgedBrie brie = new AgedBrie(brieName, sellIn, quality);
            int expectedQuality = 2;

            // Act
            brie.AdvanceTime();

            // Assert
            Assert.Equal(expectedQuality, brie.Quality);
        }

        [Fact]
        public void AgedBrieAdvanceTime_DecreasesSellIn()
        {
            // Arrange
            string brieName = "Aged Brie";
            int sellIn = 1;
            int quality = 1;
            AgedBrie brie = new AgedBrie(brieName, sellIn, quality);
            int expectedSellIn = 0;

            // Act
            brie.AdvanceTime();

            // Assert
            Assert.Equal(expectedSellIn, brie.SellIn);
        }

        [Theory]
        [InlineData(-1, 55, -2, 53)]
        [InlineData(2, 2, 1, 1)]
        public void FrozenItemAdvanceTime_ReduceBothByOne(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            string name = "Frozen Item";
            FrozenItem frozenItem = new FrozenItem(name, sellIn, quality);

            // Act
            frozenItem.AdvanceTime();

            // Assert
            Assert.Equal(expectedQuality, frozenItem.Quality);
            Assert.Equal(expectedSellIn, frozenItem.SellIn);
        }

        [Theory]
        [InlineData(-1, 2, -2, 0)]
        [InlineData(9, 2, 8, 4)]
        [InlineData(4, 2, 3, 5)]
        public void ChristmasCrackers_AdvanceTimeCorrectly(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            string name = "Christmas Crackers";
            ChristmasCracker crackers = new ChristmasCracker(name, sellIn, quality);

            // Act
            crackers.AdvanceTime();

            // Assert
            Assert.Equal(expectedQuality, crackers.Quality);
            Assert.Equal(expectedSellIn, crackers.SellIn);
        }

        [Theory]
        [InlineData(2, 2, 1, 0)]
        [InlineData(-1, 5, -2, 1)]
        public void FreshItem_AdvanceTimeCorrectly(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            string name = "Fresh Item";
            FreshItem freshItem = new FreshItem(name, sellIn, quality);

            // Act
            freshItem.AdvanceTime();

            // Assert
            Assert.Equal(expectedSellIn, freshItem.SellIn);
            Assert.Equal(expectedQuality, freshItem.Quality);
        }
    }
}
