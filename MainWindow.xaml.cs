using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;


namespace TestTask
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            WeatherButton.IsEnabled = true;

            if (CityTextBox.Text == "")
            {
                WeatherButton.IsEnabled = false;
            }
        }

        async private void GetWeather(object sender, RoutedEventArgs e)
        {
            Service service = new(); 
            try
            {
                String weatherInfo = await service.GetWeather(CityTextBox.Text);
                Info.Content = weatherInfo;
            } 
            catch (HttpRequestException exception)
            {
                Info.Content = exception.Message;
            }
        }
    }
}
