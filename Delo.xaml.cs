using System;
using System.Collections.Generic;
using System.Linq;
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

namespace spisokDel
{
    /// <summary>
    /// Логика взаимодействия для Delo.xaml
    /// </summary>
    public partial class Delo : Window
    {
        private MainWindow mainWindow;
        public Delo(MainWindow window)
        {
            InitializeComponent();
            mainWindow = window;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Добавить дело", "Вы точно этого хотите?", MessageBoxButton.YesNo, MessageBoxImage.None);

            if (result == MessageBoxResult.Yes)
            {
                string taskText = TextDelo.Text; 
                mainWindow.AddListVibor(taskText);
                mainWindow.UpdateList();
                this.Close();
              
         
            }
          
        }

    }
}
