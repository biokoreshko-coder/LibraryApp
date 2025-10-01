using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LibraryApp.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        // Событие для оповещения UI об изменении свойства
        public event PropertyChangedEventHandler PropertyChanged;

        // Метод для вызова события
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Устанавливает значение свойства и вызывает OnPropertyChanged, если значение изменилось.
        /// </summary>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}