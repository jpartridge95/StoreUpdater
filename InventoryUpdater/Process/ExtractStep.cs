using Core.Products;
using InventoryUpdater.File;

namespace InventoryUpdater.Process
{
    public class ExtractStep
    {
        List<string> Data;

        public ExtractStep(List<string> data)
        {
            Data = data;
        }

        public List<Product> Extract()
        {
            try
            {
                IListExtraction extractor = new ExtractData(Data);
                List<Product> extractedToObjects = extractor.Extract();
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
