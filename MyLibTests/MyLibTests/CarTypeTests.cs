using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace MyLib.Tests
{
    /// <summary>
    /// Класс для тестирования функционала класса CarType
    /// </summary>
    [TestClass]
    public class CarTypeTests
    {
        /// <summary>
        /// Тестирование метода GetFinalPrice класса CarType
        /// </summary>
        [TestMethod]
        public void GetFinalPrice_PriceAndDiscount_ReturnsCorrectFinalPrice()
        {
            // Создание нового объекта CarType и установка его цены и скидки
            var carType = new CarType
            {
                Price = 1000,
                Discount = 0.10
            };

            // Вычисление итоговой цены с учетом скидки
            var result = carType.GetFinalPrice();

            // Проверка, что итоговая цена соответствует ожидаемой
            Assert.AreEqual(900, result);
        }

        /// <summary>
        /// Тестирование метода GenerateReceipt класса CarType
        /// </summary>
        [TestMethod]
        public void GenerateReceipt_BrandModelAndType_ReturnsCorrectReceipt()
        {
            // Создание нового объекта CarType и установка цены, скидки и типа комплектации
            var carType = new CarType
            {
                Price = 1000,
                Discount = 0.10,
                Type = new Type { Name = "Comfort" }
            };
            string brand = "Toyota";
            string model = "Corolla";

            // Генерация чека
            var result = carType.GenerateReceipt(brand, model);

            // Проверка, что сгенерированный чек соответствует ожидаемому
            string expectedReceipt = "Автосалон «Machines»\nБренд: Toyota\nМодель: Corolla\nКомплектация: Comfort\nЦена со скидкой: 900";
            Assert.AreEqual(expectedReceipt, result);
        }
    }
}
