using LibraryApp.Models;
using LibraryApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Generic;

namespace LibraryApp.ViewModels
{
    public class LibraryViewModel : ViewModelBase
    {
        private readonly MainViewModel _mainViewModel; // <--- ДОБАВЛЕНО
        public ObservableCollection<Book> Books { get; set; }
        public ICommand OpenBookCommand { get; }

        // Конструктор теперь принимает MainViewModel
        public LibraryViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel; // <--- СОХРАНЕНИЕ ССЫЛКИ
            Books = new ObservableCollection<Book>();
            LoadSampleData();
            OpenBookCommand = new RelayCommand(OpenBook);
        }

        private void LoadSampleData()
        {
            // Добавим несколько тестовых книг
            Books.Add(new Book
            {
                Id = 1,
                Title = "Дюна",
                Author = "Фрэнк Герберт",
                FileType = "книга",
                ReadingStatus = "в процессе",
                Tags = new List<string> { "Sci-Fi", "Экология" }
            });

            Books.Add(new Book
            {
                Id = 2,
                Title = "Краткая история времени",
                Author = "Стивен Хокинг",
                FileType = "статья",
                ReadingStatus = "прочитано",
                Tags = new List<string> { "Научпоп", "Космология" }
            });
            // TODO: Заменить на реальную загрузку данных из локальной БД
        }

        private void OpenBook(object parameter)
        {
            if (parameter is Book selectedBook)
            {
                // ИСПОЛЬЗУЕМ MainViewModel для навигации на карточку книги
                _mainViewModel.NavigateToBookCard(selectedBook); // <--- ВАЖНОЕ ИЗМЕНЕНИЕ
            }
        }
    }
}