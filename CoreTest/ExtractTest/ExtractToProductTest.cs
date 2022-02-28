using Core.Extraction;
using Core.Products;
using Xunit;
namespace CoreTest.ExtractTest
{
    public class ExtractToProductTest
    {
        [Fact]
        public void ExtractToProduct_ReturnsProduct()
        {
            // Arrange
            string product = "Aged Brie 1 1";
            Extraction extractor = new Extraction();

            // Act
            var extractedProduct = extractor.Extract(product);

            // Assert
            Assert.IsType<Product>(extractedProduct);
        }

        [Theory]
        [InlineData("Aged Brie 1 1", "Aged Brie")]
        [InlineData("Soap 1 1", "Soap")]
        [InlineData("Long Product Test 1 1", "Long Product Test")]
        public void ExtractToProduct_ReturnsNameCorrectly_WhenCorrectlyFormattedData(string product, string expected)
        {
            // Arrange
            Extraction extractor = new Extraction();

            // Act
            var extractedProduct = extractor.Extract(product);

            // Assert
            Assert.Equal(expected, extractedProduct.Name);
        }

        [Theory]
        [InlineData("Aged Brie 1 2", 1)]
        [InlineData("Soap 1 2", 1)]
        [InlineData("Long Product Test 1 2", 1)]
        public void ExtractToProduct_ReturnsSellInCorrectly_WhenCorrectlyFormatted(string product, int expected)
        {
            // Arrange
            Extraction extractor = new Extraction();

            // Act
            var extractedProduct = extractor.Extract(product);

            // Assert
            Assert.Equal(expected, extractedProduct.SellIn);
        }

        [Theory]
        [InlineData("Aged Brie 1 2", 2)]
        [InlineData("Soap 1 2", 2)]
        [InlineData("Long Product Test 1 2", 2)]
        public void ExtractToProduct_ReturnsQualityCorrectly_WhenCorrectlyFormatted(string product, int expected)
        {
            // Arrange
            Extraction extractor = new Extraction();

            // Act
            var extractedProduct = extractor.Extract(product);

            // Assert
            Assert.Equal(expected, extractedProduct.Quality);
        }

        [Fact]
        public void ExtractToProduct_ReturnsProduct_WhenNoSellInOrQuality()
        {
            // Arrange
            string product = "Invalid Data";
            Extraction extractor = new Extraction();

            // Act
            var extractedProduct = extractor.Extract(product);

            // Assert
            Assert.IsType<Product>(extractedProduct);
        }
    }
}
