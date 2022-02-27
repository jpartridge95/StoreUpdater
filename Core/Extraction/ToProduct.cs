using Core.Products;

namespace Core.Extraction
{
    public interface IExtraction
    {
        Product Extract();
    }

    public class Extraction : IExtraction
    {
        private string _product;

        public Extraction(string product)
        {
            _product = product;
        }

        public Product Extract()
        {
            if (!_product.Any(char.IsDigit))
            {
                return new Product(_product, 1, 1);
            }

            _product = _product.Trim();
            string[] asArray = _product.Split(" ");
            ArraySegment<string> numericVals = 
                new ArraySegment<string>(asArray, (asArray.Length - 2), 2);
            int sellIn = Convert.ToInt32(numericVals[0]);
            int quality = Convert.ToInt32(numericVals[1]);

            ArraySegment<string> stringVals =
                new ArraySegment<string>(asArray, 0, (asArray.Length - 2));

            string name = String.Join(" ", stringVals);

            return new Product(name, sellIn, quality);
        }
    }
}
