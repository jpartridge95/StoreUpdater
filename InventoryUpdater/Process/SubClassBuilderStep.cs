using Core.Products;
using InventoryUpdater.Products;

namespace InventoryUpdater.Process
{
    public class SubClassBuilderStep : ISubClassListBuilder
    {
        ISubClassListBuilder _builder;

        public SubClassBuilderStep(ISubClassListBuilder builder)
        {
            _builder = builder;
        }

        public List<IProductName> BuildList(List<Product> products)
        {
            try
            {
                var subClassList = _builder.BuildList(products);
                return subClassList;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "An internal error has occurred contact support for help");
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
                return null;
            }
        }
    }
}
