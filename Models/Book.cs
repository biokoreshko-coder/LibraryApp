using System.Collections.Generic;

namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string FilePath { get; set; } // Путь к локальному файлу
        public string CoverImagePath { get; set; } // Путь к обложке
        public string Description { get; set; }
        public string Language { get; set; }
        public string FileType { get; set; } // "книга", "статья", "заметка"

        // Список тегов (пока как строки, позже можно заменить на List<Tag>)
        public List<string> Tags { get; set; } = new List<string>();

        // Статус чтения: "не прочитано", "в процессе", "прочитано"
        public string ReadingStatus { get; set; } = "не прочитано";

        // Свойство для избранного
        public bool IsFavorite { get; set; }
    }
}