
namespace Core.Products
{
    public interface IProductName
    {
        string Name { get; set; }
    }

    public interface IProductPrinter
    {
        string Print();
    }

    public interface IProductData
    {
        int SellIn { get; set; }
        int Quality { get; set; }
    }

    public interface INamedProduct
    {
        void AdvanceTime();
    }

    public class InvalidProduct : IProductName, IProductPrinter
    {
        public InvalidProduct(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string Print()
        {
            return Name;
        }
    }
}
