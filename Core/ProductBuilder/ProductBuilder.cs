﻿using Core.Products;
using Core.Validate;

namespace Core.ProductBuilder
{
    public interface IProductBuilder
    {
        IProductName Build(Product product);
    }

    public class ProductBuilder : IProductBuilder
    {
        public IProductName Build(Product product)
        {
            var validator = new ProductValidator(product);

            if (!validator.IsValidName())
            {
                return new InvalidProduct("NO SUCH ITEM");
            }

            switch (product.Name)
            {
                case "Aged Brie":
                    return new AgedBrie(
                        product.Name,
                        product.SellIn,
                        product.Quality);

                case "Christmas Crackers":
                    return new ChristmasCracker(
                        product.Name,
                        product.SellIn,
                        product.Quality);

                case "Soap":
                    return new Product(
                        product.Name,
                        product.SellIn,
                        product.Quality);

                case "Frozen Item":
                    return new FrozenItem(
                        product.Name,
                        product.SellIn,
                        product.Quality);

                case "Fresh Item":
                    return new FreshItem(
                        product.Name,
                        product.SellIn,
                        product.Quality);

                default:
                    return new InvalidProduct("NO SUCH ITEM");
            }
        }
    }
}
