using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace LibraryApp.Converters
{
    /// <summary>
    /// Конвертирует List<string> в одну строку, разделенную запятыми.
    /// </summary>
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Проверяем, является ли значение списком строк (наш List<string> Tags)
            if (value is List<string> list && list.Count > 0)
            {
                // Объединяем элементы списка в одну строку с разделителем ", "
                return string.Join(", ", list);
            }

            // Если список пуст или null, возвращаем пустую строку
            return string.Empty;
        }

        // Обратное преобразование не требуется для этого случая
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}