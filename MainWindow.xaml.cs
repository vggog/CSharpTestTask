using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            WeatherButton.IsEnabled = true;

            if (SityTextBox.Text == "")
            {
                WeatherButton.IsEnabled = false;
            }
        }

        async private void GetWeather(object sender, RoutedEventArgs e)
        {
            Api api = new();
            try
            {
                await api.GetWeather(SityTextBox.Text);
            } 
            catch (HttpRequestException exception)
            {
                ExceptionLabel.Content = exception.Message;
            }
        }
    }
}
