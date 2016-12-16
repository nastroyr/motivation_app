using System;
using System.Windows;

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

        private void TimerTick()
        {

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

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
