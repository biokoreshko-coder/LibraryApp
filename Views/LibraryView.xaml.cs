using System.Windows.Controls;
using System.Windows; // Добавьте этот using

namespace LibraryApp.Views
{
    public partial class LibraryView : UserControl
    {
        public LibraryView()
        {
            InitializeComponent();
        }

        // Обработчик двойного клика
        private void ListViewItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            if (item != null && item.DataContext is Models.Book selectedBook)
            {
                // Получаем DataContext (LibraryViewModel)
                if (DataContext is ViewModels.LibraryViewModel viewModel)
                {
                    // Вызываем команду OpenBookCommand, передавая выбранную книгу
                    viewModel.OpenBookCommand.Execute(selectedBook);
                }
            }
        }
    }
}