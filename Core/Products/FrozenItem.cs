using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Products
{
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
}
