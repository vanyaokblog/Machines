using System.Windows;

namespace Machines
{
    /// <summary>
    /// Логика взаимодействия для ReceiptWindow.xaml
    /// </summary>
    public partial class ReceiptWindow : Window
    {
        public ReceiptWindow()
        {
            InitializeComponent();
        }

        // Метод для отображения чека в текстовом блоке
        public void ShowReceipt(string receipt)
        {
            // Установка текста чека в текстовый блок
            ReceiptTextBlock.Text = receipt;
        }
    }
}
