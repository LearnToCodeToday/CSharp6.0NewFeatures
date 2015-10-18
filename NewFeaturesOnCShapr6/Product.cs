using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesOnCShapr6
{
    public class Product
    {
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public Guid ParentProductCategoryId { get; } = Guid.NewGuid();

        public string DisplayProduct() => $"{this.ProductId} { this.ParentProductCategoryId}";

        public string ProductInfo => $"{this.ProductId} { this.ParentProductCategoryId}";
    }
}
