using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.Sqlite;
using MyLib;
using ActionLogger;

namespace Machines
{
    /// <summary>
    /// Логика взаимодействия для CarDetailsWindow.xaml
    /// </summary>
    public partial class CarDetailsWindow : Window
    {
        private Car _car; // Выбранный автомобиль
        private Logger _logger; // Логгер для записи действий пользователя

        public CarDetailsWindow(Car car, string brand, string model)
        {
            InitializeComponent();

            // Сохранение выбранного автомобиля
            _car = car;

            // Создание нового экземпляра логгера
            _logger = new Logger();

            // Установка марки и модели автомобиля
            BrandCarLabel.Text = brand;
            ModelCarLabel.Text = model;

            // Загрузка деталей автомобиля
            LoadCarDetails();
        }

        // Метод для загрузки деталей автомобиля из базы данных
        private void LoadCarDetails()
        {
            // Создание нового соединения с базой данных
            using (var connection = new SqliteConnection("Data Source=machines.db"))
            {
                connection.Open(); // Открытие соединения с базой данных

                // Создание новой команды SQL
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT CarTypes.*,Types.NameType, Types.DescriptionType FROM CarTypes INNER JOIN Types ON CarTypes.IdType = Types.IdType WHERE IdCar = {_car.Id}";

                // Выполнение команды SQL и получение результатов
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Создание нового объекта CarType и заполнение его данными из базы данных
                        var carType = new CarType
                        {
                            CarId = reader.GetInt32(0),
                            TypeId = reader.GetInt32(1),
                            Price = reader.GetDouble(2),
                            Discount = reader.GetDouble(3),
                            Type = new Type { Name = reader.GetString(4), Description = reader.GetString(5) }
                        };

                        carType.FinalPrice = carType.GetFinalPrice(); // Расчет итоговой цены

                        CarDetailsList.Items.Add(carType); // Добавление в список
                    }
                }
            }
        }

        // Обработчик события выбора элемента в списке
        private void CarDetailsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получение выбранного типа автомобиля
            var selectedCarType = (CarType)CarDetailsList.SelectedItem;

            // Формируем чек
            var receipt = selectedCarType.GenerateReceipt(_car.Brand.Name, _car.Model);

            // Запись действия пользователя в лог
            _logger.LogAction($"Выбрана комплектация \"{selectedCarType.Type.Name}\" для автомобиля \"{_car.Brand.Name} {_car.Model}\". Сформирован чек.");

            // Открываем ReceiptWindow и показываем чек
            var receiptWindow = new ReceiptWindow();
            receiptWindow.ShowReceipt(receipt);
            receiptWindow.Show();
        }

        // Обработчик события нажатия на кнопку "Назад"
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _logger.LogAction("Нажата кнопка \"На главную страницу\"");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
