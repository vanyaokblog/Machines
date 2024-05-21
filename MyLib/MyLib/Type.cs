namespace MyLib
{
    /// <summary>
    /// Класс, представляющий тип автомобиля
    /// </summary>
    public class Type
    {
        /// <summary>
        /// Уникальный идентификатор типа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название типа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание типа
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Список типов автомобиля
        /// </summary>
        public List<CarType> CarTypes { get; set; }
    }
}
