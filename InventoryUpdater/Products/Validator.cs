using Core.Products;
using Core.Validate;


namespace InventoryUpdater.Products
{
    public class Validator
    {
        List<IProductName> Products;

        public Validator(List<IProductName> products)
        {
            Products = products;
        }

        public void ValidateAllNumeric()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i] is IProductData)
                {
                    NumericValidator validator 
                        = new NumericValidator((IProductData)Products[i]);
                    validator.MakeQualityInRange();
                }
            }
        }
    }
}
