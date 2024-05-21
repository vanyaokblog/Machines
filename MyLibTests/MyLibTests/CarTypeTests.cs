using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace MyLib.Tests
{
    /// <summary>
    /// ����� ��� ������������ ����������� ������ CarType
    /// </summary>
    [TestClass]
    public class CarTypeTests
    {
        /// <summary>
        /// ������������ ������ GetFinalPrice ������ CarType
        /// </summary>
        [TestMethod]
        public void GetFinalPrice_PriceAndDiscount_ReturnsCorrectFinalPrice()
        {
            // �������� ������ ������� CarType � ��������� ��� ���� � ������
            var carType = new CarType
            {
                Price = 1000,
                Discount = 0.10
            };

            // ���������� �������� ���� � ������ ������
            var result = carType.GetFinalPrice();

            // ��������, ��� �������� ���� ������������� ���������
            Assert.AreEqual(900, result);
        }

        /// <summary>
        /// ������������ ������ GenerateReceipt ������ CarType
        /// </summary>
        [TestMethod]
        public void GenerateReceipt_BrandModelAndType_ReturnsCorrectReceipt()
        {
            // �������� ������ ������� CarType � ��������� ����, ������ � ���� ������������
            var carType = new CarType
            {
                Price = 1000,
                Discount = 0.10,
                Type = new Type { Name = "Comfort" }
            };
            string brand = "Toyota";
            string model = "Corolla";

            // ��������� ����
            var result = carType.GenerateReceipt(brand, model);

            // ��������, ��� ��������������� ��� ������������� ����������
            string expectedReceipt = "��������� �Machines�\n�����: Toyota\n������: Corolla\n������������: Comfort\n���� �� �������: 900";
            Assert.AreEqual(expectedReceipt, result);
        }
    }
}
