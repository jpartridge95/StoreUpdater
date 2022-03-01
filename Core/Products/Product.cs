using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Products
{
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
}
