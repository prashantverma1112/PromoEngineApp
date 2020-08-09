using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Model
{
    public class UnitPrice
    {
        public Guid Id { get; set; }
        public SKU Name { get; set; }
        public int Value { get; set; }
    }
}
