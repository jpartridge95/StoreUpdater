using Core.Products;
using Core.Validate;

namespace Core.ProductBuilder
{
    public interface IProductBuilder
    {
        IProductName Build(IProductName product);
    }

    public class ProductBuilder : IProductBuilder
    {
        private readonly IStringValidator _validator;

        public ProductBuilder(IStringValidator validator)
        {
            _validator = validator;
        }

        public IProductName Build(IProductName product)
        {
            if (!_validator.IsValidName(product))
            {
                return new InvalidProduct("NO SUCH ITEM");
            }

            switch (product.Name)
            {
                case "Aged Brie":
                    return new AgedBrie(
                        ((Product)product).Name,
                        ((Product)product).SellIn,
                        ((Product)product).Quality);

                case "Christmas Crackers":
                    return new ChristmasCracker(
                        ((Product)product).Name,
                        ((Product)product).SellIn,
                        ((Product)product).Quality);

                case "Soap":
                    return new Product(
                        ((Product)product).Name,
                        ((Product)product).SellIn,
                        ((Product)product).Quality);

                case "Frozen Item":
                    return new FrozenItem(
                        ((Product)product).Name,
                        ((Product)product).SellIn,
                        ((Product)product).Quality);

                case "Fresh Item":
                    return new FreshItem(
                        ((Product)product).Name,
                        ((Product)product).SellIn,
                        ((Product)product).Quality);

                default:
                    return new InvalidProduct("NO SUCH ITEM");
            }
        }
    }
}
