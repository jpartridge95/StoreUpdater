using Core.ProductBuilder;
using Core.Products;

namespace InventoryUpdater.Products
{
    public interface ISubClassListBuilder
    {
        List<IProductName> BuildList();
    }

    public class SubClassBuilder : ISubClassListBuilder
    {
        List<Product> Products;

        public SubClassBuilder(List<Product> products)
        {
            Products = products;
        }

        public List<IProductName> BuildList()
        {
            List<IProductName> result = new List<IProductName>();

            foreach(var product in Products)
            {
                ProductBuilder builder = new ProductBuilder(product);
                result.Add(builder.Build());
            }

            return result;
        }
    }
}
