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
using Books.Data;

namespace MotivationApp.UI
{
    /// <summary>
    /// Логика взаимодействия для BookshelfWindow.xaml
    /// </summary>
    public partial class BookshelfWindow : Window
    {
        Request request = new Request();

        public BookshelfWindow()
        {
            InitializeComponent();
            
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            
            BooksDataGrid.ItemsSource = request.ShowAll();
            BooksDataGrid.Columns[0].Header = "Название книги";
            BooksDataGrid.Columns[1].Header = "Имя автора";
            BooksDataGrid.Columns[2].Header = "Об авторе";
            BooksDataGrid.Columns[3].Header = "О книге";
            BooksDataGrid.Columns[4].Header = "Жанр";
            BooksDataGrid.Columns[5].Header = "Тематика";
            BooksDataGrid.Columns[6].Header = "Где можно купить бумажную версию";
            BooksDataGrid.Columns[7].Header = "Где можно скачать бесплатно";

        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            StackPanelSort.IsEnabled = true;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            List<int> checkGenre = new List<int>();
            List<string> checkSubj = new List<string>();
            List<BookViewModel> res = new List<BookViewModel>();

            if (NovelCheckBox.IsChecked == true)
            {
                checkGenre.Add(1);
            }
            if(BusinessBookСheckBox.IsChecked == true)
            {
                checkGenre.Add(2);
            }
            if(PsychologyCheckBox.IsChecked == true)
            {
                checkGenre.Add(3);
            }
            if(PhilosophyCheckBox.IsChecked == true)
            {
                checkGenre.Add(4);
            }
            if(SuccessCheckBox.IsChecked == true)
            {
                checkSubj.Add("Стремление к успеху");
            }
            if (BusinessCheckBox.IsChecked == true)
            {
                checkSubj.Add("Бизнес");
            }
            if (SelfDevelopmentСheckBox.IsChecked == true)
            {
                checkSubj.Add("Саморазвитие");
            }
            if (checkGenre.Count == 1)
            {
                res = request.SortByGenre(checkGenre[0]);
                //BooksDataGrid.ItemsSource = request.SortByGenre(checkGenre[0]);
                //BooksDataGrid.Columns[0].Header = "Название книги";
                //BooksDataGrid.Columns[1].Header = "Имя автора";
                //BooksDataGrid.Columns[2].Header = "Об авторе";
                //BooksDataGrid.Columns[3].Header = "О книге";
                //BooksDataGrid.Columns[4].Header = "Жанр";
                //BooksDataGrid.Columns[5].Header = "Тематика";
                //BooksDataGrid.Columns[6].Header = "Где можно купить бумажную версию";
                //BooksDataGrid.Columns[7].Header = "Где можно скачать бесплатно";
            }
            else if (checkGenre.Count == 2)
            {
                res = request.SortByGenre(checkGenre[0], checkGenre[1]);
               
            }
            else if (checkGenre.Count == 3)
            {
                res = request.SortByGenre(checkGenre[0], checkGenre[1], checkGenre[2]);
                
            }
            else if (checkGenre.Count == 4)
            {
                res = request.SortByGenre(checkGenre[0], checkGenre[1], checkGenre[2], checkGenre[3]);
                
            }
            if (checkSubj.Count == 0)
            {
                
            }
            else if (checkSubj.Count == 1)
            {
                BooksDataGrid.ItemsSource = request.SortBySubject(res, checkSubj[0]);
            }
        }
    }
}
