using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Products
{
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
}
