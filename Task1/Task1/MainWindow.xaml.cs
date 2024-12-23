﻿using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task1
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
        string response;
        string url;
        async  void test()
        {
            await Task.Run(() => {
                 
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();

                }
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
                Dispatcher.Invoke(()=>townName.Content=weatherResponse.Name);
                Dispatcher.Invoke(() => townTemp.Content = weatherResponse.Main.Temp);
                Dispatcher.Invoke(() => townDescription.Content = weatherResponse.Weather[0].Description);
                Dispatcher.Invoke(() => townIcon.Source = new BitmapImage( new Uri($"http://openweathermap.org/img/w/{weatherResponse.Weather[0].Icon}.png")));
            });
         



          
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                url = $"https://api.openweathermap.org/data/2.5/weather?q={townSearch.Text}&units=metric&lang=RU&appid=11e92b97b09012267754f48d244af4cc";
                test();

            }
        }
    }
}