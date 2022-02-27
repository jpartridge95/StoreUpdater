using Core.Products;
using InventoryUpdater.Process;
using InventoryUpdater.Products;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace InventoryUpdaterTest.ProcessTest
{
    public class SubClassBuilderStepTest
    {
        List<IProductName> Data = new List<IProductName>()
        {
            new AgedBrie("Aged Brie", 1, 1),
            new FrozenItem("Frozen Item", 1, 1),
            new InvalidProduct("Typo Item")
        };

        [Fact]
        public void BuildList_ReturnsListIProductName_OnSuccess()
        {
            // Arrange
            Mock<ISubClassListBuilder> builder = new Mock<ISubClassListBuilder>();
            builder.Setup(x => x.BuildList())
                .Returns(Data);

            SubClassBuilderStep sut = new SubClassBuilderStep(builder.Object);

            // Act
            var results = sut.BuildList();

            // Assert
            Assert.IsType<List<IProductName>>(results);
        }
    }
}
