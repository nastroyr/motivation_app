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
    /// Логика взаимодействия для VisualRemindWindow.xaml
    /// </summary>
    public partial class VisualRemindWindow : Window
    {
        public VisualRemindWindow(MotivationEvent ev)
        {
            InitializeComponent();
            gridMain.DataContext = ev;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
