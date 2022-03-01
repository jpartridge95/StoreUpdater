using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Products
{
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
