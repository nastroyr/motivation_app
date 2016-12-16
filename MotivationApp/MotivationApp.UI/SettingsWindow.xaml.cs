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
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private IEnumerable<MotivationQuote> _src;
        public SettingsWindow(IEnumerable<MotivationQuote> src)
        {
            InitializeComponent();
            ImagesInterval.Text = Properties.Settings.Default.ImageInterval.ToString();
            QuotesInterval.Text = Properties.Settings.Default.QuoteInterval.ToString();
            BooksInterval.Text = Properties.Settings.Default.BookInterval.ToString();
            _src = src;
            ListBoxQuotes.ItemsSource = _src;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            string quote = TextBoxQuote.Text;
            if (!String.IsNullOrEmpty(quote))
            {

            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
