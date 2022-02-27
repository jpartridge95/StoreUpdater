using Core.Products;
using InventoryUpdater.Products;
using System;
using System.Collections.Generic;
using Xunit;

namespace InventoryUpdaterTest.ProductsTest
{
    public class SubClassBuilderTest
    {
        List<Product> Data = new List<Product>()
        {
            new Product("Frozen Item", 1, 1),
            new Product("Fresh Item", 1, 1),
            new Product("Soap", 1, 1),
            new Product("IntentionalTypo", 1, 1)
        };

        [Fact]
        public void BuildList_FirstItem_ShouldBe_FrozenItem()
        {
            // Arrange
            SubClassBuilder sut = new SubClassBuilder(Data);

            // Act
            var results = sut.BuildList();

            // Assert
            Assert.IsType<FrozenItem>(results[0]);
        }

        [Fact]
        public void BuildList_SecondItem_ShouldBe_FreshItem()
        {
            // Arrange
            SubClassBuilder sut = new SubClassBuilder(Data);

            // Act
            var results = sut.BuildList();

            // Assert
            Assert.IsType<FreshItem>(results[1]);
        }

        [Fact]
        public void BuildList_ThirdItem_ShouldBe_Product()
        {
            // Arrange
            SubClassBuilder sut = new SubClassBuilder(Data);

            // Act
            var results = sut.BuildList();

            // Assert
            Assert.IsType<Product>(results[2]);
        }

        [Fact]
        public void BuildList_FourthItem_ShouldBe_InvalidProduct()
        {
            // Arrange
            SubClassBuilder sut = new SubClassBuilder(Data);

            // Act
            var results = sut.BuildList();

            // Assert
            Assert.IsType<InvalidProduct>(results[3]);
        }

        [Fact]
        public void BuildList_ShouldReturnIProductNameList()
        {
            // Arrange
            SubClassBuilder sut = new SubClassBuilder(Data);

            // Act
            var results = sut.BuildList();

            // Assert
            Assert.IsType<List<IProductName>>(results);
        }
    }
}
