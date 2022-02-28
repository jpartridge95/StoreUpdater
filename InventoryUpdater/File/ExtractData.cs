using Core.Extraction;
using Core.Products;

namespace InventoryUpdater.File
{
    public interface IListExtraction
    {
        List<Product> Extract(List<string> data);
    }

    public class ExtractData : IListExtraction
    {
        private readonly IExtraction _extractor;

        public ExtractData(IExtraction extractor)
        {
            _extractor = extractor;
        }

        public List<Product> Extract(List<string> data)
        {
            List<Product> result = new List<Product>();

            foreach(var stringProduct in data)
            {
                result.Add(_extractor.Extract(stringProduct));
            }

            return result;
        }
    }
}
