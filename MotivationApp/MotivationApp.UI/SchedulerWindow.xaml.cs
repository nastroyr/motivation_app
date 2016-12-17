using Books.Data;
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
    /// Логика взаимодействия для SchedulerWindow.xaml
    /// </summary>
    public partial class SchedulerWindow : Window
    {
        Request _request;
        public SchedulerWindow()
        {
            InitializeComponent();
            _request = new Request();
            ListBoxEvents.ItemsSource = _request.GetAllEvents();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEventWindow win = new AddEventWindow();
            win.ShowDialog();
            if (win.DialogResult == true)
            {
                _request.AddEvent(win.CreatedEvent);
            }
            ListBoxEvents.ItemsSource = _request.GetAllEvents();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ListBoxEvents.SelectedItem != null)
            {
                MotivationEvent eventToDelete = (MotivationEvent)ListBoxEvents.SelectedItem;
                _request.RemoveEvent(eventToDelete);
            }
            ListBoxEvents.ItemsSource = _request.GetAllEvents();
        }
    }
}
