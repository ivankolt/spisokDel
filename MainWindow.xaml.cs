using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;
using System.IO;

namespace spisokDel
{

    public class Vibor
    {
        public string Text { get; set; }
        public bool IsChecked { get; set; }
        public static string Color { get; set; } = "#00FFFFFF";
    }


    public partial class MainWindow : Window
    {
        public List<Vibor> ListVibor { get; set; }

        public static string ColorStat { get; set; } = "#00FFFFFF";

        private const string JsonFilePath = @"C:\Users\User\source\repos\spisokDel\spisokDel\ListVibor.json";

        public MainWindow()
        {
            InitializeComponent();
            ListVibor = new List<Vibor>();
            LoadData();
        }
        private void SaveData()
        {
            string jsonString = JsonConvert.SerializeObject(ListVibor, Formatting.Indented);
            File.WriteAllText(JsonFilePath, jsonString);
        }
        private void LoadData()
        {
            if (File.Exists(JsonFilePath))
            {
                string jsonString = File.ReadAllText(JsonFilePath);
                ListVibor = JsonConvert.DeserializeObject<List<Vibor>>(jsonString);
                UpdateList(); 
            }
        }

        private void UpdateCheckBoxBackground(CheckBox checkBox, TextBlock textBlock)
        {
            if (checkBox.IsChecked == true)
            {
                Vibor.Color = "#FF65B424";
            }
            else
            {
                Vibor.Color = "#00FFFFFF";
            }
            textBlock.Background = (Brush)new BrushConverter().ConvertFromString(Vibor.Color);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Delo delo = new Delo(this);
            delo.Show();
        }
        public void UpdateList()
        {
            Vibbbor.Children.Clear();

            foreach (var vibor in ListVibor)
            {
                StackPanel itemPanel = new StackPanel { Orientation = Orientation.Horizontal };

                TextBlock textBlock = new TextBlock
                {
                    Text = vibor.Text,
                    Margin = new Thickness(5),
                    FontSize = 24,
                    FontWeight = FontWeights.Bold,
                    TextWrapping = TextWrapping.Wrap,
                    Width = 390,
                    Background = (Brush)new BrushConverter().ConvertFromString(ColorStat)
                };

                CheckBox checkBox = new CheckBox
                {
                    IsChecked = vibor.IsChecked,
                    Margin = new Thickness(5),
                };

                checkBox.Click += (sender, e) =>
                {
                    vibor.IsChecked = checkBox.IsChecked == true;
                    UpdateCheckBoxBackground(checkBox, textBlock);
                    SaveData();
                };

                itemPanel.Children.Add(checkBox);
                itemPanel.Children.Add(textBlock);

                Vibbbor.Children.Add(itemPanel);
            }
        }


        public void AddListVibor(string text)
        {
            Vibor vibor = new Vibor
            {
                Text = text,
                IsChecked = false
            };

            ListVibor.Add(vibor);
            SaveData();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
         
            ListVibor.RemoveAll(vibor => vibor.IsChecked == true);           
            UpdateList();
            SaveData();
        }
    }
}