using Core.Products;
using Core.Validate;
using Xunit;

namespace CoreTest.ValidateTest
{
    public class ProductValidatorTest
    {
        [Theory]
        [InlineData("Aged Brie", true)]
        [InlineData("Soap", true)]
        [InlineData("Fresh Item", true)]
        [InlineData("Frozen Item", true)]
        [InlineData("Christmas Crackers", true)]
        [InlineData("Multipack Crisps", false)]
        public void IsValidName_ReturnsTrue_WhenNameValid(string name, bool expected)
        {
            // Arrange
            Product product = new Product(name, 1, 1);
            NameValidator prelimProduct = new NameValidator(product);
            bool isValid;

            // Act
            isValid = prelimProduct.IsValidName();

            // Assert
            Assert.Equal(expected, isValid);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(51, 50)]
        [InlineData(50, 50)]
        [InlineData(49, 49)]
        public void MakeQualityInRange_KeepsQualityBound(int quality, int expected)
        {
            // Arrange
            Product product = new Product("test", 1, quality);
            NumericValidator numericValidator = new NumericValidator(product);

            // Act
            numericValidator.MakeQualityInRange();

            // Assert
            Assert.Equal(expected, product.Quality);
        }
    }
}
