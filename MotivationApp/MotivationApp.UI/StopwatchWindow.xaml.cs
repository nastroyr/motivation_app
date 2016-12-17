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
using System.Windows.Threading;

namespace MotivationApp.UI
{
    /// <summary>
    /// Логика взаимодействия для StopwatchWindow.xaml
    /// </summary>
    public partial class StopwatchWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public int secs = 0;
        public int mins = 0;
        public int hours = 0;

        public StopwatchWindow()
        {
            InitializeComponent();
            StopwatchLabel.Content = "0 ч: 0 мин: 0 сек ";
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(Timer_tick);
        }

        void Timer_tick(object obj, EventArgs e)
        {
            StopwatchLabel.Content = hours.ToString() + " ч: " + mins.ToString() + " мин: " + secs++.ToString() + " сек ";
            if ((secs % 60) == 0)
            {
                secs = 0;
                StopwatchLabel.Content = mins++.ToString() + " : " + secs++.ToString();

                if ((mins % 60) == 0)
                {
                    secs = 0;
                    mins = 0;
                    StopwatchLabel.Content = hours++.ToString() + " : " + mins++.ToString() + " : " + secs++.ToString();
                }
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            secs = 0;
            mins = 0;
            hours = 0;
            StopwatchLabel.Content = hours.ToString() + " ч: " + mins.ToString() + " мин: " + secs.ToString() + " сек ";
            timer.Stop();
        }
    }
}
