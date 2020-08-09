using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.IBAL
{
    public interface IOrderValueCalculator
    {
        Task<int> CalculateOrder(List<SKUOrder> units);
    }
}
