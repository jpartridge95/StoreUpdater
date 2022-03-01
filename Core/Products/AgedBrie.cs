using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Products
{
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
}
