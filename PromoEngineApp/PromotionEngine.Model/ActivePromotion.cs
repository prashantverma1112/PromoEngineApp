using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Model
{
    public class ActivePromotion
    {
        public Guid Id { get; set; }
        public IEnumerable<SKU> Unit { get; set; }
        public int Quantity { get; set; }
        public int Value { get; set; }
        public bool AllowMultiple { get; set; }
    }
}
