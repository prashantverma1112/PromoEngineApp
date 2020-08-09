using PromotionEngine.Model;

namespace PromotionEngine.BAL.Helper
{
    public static class CalculateOrder
    {
        /// <summary>
        /// To calcuate order with promotion applied on it
        /// </summary>
        /// <param name="order"></param>
        /// <param name="defaultValue"></param>
        /// <param name="promo"></param>
        /// <returns></returns>
        public static int Calculate(this SKUOrder order, int defaultValue, ActivePromotion promo)
        {
            int applyPromotionQuantity = 0;
            if (order.Quantity >= promo.Quantity)
            {
                applyPromotionQuantity = order.Quantity / promo.Quantity;
            }

            if (applyPromotionQuantity != 0)
                return (applyPromotionQuantity * promo.Value) + (order.Quantity - (promo.Quantity * applyPromotionQuantity)) * defaultValue;

            return order.Quantity * defaultValue;
        }
    }
}
