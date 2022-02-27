
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

    public class Product : IProductName, IProductData, IProductPrinter
    {
        public Product(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public string Print()
        {
            return String.Format("{0} {1} {2}", Name, SellIn, Quality);
        }

    }

    public class AgedBrie : Product, INamedProduct
    {
        public AgedBrie(string name, int sellIn, int quality) 
            : base(name, sellIn, quality)
        {
        }

        public void AdvanceTime()
        {
            SellIn--;
            Quality++;
        }
    }

    public class FrozenItem : Product, INamedProduct
    {
        public FrozenItem(string name, int sellIn, int quality) 
            : base(name, sellIn, quality)
        {
        }

        public void AdvanceTime()
        {
            SellIn--;

            if (SellIn < 0)
            {
                Quality -= 2;
            }
            else
            {
                Quality--;
            }
        }
    }

    public class ChristmasCracker : Product, INamedProduct
    {
        public ChristmasCracker(string name, int sellIn, int quality) 
            : base(name, sellIn, quality)
        {
        }

        public void AdvanceTime()
        {
            // increase, if sellin <= 10 inc qual by 2, <= 5 inc by 3, <= 0 == 0 
            SellIn--;

            if (SellIn < 0)
            {
                Quality = 0;
            } 
            else if (SellIn <= 5)
            {
                Quality += 3;
            }
            else if (SellIn <= 10)
            {
                Quality += 2;
            }
            else
            {
                Quality++;
            }
        }
    }

    public class FreshItem : Product, INamedProduct
    {
        public FreshItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public void AdvanceTime()
        {
            SellIn--;

            if (SellIn < 0)
            {
                Quality -= 4;
            }
            else
            {
                Quality -= 2;
            }
        }
    }
}
