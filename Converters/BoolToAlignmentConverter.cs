using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LibraryApp.Converters
{
    // Преобразует булево значение (IsUser) в HorizontalAlignment
    public class BoolToAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isUser && isUser)
            {
                return HorizontalAlignment.Right; // Сообщение пользователя справа
            }
            return HorizontalAlignment.Left; // Сообщение ИИ слева
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}