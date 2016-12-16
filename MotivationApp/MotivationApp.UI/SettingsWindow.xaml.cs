using Books.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MotivationApp.UI
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        Request request;
        private IEnumerable<MotivationQuote> _src;
        public SettingsWindow()
        {
            InitializeComponent();
            ImagesInterval.Text = Properties.Settings.Default.ImageInterval.ToString();
            QuotesInterval.Text = Properties.Settings.Default.QuoteInterval.ToString();
            BooksInterval.Text = Properties.Settings.Default.BookInterval.ToString();
            request = new Request();
            ListBoxQuotes.ItemsSource = request.GetAllQuotes().ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            string quote = TextBoxQuote.Text;
            request.AddQuote(quote);
            ListBoxQuotes.ItemsSource = request.GetAllQuotes().ToList();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            request.RemoveQuote((MotivationQuote)ListBoxQuotes.SelectedItem);
            ListBoxQuotes.ItemsSource = request.GetAllQuotes().ToList();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int _quoteInterval = int.Parse(QuotesInterval.Text);
                int _bookInterval = int.Parse(BooksInterval.Text);
                int _imageInterval = int.Parse(ImagesInterval.Text);
                if (_quoteInterval <= 0 || _quoteInterval > 24*60*60*60 || _bookInterval <= 0 || _bookInterval > 24 * 60 * 60 * 60 || _imageInterval <= 0 || _imageInterval > 24 * 60 * 60 * 60)
                {
                    throw new Exception();
                }

                Properties.Settings.Default.QuoteInterval = _quoteInterval;
                Properties.Settings.Default.BookInterval = _bookInterval;
                Properties.Settings.Default.ImageInterval = _imageInterval;
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Интервал должен быть от 1 сек. до 1 суток (5 184 000 сек.)");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
