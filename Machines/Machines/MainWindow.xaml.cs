using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using MyLib;
using ActionLogger;

namespace Machines
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logger _logger; // Логгер для записи действий пользователя
        public MainWindow()
        {
            InitializeComponent();

            // Создание нового экземпляра логгера
            _logger = new Logger();

            // Загрузка данных об автомобилях из базы данных
            LoadCars();
        }

        // Метод для загрузки данных об автомобилях из базы данных
        private void LoadCars()
        {
            // Создание нового соединения с базой данных
            using (var connection = new SqliteConnection("Data Source=machines.db"))
            {
                // Открытие соединения с базой данных
                connection.Open();

                // Создание новой команды SQL
                var command = connection.CreateCommand();
                command.CommandText = @"
                SELECT Cars.*, Brands.NameBrand, CarTypes.Price, CarTypes.Discount 
                FROM Cars 
                INNER JOIN Brands ON Cars.IdBrand = Brands.IdBrand
                INNER JOIN CarTypes ON Cars.IdCar = CarTypes.IdCar
                INNER JOIN Types ON CarTypes.IdType = Types.IdType
                WHERE Types.NameType = 'Comfort'";

                // Выполнение команды SQL и получение результатов
                using (var reader = command.ExecuteReader())
                {
                    var cars = new List<Car>();

                    while (reader.Read())
                    {
                        // Создание нового объекта Car и заполнение его данными из базы данных
                        var car = new Car
                        {
                            Id = reader.GetInt32(0),
                            BrandId = reader.GetInt32(1),
                            Model = reader.GetString(2),
                            Description = reader.GetString(3),
                            ProductionDate = DateOnly.Parse(reader.GetString(4)),
                            Image = reader.GetString(5),
                            Brand = new Brand { Name = reader.GetString(6) }
                        };
                        var carType = new CarType
                        {
                            Price = reader.GetDouble(7),
                            Discount = reader.GetDouble(8)
                        };

                        car.StartingPrice = carType.GetFinalPrice();

                        cars.Add(car); // Добавление нового автомобиля в список
                    }

                    // Установка списка автомобилей в качестве источника данных для CarList
                    CarList.ItemsSource = cars;
                }
            }
        }

        // Обработчик события выбора элемента в списке
        private void CarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получение выбранного автомобиля
            var selectedCar = (Car)CarList.SelectedItem;

            // Запись действия пользователя в лог
            _logger.LogAction($"Выбран автомобиль \"{selectedCar.Brand.Name} {selectedCar.Model}\"");

            // Создание нового окна с деталями выбранного автомобиля
            var carDetailsWindow = new CarDetailsWindow(selectedCar, selectedCar.Brand.Name, selectedCar.Model);
            carDetailsWindow.Show();
            Close();
        }
    }
}
