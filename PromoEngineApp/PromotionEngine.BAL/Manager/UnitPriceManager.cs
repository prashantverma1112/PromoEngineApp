﻿using PromotionEngine.IBAL;
using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.BAL.Manager
{
    public class UnitPriceManager : IUnitPriceManager
    {
        public async Task<IEnumerable<UnitPrice>> GetUnitPrices()
        {
            return new List<UnitPrice>()
            {
                new UnitPrice(){Id= Guid.NewGuid(),Name = SKU.A,Value= 50 },
                new UnitPrice(){Id= Guid.NewGuid(),Name = SKU.B,Value= 30 },
                new UnitPrice(){Id= Guid.NewGuid(),Name = SKU.C,Value= 20 },
                new UnitPrice(){Id= Guid.NewGuid(),Name = SKU.C,Value= 15 }
            };
        }
    }
}
