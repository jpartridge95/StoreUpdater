using Core.ProductBuilder;
using Core.Products;
using Core.Validate;
using Xunit;

namespace CoreTest.ProductBuilderTest
{
    public class ProductBuilderTest
    {
        [Fact]
        public void Build_ReturnsProductType_OnBadInput()
        {
            // Arrange

            string badInput = "Not A Product";
            Product prelimProduct = new Product(badInput, 1, 1);
            ProductBuilder builder = new ProductBuilder(prelimProduct);

            // Act
            IProductName product = builder.Build();

            // Assert
            Assert.IsType<InvalidProduct>(product);
        }

        [Fact]
        public void Build_ReturnsValidProduct_OnSoapIn()
        {
            // Arrange
            string soap = "Soap";
            Product prelimProduct = new Product(soap, 1, 1);
            ProductBuilder builder = new ProductBuilder(prelimProduct);

            // Act
            IProductName product = builder.Build();

            // Assert
            Assert.IsType<Product>(product);
        }

        [Fact]
        public void Build_ReturnsFreshItem_OnFreshItemIn()
        {
            // Arrange
            string freshItem = "Fresh Item";
            Product prelimProduct = new Product(freshItem, 1, 1);
            ProductBuilder builder = new ProductBuilder(prelimProduct);

            // Act
            IProductName product = builder.Build();

            // Assert
            Assert.IsType<FreshItem>(product);
        }

        [Fact]
        public void Build_ReturnsFrozenItem_OnFrozenItemIn()
        {
            // Arrange
            string frozenItem = "Frozen Item";
            Product prelimProduct = new Product(frozenItem, 1, 1);
            ProductBuilder builder = new ProductBuilder(prelimProduct);

            // Act
            IProductName product = builder.Build();

            // Assert
            Assert.IsType<FrozenItem>(product);
        }

        [Fact]
        public void Build_ReturnsAgedBrie_OnAgedBrie()
        {
            // Arrange
            string agedBrie = "Aged Brie";
            Product prelimProduct = new Product(agedBrie, 1, 1);
            ProductBuilder builder = new ProductBuilder(prelimProduct);

            // Act
            IProductName product = builder.Build();

            // Assert
            Assert.IsType<AgedBrie>(product);
        }

        [Fact]
        public void Build_ReturnsChristmasCracker_OnChristmasCrackers()
        {
            // Arrange
            string crackers = "Christmas Crackers";
            Product prelimProduct = new Product(crackers, 1, 1);
            ProductBuilder builder = new ProductBuilder(prelimProduct);

            // Act
            IProductName product = builder.Build();

            // Assert
            Assert.IsType<ChristmasCracker>(product);
        }
    }
}
