using Core.Extraction;
using Core.Products;

namespace InventoryUpdater.File
{
    public interface IListExtraction
    {
        List<IProductName> Extract(List<string> data);
    }

    public class ExtractData : IListExtraction
    {
        private readonly IExtraction _extractor;

        public ExtractData(IExtraction extractor)
        {
            _extractor = extractor;
        }

        public List<IProductName> Extract(List<string> data)
        {
            List<IProductName> result = new List<IProductName>();

            foreach(var stringProduct in data)
            {
                result.Add(_extractor.Extract(stringProduct));
            }

            return result;
        }
    }
}
