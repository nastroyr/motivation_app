using Books.Data;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MotivationApp.UI
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        Reminder reminder;

        public MainMenu()
        {
            InitializeComponent();
            reminder = new Reminder();
            reminder.OnBookUpdate += (b => GridBookInfo.DataContext = b);
            reminder.OnQuoteUpdate += (q => TextBlockQuote.Text = q.QuoteText);
            reminder.OnImagePopUp += (i => ShowImageWindow(i));
            reminder.OnEventNotification += (e => Notify(e));
            reminder.Start();
        }

        private void BookshelfButton_Click(object sender, RoutedEventArgs e)
        {
            BookshelfWindow shelf = new BookshelfWindow();
            shelf.ShowDialog();
        }

        private void SchedulerButton_Click(object sender, RoutedEventArgs e)
        {
            SchedulerWindow sch = new SchedulerWindow();
            sch.ShowDialog();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();
            reminder.Restart();
        }

        private void ShowImageWindow(MotivationImage i)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(i.ImgURL, UriKind.Absolute);
            bitmap.EndInit();

            ImageWindow window = new ImageWindow(bitmap);
            window.Height = bitmap.Height;
            window.Width = bitmap.Width;

            window.ShowDialog();
        }

        private void Notify(MotivationEvent e)
        {
            if (e.SoundRemind)
            {
                System.Media.SystemSounds.Beep.Play();
            }
            if (e.VisualRemind)
            {
                VisualRemindWindow win = new VisualRemindWindow(e);
                win.Show();
            }
        }

        private void StopWatchButton_Click(object sender, RoutedEventArgs e)
        {
            StopwatchWindow sw = new StopwatchWindow();
            sw.Show();
        }
    }
}
