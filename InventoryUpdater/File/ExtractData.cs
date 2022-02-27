using Core.Extraction;
using Core.Products;

namespace InventoryUpdater.File
{
    public interface IListExtraction
    {
        List<Product> Extract();
    }

    public class ExtractData : IListExtraction
    {
        private List<string> Data;

        public ExtractData(List<String> data)
        {
            Data = data;
        }

        public List<Product> Extract()
        {
            List<Product> result = new List<Product>();

            foreach(var stringProduct in Data)
            {
                Extraction extractor = new Extraction(stringProduct);
                result.Add(extractor.Extract());
            }

            return result;
        }
    }
}
