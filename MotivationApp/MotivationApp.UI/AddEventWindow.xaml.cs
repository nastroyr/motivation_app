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
    /// Логика взаимодействия для AddEventWindow.xaml
    /// </summary>
    public partial class AddEventWindow : Window
    {
        public MotivationEvent CreatedEvent;
        public AddEventWindow()
        {
            CreatedEvent = null;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtName.Text;
                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception();
                }
                if (datePickerDate.SelectedDate == null)
                {
                    throw new Exception();
                }
                DateTime date = (DateTime)datePickerDate.SelectedDate;
                if (date < DateTime.Now)
                {
                    throw new Exception();
                }
                string place = txtPlace.Text;
                string description = txtDescription.Text;
                int repeat = string.IsNullOrEmpty(txtRepeat.Text) ? 0 : int.Parse(txtRepeat.Text);
                int repeatSeconds = 0;
                if (repeat != 0)
                {
                    if (comboBoxItemSeconds.IsSelected)
                    {
                        repeatSeconds = repeat;
                    }
                    if (comboBoxItemMinutes.IsSelected)
                    {
                        repeatSeconds = repeat * 60;
                    }
                    if (comboBoxItemHours.IsSelected)
                    {
                        repeatSeconds = repeat * 60 * 60;
                    }
                }
                List<NotificationType> types = new List<NotificationType>();
                if (checkBoxSound.IsChecked == true)
                {
                    types.Add(NotificationType.Sound);
                }
                if (checkBoxVisual.IsChecked == true)
                {
                    types.Add(NotificationType.Visual);
                }

                MotivationEvent ev = new MotivationEvent(name, date, description, types, place, repeatSeconds);
                CreatedEvent = ev;
                DialogResult = true;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при вводе данных");
            }
        }
    }
}
