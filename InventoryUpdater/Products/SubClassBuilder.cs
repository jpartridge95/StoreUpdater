using Core.ProductBuilder;
using Core.Products;

namespace InventoryUpdater.Products
{
    public interface ISubClassListBuilder
    {
        List<IProductName> BuildList(List<IProductName> products);
    }

    public class SubClassBuilder : ISubClassListBuilder
    {
        private readonly IProductBuilder _builder;

        public SubClassBuilder(IProductBuilder builder)
        {
            _builder = builder;
        }

        public List<IProductName> BuildList(List<IProductName> products)
        {
            List<IProductName> result = new List<IProductName>();

            foreach(var product in products)
            {
                result.Add(_builder.Build(product));
            }

            return result;
        }
    }
}
