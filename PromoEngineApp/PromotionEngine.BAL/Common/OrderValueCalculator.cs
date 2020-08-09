using PromotionEngine.IBAL;
using PromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine.BAL;
using PromotionEngine.BAL.Helper;
namespace PromotionEngine.BAL.Common
{
    public class OrderValueCalculator : IOrderValueCalculator
    {
        private readonly IUnitPriceManager unitpriceManager;
        private readonly IPromotionManager promotionManager;
        public OrderValueCalculator(IUnitPriceManager unitPriceManager, IPromotionManager promotionManager)
        {
            this.unitpriceManager = unitPriceManager;
            this.promotionManager = promotionManager;
        }

        /// <summary>
        /// Calculate Order value
        /// </summary>
        /// <param name="units">order units</param>
        /// <returns>Total value of order</returns>
        public async Task<int> CalculateOrder(List<SKUOrder> units)
        {
            var unitPrices = await this.unitpriceManager.GetUnitPrices();
            var promotions = await this.promotionManager.GetPromotions();

            int orderValue = 0;

            var lstSKU = new List<SKU>() { SKU.A, SKU.B };
            var objABIds = units.Where(c => lstSKU.Contains(c.Id)).ToList();

            objABIds.ForEach(unitOrder =>
            {
                var unitprice = unitPrices.FirstOrDefault(c => c.Name == unitOrder.Id).Value;
                var promotion = promotions.FirstOrDefault(c => !c.AllowMultiple && c.Unit.Contains(unitOrder.Id));
                orderValue += this.ApplyPromotion(unitOrder, unitprice, promotion);
            });

            var objCDIds = units.Except(objABIds).ToList();

            if (objCDIds.Count == 2)
            {
                orderValue += promotions.FirstOrDefault(c => c.AllowMultiple).Value;
            }
            else
            {
                objCDIds.ForEach(unitOrder =>
                {
                    var unitprice = unitPrices.FirstOrDefault(c => c.Name == unitOrder.Id).Value;
                    orderValue += unitOrder.Quantity * unitprice;
                });
            }

            return orderValue;
        }

        /// <summary>
        /// Calucate Order value with applying promotion
        /// </summary>
        /// <param name="order"></param>
        /// <param name="defaultPriceValue"></param>
        /// <param name="promotion"></param>
        /// <returns></returns>
        private int ApplyPromotion(SKUOrder order, int defaultPriceValue, ActivePromotion promotion)
        {
            return order.Calculate(defaultPriceValue, promotion);
        }
    }
}
