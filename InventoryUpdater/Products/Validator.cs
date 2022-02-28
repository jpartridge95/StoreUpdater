using Core.Products;
using Core.Validate;


namespace InventoryUpdater.Products
{
    public interface IGroupValidator
    {
        void ValidateAllNumeric(List<IProductName> products);
    }

    public class Validator : IGroupValidator
    {
        INumberValidator _validator;

        public Validator(INumberValidator validator)
        {
            _validator = validator;
        }

        public void ValidateAllNumeric(List<IProductName> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i] is IProductData)
                {
                    _validator.MakeQualityInRange((IProductData)products[i]);
                }
            }
        }
    }
}
