using Core.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validate
{
    public interface INumberValidator
    {
        void MakeQualityInRange(IProductData product);
    }

    public class NumericValidator : INumberValidator
    {

        public void MakeQualityInRange(IProductData product)
        {
            if (product.Quality > 50)
            {
                product.Quality = 50;
            }

            if (product.Quality < 0)
            {
                product.Quality = 0;
            }
        }
    }
}
