using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.BAL.Common;
using PromotionEngine.BAL.Manager;
using PromotionEngine.IBAL;
using PromotionEngine.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromotionEngine.Test
{

    [TestClass]
    public class PromotionEngineTest
    {
        private IOrderValueCalculator objCalculator;

        /// <summary>
        /// Intiliaze method
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            IUnitPriceManager unitPrice = new UnitPriceManager();
            IPromotionManager promotion = new PromotionManager();
            objCalculator = new OrderValueCalculator(unitPrice, promotion);
        }

        /// <summary>
        /// This test case check scenario 1 and validate expected return value 100
        /// </summary>
        /// <returns></returns>
        [TestMethod]    
        public async Task CalculateOrder_Scenario1()
        {
            //Assemble
            int expectedOrderValue = 100;
            List<SKUOrder> orders = new List<SKUOrder>()
            {
                new SKUOrder(){Id = SKU.A,Quantity =1},
                new SKUOrder(){Id = SKU.B,Quantity =1},
                new SKUOrder(){Id = SKU.C,Quantity =1},
            };

            //Validate
            var testResult = await this.objCalculator.CalculateOrder(orders);

            //Assemble
            Assert.AreEqual(expectedOrderValue, testResult);
        }

        /// <summary>
        /// This test case check scenario 2 and validate expected return value 370
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task CalculateOrder_Scenario2()
        {
            int expectedOrderValue = 370;
            //Arrange
            List<SKUOrder> orders = new List<SKUOrder>()
            {
                new SKUOrder(){Id = SKU.A,Quantity =5},
                new SKUOrder(){Id = SKU.B,Quantity =5},
                new SKUOrder(){Id = SKU.C,Quantity =1},
            };

            //Act
            var testResult = await this.objCalculator.CalculateOrder(orders);

            //Assert
            Assert.AreEqual(expectedOrderValue, testResult);
        }

        /// <summary>
        /// This test case check scenario 3 and validate expected return value 280
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task CalculateOrder_Scenario3()
        {
            int expectedOrderValue = 280;
            //Arrange
            List<SKUOrder> orders = new List<SKUOrder>()
            {
                new SKUOrder(){Id = SKU.A,Quantity =3},
                new SKUOrder(){Id = SKU.B,Quantity =5},
                new SKUOrder(){Id = SKU.C,Quantity =1},
                new SKUOrder(){Id = SKU.D,Quantity =1},
            };

            //Act
            var testResult = await this.objCalculator.CalculateOrder(orders);

            //Assert
            Assert.AreEqual(expectedOrderValue, testResult);
        }
    }
}
