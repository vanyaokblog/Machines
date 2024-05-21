namespace MyLib
{
    /// <summary>
    /// Класс, представляющий тип автомобиля
    /// </summary>
    public class CarType
    {
        /// <summary>
        /// Идентификатор автомобиля
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// Автомобиль
        /// </summary>
        public Car Car { get; set; }

        /// <summary>
        /// Идентификатор типа
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Тип автомобиля
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Цена автомобиля
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Скидка на автомобиль
        /// </summary>
        public double Discount { get; set; }

        /// <summary>
        /// Итоговая цена автомобиля
        /// </summary>
        public double FinalPrice { get; set; }

        /// <summary>
        /// Расчет итоговой цены автомобиля
        /// </summary>
        /// <returns>Итоговая цена.</returns>
        public double GetFinalPrice()
        {
            return Price - (Price * Discount);
        }

        /// <summary>
        /// Генерация чека для автомобиля
        /// </summary>
        /// <param name="brand">Бренд автомобиля</param>
        /// <param name="model">Модель автомобиля</param>
        /// <returns>Чек</returns>
        public string GenerateReceipt(string brand, string model)
        {
            var finalPrice = GetFinalPrice();
            return $"Автосалон «Machines»\nБренд: {brand}\nМодель: {model}\nКомплектация: {Type.Name}\nЦена со скидкой: {finalPrice}";
        }
    }
}
