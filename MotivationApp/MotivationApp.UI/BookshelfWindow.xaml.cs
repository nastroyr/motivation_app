using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using Books.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using System.Windows.Controls.Primitives;

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

        private void OKButton_Click(object sender, RoutedEventArgs e)
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
                res = request.SortByGenre(checkGenre);
                if (checkSubj.Count == 0)
                {
                    BooksDataGrid.ItemsSource = res;
                }
                else
                {
                    BooksDataGrid.ItemsSource = request.SortBySubject(res, checkSubj);
                }
            }
            else
            {
                if (checkSubj.Count == 0)
                {
                    BooksDataGrid.ItemsSource = request.ShowAll();
                }
                else
                {
                    BooksDataGrid.ItemsSource = request.SortBySubject(null, checkSubj);
                }
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(Object o in sortingStackPanel.Children)
            {
                if (o is CheckBox)
                {
                    ((CheckBox)o).IsChecked = false;
                }
            }
            BooksDataGrid.ItemsSource = request.ShowAll();
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