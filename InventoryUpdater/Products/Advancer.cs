using Core.Products;

namespace InventoryUpdater.Products
{
    public class Advancer
    {
        private List<IProductName> Products;

        public Advancer(List<IProductName> products)
        {
            Products = products;
        }

        public void Advance()
        {
            for(int i = 0; i < Products.Count; i++)
            {
                if (Products[i] is INamedProduct)
                {
                    INamedProduct product = (INamedProduct)Products[i];
                    product.AdvanceTime();
                    Products[i] = (IProductName)product;
                }
            }
        }
    }
}
