using Core.Products;


namespace Core.Validate
{
    public interface IStringValidator
    {
        bool IsValidName(IProductName product);
    }

    public class NameValidator 
        : IStringValidator
    {
        
        private readonly List<string> validNames = new List<string>()
        {
            "Aged Brie",
            "Frozen Item",
            "Fresh Item",
            "Soap",
            "Christmas Crackers"
        };

        public bool IsValidName(IProductName product)
        {
            return validNames.Contains(product.Name);
        }

    }
}
