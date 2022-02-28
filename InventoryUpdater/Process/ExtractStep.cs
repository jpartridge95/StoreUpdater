using Core.Products;
using InventoryUpdater.File;

namespace InventoryUpdater.Process
{
    public class ExtractStep : IListExtraction
    {
        private readonly IListExtraction _extractor;

        public ExtractStep(IListExtraction extractor)
        {
            _extractor = extractor;
        }

        public List<Product> Extract(List<string> data)
        {
            try
            {
                List<Product> extractedToObjects = _extractor.Extract(data);
                return extractedToObjects;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "An error has occured parsing the products" + 
                    "Please ensure Products are entered in the correct format");
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
                return null;
            }
        }
    }
}
