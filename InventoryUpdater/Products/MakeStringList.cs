using Core.Products;

namespace InventoryUpdater.Products
{
    public class MakeStringList
    {
        List<IProductName> Products;

        public MakeStringList(List<IProductName> products)
        {
            Products = products;
        }

        public List<string> PrintProducts()
        {
            List<string> result = new List<string>();

            foreach (IProductPrinter product in Products)
            {
                result.Add(product.Print());
            }

            return result;
        }
    }
}
