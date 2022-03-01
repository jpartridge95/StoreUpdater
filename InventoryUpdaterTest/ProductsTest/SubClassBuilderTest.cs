using Core.ProductBuilder;
using Core.Products;
using InventoryUpdater.Products;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace InventoryUpdaterTest.ProductsTest
{
    public class SubClassBuilderTest
    {
        Product prodOne = new Product("Frozen Item", 1, 1);
        Product prodTwo = new Product("Fresh Item", 1, 1);
        Product prodThree = new Product("Soap", 1, 1);
        Product prodFour = new Product("IntentionalTypo", 1, 1);

        List<IProductName> products;

        Mock<IProductBuilder> builder;

        public SubClassBuilderTest()
        {
            products = new List<IProductName>()
            {
                prodOne, prodTwo, prodThree, prodFour
            };

            builder = new Mock<IProductBuilder>();
            builder
                .Setup(x => x.Build(prodOne))
                .Returns(new FrozenItem("Frozen Item", 1, 1));
            builder
                .Setup(x => x.Build(prodTwo))
                .Returns(new FreshItem("Fresh Item", 1, 1));
            builder
                .Setup(x => x.Build(prodThree))
                .Returns(new Product("Soap", 1, 1));
            builder
                .Setup(x => x.Build(prodFour))
                .Returns(new InvalidProduct("Frozen Item"));
        }
        

        [Fact]
        public void BuildList_FirstItem_ShouldBe_FrozenItem()
        {
            // Arrange
            
            SubClassBuilder sut = new SubClassBuilder(builder.Object);

            // Act
            var results = sut.BuildList(products);

            // Assert
            Assert.IsType<FrozenItem>(results[0]);
        }

        [Fact]
        public void BuildList_SecondItem_ShouldBe_FreshItem()
        {
            // Arrange
            SubClassBuilder sut = new SubClassBuilder(builder.Object);

            // Act
            var results = sut.BuildList(products);

            // Assert
            Assert.IsType<FreshItem>(results[1]);
        }

        [Fact]
        public void BuildList_ThirdItem_ShouldBe_Product()
        {
            // Arrange
            SubClassBuilder sut = new SubClassBuilder(builder.Object);

            // Act
            var results = sut.BuildList(products);

            // Assert
            Assert.IsType<Product>(results[2]);
        }

        [Fact]
        public void BuildList_FourthItem_ShouldBe_InvalidProduct()
        {
            // Arrange
            SubClassBuilder sut = new SubClassBuilder(builder.Object);

            // Act
            var results = sut.BuildList(products);

            // Assert
            Assert.IsType<InvalidProduct>(results[3]);
        }

        [Fact]
        public void BuildList_ShouldReturnIProductNameList()
        {
            // Arrange
            SubClassBuilder sut = new SubClassBuilder(builder.Object);

            // Act
            var results = sut.BuildList(products);

            // Assert
            Assert.IsType<List<IProductName>>(results);
        }
    }
}
