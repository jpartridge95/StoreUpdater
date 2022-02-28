using Core.Products;

namespace InventoryUpdater.Products
{
    public interface IProductsPrinter
    {
        List<string> PrintProducts(List<IProductName> products);
    }

    public class MakeStringList : IProductsPrinter
    {

        public List<string> PrintProducts(List<IProductName> products)
        {
            List<string> result = new List<string>();

            foreach (IProductPrinter product in products)
            {
                result.Add(product.Print());
            }

            return result;
        }
    }
}
