using PromotionEngine.IBAL;
using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.BAL.Manager
{
    public class PromotionManager : IPromotionManager
    {
        public async Task<IEnumerable<ActivePromotion>> GetPromotions()
        {
            return new List<ActivePromotion>()
            {
                new ActivePromotion(){Id= Guid.NewGuid(),Unit = new List<SKU>{ SKU.A },Quantity =3, Value= 130,AllowMultiple = false },
                new ActivePromotion(){Id= Guid.NewGuid(),Unit = new List<SKU>{ SKU.B },Quantity =2, Value= 45,AllowMultiple = false},
                new ActivePromotion(){Id= Guid.NewGuid(),Unit = new List<SKU>{ SKU.C,SKU.D },Quantity =0, Value= 30,AllowMultiple = true }
            };
        }
    }
}
