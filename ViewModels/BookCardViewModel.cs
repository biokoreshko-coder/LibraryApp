using LibraryApp.Models;
using LibraryApp.ViewModels.Base;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class BookCardViewModel : ViewModelBase
    {
        private readonly Book _book;

        // Свойства для отображения в View
        public string Title => _book.Title;
        public string Author => _book.Author;
        public string Description => _book.Description ?? "Описание отсутствует.";
        public string Status => _book.ReadingStatus;

        // Команда для возврата в библиотеку
        public ICommand GoBackCommand { get; }

        // Команда для ИИ-пересказа
        public ICommand SummarizeAICommand { get; }

        // Конструктор принимает выбранную модель книги
        public BookCardViewModel(Book book, MainViewModel mainViewModel)
        {
            _book = book;
            // Команда для возврата: мы вызываем метод из MainViewModel для смены экрана
            GoBackCommand = new RelayCommand(o => mainViewModel.Navigate("Library"));

            // Инициализация других команд
            SummarizeAICommand = new RelayCommand(SummarizeAI);

            // TODO: Загрузка заметок, закладок, истории ИИ-диалогов для этой книги
        }

        private void SummarizeAI(object obj)
        {
            System.Diagnostics.Debug.WriteLine($"Запрос на пересказ для книги: {_book.Title}");
            // TODO: Логика вызова ИИ-сервиса
        }
    }
}