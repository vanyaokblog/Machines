using System;
using System.IO;

namespace ActionLogger
{
    /// <summary>
    /// Класс Logger предназначен для логирования действий
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Путь к файлу лога
        /// </summary>
        private string _logFilePath;

        /// <summary>
        /// Конструктор класса Logger. Создает файл лога в папке Debug
        /// </summary>
        public Logger()
        {
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        }

        /// <summary>
        /// Метод для записи действия в лог
        /// </summary>
        /// <param name="action">Действие, которое нужно записать в лог</param>
        public void LogAction(string action)
        {
            // Формируем строку лога
            string logEntry = $"[{DateTime.Now:HH:mm dd.MM.yyyy}] - {action}";

            // Записываем строку лога в файл
            File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
        }
    }
}
