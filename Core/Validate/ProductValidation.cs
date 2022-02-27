using Core.Products;


namespace Core.Validate
{
    public interface IStringValidator
    {
        bool IsValidName();
    }

    public interface INumericValidator
    {
        bool IsQualityZeroOrHigher();
        bool IsQualityFiftyOrLower();
    }

    public interface IValidateNumbers
    {
        void MakeQualityInRange();
    }

    public class ProductValidator 
        : IStringValidator
    {
        public ProductValidator(IProductName product)
        {
            Product = product;
        }

        private IProductName Product;
        
        private readonly List<string> validNames = new List<string>()
        {
            "Aged Brie",
            "Frozen Item",
            "Fresh Item",
            "Soap",
            "Christmas Crackers"
        };

        public bool IsValidName()
        {
            return validNames.Contains(Product.Name);
        }

    }

    public class NumericValidator : IValidateNumbers
    {
        
        private IProductData Product;

        public NumericValidator(IProductData product)
        {
            Product = product;
        }

        public void MakeQualityInRange()
        {
            if (Product.Quality > 50)
            {
                Product.Quality = 50;
            }

            if (Product.Quality < 0)
            {
                Product.Quality = 0;
            }
        }
    }
}
