using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFClient.Views
{
    /// <summary>
    /// Interaction logic for NumbersWindow.xaml
    /// </summary>
    public partial class NumbersWindow : Window
    {
        public string PinCode { get; set; } = string.Empty;
        public NumbersWindow()
        {
            InitializeComponent();
        }

        private void NumberClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender; // Отримуємо посилання на натискану кнопку.
            string number = clickedButton.Content.ToString(); // Отримуємо текст кнопки (цифру).
            PinCode += number; // Додаємо цифру до рядка pin.
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult= false;
        }
    }
}
