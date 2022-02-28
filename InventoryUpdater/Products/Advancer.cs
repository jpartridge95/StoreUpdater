using Core.Products;

namespace InventoryUpdater.Products
{
    public interface IAdvancer
    {
        void Advance(List<IProductName> products);
    }

    public class Advancer : IAdvancer
    {
        public void Advance(List<IProductName> products)
        {
            for(int i = 0; i < products.Count; i++)
            {
                if (products[i] is INamedProduct)
                {
                    INamedProduct product = (INamedProduct)products[i];
                    product.AdvanceTime();
                    products[i] = (IProductName)product;
                }
            }
        }
    }
}
