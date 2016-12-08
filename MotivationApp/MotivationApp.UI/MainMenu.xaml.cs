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

namespace MotivationApp.UI
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void BookshelfButton_Click(object sender, RoutedEventArgs e)
        {
            BookshelfWindow shelf = new BookshelfWindow();
            shelf.Show();
            
        }

        private void SchedulerButton_Click(object sender, RoutedEventArgs e)
        {
            SchedulerWindow sch = new SchedulerWindow();
            sch.Show();
        }
    }
}
