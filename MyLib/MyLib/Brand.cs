namespace MyLib
{
    /// <summary>
    /// Класс, представляющий бренд автомобиля
    /// </summary>
    public class Brand
    {
        /// <summary>
        /// Уникальный идентификатор бренда
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название бренда
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список автомобилей этого бренда
        /// </summary>
        public List<Car> Cars { get; set; }
    }
}
