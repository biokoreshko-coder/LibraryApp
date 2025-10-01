using LibraryApp.ViewModels.Base;
using LibraryApp.Models; // Добавляем using для Book
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private string _searchText;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public ICommand NavigateCommand { get; }
        public ICommand PerformSearchCommand { get; }

        public MainViewModel()
        {
            // Передаем ссылку на себя (this) в конструктор LibraryViewModel
            CurrentViewModel = new LibraryViewModel(this);

            NavigateCommand = new RelayCommand(Navigate);
            PerformSearchCommand = new RelayCommand(PerformSearch);
        }

        public void Navigate(object parameter)
        {
            string targetView = parameter as string;

            switch (targetView)
            {
                case "Library":
                    // При переходе на "Library" создаем новый LibraryViewModel
                    CurrentViewModel = new LibraryViewModel(this);
                    break;
                case "AI":
                    // CurrentViewModel = new AIViewModel(this);
                    break;
                // ... другие разделы
                default:
                    CurrentViewModel = new LibraryViewModel(this);
                    break;
            }
        }

        // НОВЫЙ МЕТОД: Навигация к конкретной карточке книги
        public void NavigateToBookCard(Book book)
        {
            CurrentViewModel = new BookCardViewModel(book, this);
        }

        private void PerformSearch(object parameter)
        {
            // Логика поиска...
        }
    }
}