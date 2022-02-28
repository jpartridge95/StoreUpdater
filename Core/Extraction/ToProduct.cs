using Core.Products;

namespace Core.Extraction
{
    public interface IExtraction
    {
        Product Extract(string product);
    }

    public class Extraction : IExtraction
    {

        public Product Extract(string product)
        {
            if (!product.Any(char.IsDigit))
            {
                return new Product(product, 1, 1);
            }

            product = product.Trim();
            string[] asArray = product.Split(" ");
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
