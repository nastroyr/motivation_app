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
using System.IO;
using Books.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using System.Windows.Controls.Primitives;
using iTextSharp.text.html;

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
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
       where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }

            return null;
        }

        public void Headers()
        {
            BooksDataGrid.Columns[0].Header = "Название книги";
            BooksDataGrid.Columns[1].Header = "Имя автора";
            BooksDataGrid.Columns[2].Header = "Об авторе";
            BooksDataGrid.Columns[3].Header = "О книге";
            BooksDataGrid.Columns[4].Header = "Жанр";
            BooksDataGrid.Columns[5].Header = "Тематика";
            BooksDataGrid.Columns[6].Header = "Где можно купить бумажную версию";
            BooksDataGrid.Columns[7].Header = "Где можно скачать бесплатно";
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            BooksDataGrid.ItemsSource = request.ShowAll();
            Headers();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {

            SortingCanvas.IsEnabled = true;
        }

        private void OKButton_Click_1(object sender, RoutedEventArgs e)
        {
            List<int> checkGenre = new List<int>();
            List<string> checkSubj = new List<string>();
            List<BookViewModel> res = new List<BookViewModel>();

            if (NovelCheckBox.IsChecked == true)
            {
                checkGenre.Add(1);
            }
            if (BusinessBookСheckBox.IsChecked == true)
            {
                checkGenre.Add(2);
            }
            if (PsychologyCheckBox.IsChecked == true)
            {
                checkGenre.Add(3);
            }
            if (PhilosophyCheckBox.IsChecked == true)
            {
                checkGenre.Add(4);
            }
            if (SuccessCheckBox.IsChecked == true)
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
            if (checkGenre.Count > 0)
            {
                if (checkGenre.Count == 1)
                {
                    res = request.SortByGenre(checkGenre[0]);
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
                    BooksDataGrid.ItemsSource = res;
                    Headers();
                }
                else if (checkSubj.Count == 1)
                {
                    BooksDataGrid.ItemsSource = request.SortBySubject(res, checkSubj[0]);
                    Headers();
                }
                else if (checkSubj.Count == 2)
                {
                    BooksDataGrid.ItemsSource = request.SortBySubject(res, checkSubj[0], checkSubj[1]);
                    Headers();
                }
                else if (checkSubj.Count == 3)
                {
                    BooksDataGrid.ItemsSource = request.SortBySubject(res, checkSubj[0], checkSubj[1], checkSubj[2]);
                    Headers();
                }
            }
            else
            {

                if (checkSubj.Count == 0)
                {
                    MessageBox.Show("Извините, но в нашей библиотеке нет книг, подходящих данным условиям! Попробуйте снова с другими параметрами :)");
                }
                else if (checkSubj.Count == 1)
                {
                    BooksDataGrid.ItemsSource = request.SortBySubject(res, checkSubj[0]);
                    Headers();
                }
                else if (checkSubj.Count == 2)
                {
                    BooksDataGrid.ItemsSource = request.SortBySubject(res, checkSubj[0], checkSubj[1]);
                    Headers();
                }
                else if (checkSubj.Count == 3)
                {
                    BooksDataGrid.ItemsSource = request.SortBySubject(res, checkSubj[0], checkSubj[1], checkSubj[2]);
                    Headers();
                }
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            NovelCheckBox.IsChecked = false;
            BusinessBookСheckBox.IsChecked = false;
            PsychologyCheckBox.IsChecked = false;
            PhilosophyCheckBox.IsChecked = false;
            SuccessCheckBox.IsChecked = false;
            SelfDevelopmentСheckBox.IsChecked = false;
            BusinessCheckBox.IsChecked = false;
        }

        private void PDFButton_Click(object sender, RoutedEventArgs e)
        {
            string ttf = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);

            
            Document doc = new Document(PageSize.LETTER, 8, 8, 35, 30);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(BooksDataGrid.Columns.Count);
            for (int i = 0; i < BooksDataGrid.Columns.Count; i++)
            {
                table.AddCell(new Phrase(BooksDataGrid.Columns[i].Header.ToString(), font));
            }

            table.HeaderRows = 1;

            IEnumerable itemsSource = BooksDataGrid.ItemsSource as IEnumerable;
            if (itemsSource != null)
            {
                foreach (var item in itemsSource)
                {
                    DataGridRow row = BooksDataGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < BooksDataGrid.Columns.Count; ++i)
                        {
                            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                            TextBlock txt = cell.Content as TextBlock;
                            if (txt != null)
                            {
                                table.AddCell(new Phrase(txt.Text, font));
                            }
                        }
                    }
                }
            }
            doc.Add(table);
            doc.Close();
            MessageBox.Show("Всё готово!");
        }
    }
}