namespace MyLib
{
    /// <summary>
    /// Класс, представляющий автомобиль
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Уникальный идентификатор автомобиля
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор бренда автомобиля
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Бренд автомобиля
        /// </summary>
        public Brand Brand { get; set; }

        /// <summary>
        /// Модель автомобиля
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Описание автомобиля
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата производства автомобиля
        /// </summary>
        public DateOnly ProductionDate { get; set; }

        /// <summary>
        /// Изображение автомобиля
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Начальная цена автомобиля
        /// </summary>
        public double StartingPrice { get; set; }

        /// <summary>
        /// Список типов автомобиля
        /// </summary>
        public List<CarType> CarTypes { get; set; }
    }
}
