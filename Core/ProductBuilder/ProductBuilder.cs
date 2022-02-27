using Core.Products;
using Core.Validate;

namespace Core.ProductBuilder
{
    public interface IProductBuilder
    {
        IProductName Build();
    }

    public class ProductBuilder : IProductBuilder
    {
        public ProductBuilder(Product product)
        {
            _product = product;
        }

        Product _product;

        public IProductName Build()
        {
            var validator = new ProductValidator(_product);

            if (!validator.IsValidName())
            {
                return new InvalidProduct("NO SUCH ITEM");
            }

            switch (_product.Name)
            {
                case "Aged Brie":
                    return new AgedBrie(
                        _product.Name,
                        _product.SellIn,
                        _product.Quality);

                case "Christmas Crackers":
                    return new ChristmasCracker(
                        _product.Name,
                        _product.SellIn,
                        _product.Quality);

                case "Soap":
                    return new Product(
                        _product.Name,
                        _product.SellIn,
                        _product.Quality);

                case "Frozen Item":
                    return new FrozenItem(
                        _product.Name,
                        _product.SellIn,
                        _product.Quality);

                case "Fresh Item":
                    return new FreshItem(
                        _product.Name,
                        _product.SellIn,
                        _product.Quality);

                default:
                    return new InvalidProduct("NO SUCH ITEM");
            }
        }
    }
}
