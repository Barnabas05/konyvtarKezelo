using konyvtarKezelo;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static System.Reflection.Metadata.BlobBuilder;

namespace konyvtarKezelo
{
    public partial class MainWindow : Window
    {
        private List<Book> books = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Könyv hozzáadása
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTextBox.Text;
            var selectedCategory = CategoryComboBox.SelectedItem as ComboBoxItem;

            if (string.IsNullOrWhiteSpace(title) || selectedCategory == null)
            {
                MessageBox.Show("A könyv címe és műfaja kötelező!");
                return;
            }

            Book newBook = new Book
            {
                Title = title,
                Category = selectedCategory.Content.ToString()
            };

            books.Add(newBook);
            BookListBox.Items.Add(newBook);

            TitleTextBox.Clear();
            CategoryComboBox.SelectedIndex = -1;
        }

        // Könyv törlése
        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (BookListBox.SelectedItem != null)
            {
                var bookToDelete = BookListBox.SelectedItem as Book;
                MessageBoxResult result = MessageBox.Show($"Biztosan törölni akarja a könyvet: {bookToDelete.Title}?", "Törlés megerősítése", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    books.Remove(bookToDelete);
                    BookListBox.Items.Remove(bookToDelete);
                }
            }
            
        }

        private void Filtercategory_Changed(object sender, RoutedEventArgs e)
        {
            var selectedCategory = FilterCategoryComboBox.SelectedItem as ComboBoxItem;
            string selectedCategoryString = selectedCategory.Content.ToString();

            BookListBox.Items.Clear();

            foreach (var book in books)
            {
                if (selectedCategoryString == "Összes" || book.Category == selectedCategoryString)
                {
                    BookListBox.Items.Add(book);
                }
            }
            
                
            }

        // Összes könyv megjelenítése
        private void ShowAllBooks_Click(object sender, RoutedEventArgs e)
        {
            string allBooks = string.Join("\n", books);
            MessageBox.Show(allBooks, "Összes könyv");
        }

       
    }
}
