using LibraryApp.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LibraryApp.ViewModels
{
    // Модель для хранения отдельного сообщения в чате
    public class ChatMessage
    {
        public string Sender { get; set; } // "User" или "AI"
        public string Text { get; set; }
        public bool IsUser => Sender == "User";
        public bool IsAI => Sender == "AI";
    }

    public class AIViewModel : ViewModelBase
    {
        private string _inputMessage;

        public ObservableCollection<ChatMessage> ChatHistory { get; set; }

        public string InputMessage
        {
            get => _inputMessage;
            set => SetProperty(ref _inputMessage, value);
        }

        // Команды для ИИ-функций
        public ICommand SendMessageCommand { get; }
        public ICommand SummarizeAllCommand { get; }
        public ICommand CompareBooksCommand { get; }
        public ICommand GoBackCommand { get; }

        public AIViewModel(MainViewModel mainViewModel)
        {
            ChatHistory = new ObservableCollection<ChatMessage>();
            LoadInitialMessage();

            SendMessageCommand = new RelayCommand(SendMessage, CanSendMessage);
            SummarizeAllCommand = new RelayCommand(SummarizeAll);
            CompareBooksCommand = new RelayCommand(CompareBooks);
            // Команда для возврата, если понадобится отдельная кнопка
            GoBackCommand = new RelayCommand(o => mainViewModel.Navigate("Library"));
        }

        private void LoadInitialMessage()
        {
            ChatHistory.Add(new ChatMessage
            {
                Sender = "AI",
                Text = "Здравствуйте! Я — ваш интеллектуальный помощник. Чем могу помочь? Вы можете задать вопрос по всей вашей библиотеке или использовать быстрые функции ниже."
            });
        }

        private bool CanSendMessage(object obj)
        {
            // Простая проверка, что поле ввода не пусто
            return !string.IsNullOrWhiteSpace(InputMessage);
        }

        private void SendMessage(object obj)
        {
            string userText = InputMessage;
            ChatHistory.Add(new ChatMessage { Sender = "User", Text = userText });

            // Очистка поля ввода и уведомление UI
            InputMessage = string.Empty;

            // Имитация ответа ИИ
            RespondToUser(userText);
        }

        private void RespondToUser(string userQuery)
        {
            // TODO: Здесь будет реальная логика вызова API ИИ
            string aiResponse = $"Спасибо за ваш запрос '{userQuery}'. Я обрабатываю его и ищу информацию в вашей библиотеке...";

            ChatHistory.Add(new ChatMessage { Sender = "AI", Text = aiResponse });
        }

        private void SummarizeAll(object obj)
        {
            ChatHistory.Add(new ChatMessage { Sender = "User", Text = "📊 Сводка: Выжимка ключевых идей из всей библиотеки." });
            ChatHistory.Add(new ChatMessage { Sender = "AI", Text = "Анализирую все 500+ документов в вашей библиотеке. Это займёт несколько секунд..." });
        }

        private void CompareBooks(object obj)
        {
            ChatHistory.Add(new ChatMessage { Sender = "User", Text = "🧠 Размышления: Сравнить разные книги." });
            ChatHistory.Add(new ChatMessage { Sender = "AI", Text = "Укажите названия книг, которые вы хотите сравнить." });
        }
    }
}