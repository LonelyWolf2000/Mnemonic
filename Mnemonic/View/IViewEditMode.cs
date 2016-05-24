using System;
using System.Collections.Generic;

namespace Mnemonic.View
{
    internal interface IViewEditMode
    {
        string[] SubjectsList { get; set; }
        string[] ThemesList { get; set; }
        string[] QuestionsList { get; set; }

        //Поля для обмена информацией между формой и контроллером
        string Question { get; set; }
        string Subject { get; set; }
        string Theme { get; set; }
        string Term { get; set; }
        string Definition { get; set; }
        Dictionary<string, string> Images { get; set; }
        Dictionary<string, string> Audios { get; set; }
        int Rating { get; set; }
        Model.ModeTest ModeTest { get; set; }
        Model.ModeRepeat ModeRepeat { get; set; }
        DateTime RepeatTime { get; set; }
        bool IsResetRaiting { get; }
        bool IsCompleted { get; set; }

        //Создать новый файл БД
        void CreateNewBD(string path);
        //Сохранить файл
        void SaveFileDB(string path);
        //Открыть файл БД
        void OpenDataBase(string path);
        //Создать новый раздел "Предмет"
        void NewSubject(string nameSubject);
        //Создать новый раздел "Тема"
        void NewTheme(string nameSubject, string nameTheme);
        //Создать новую запись (очистить форму и свойства)
        void NewDataObject();
        //Сохранить запись
        void SaveDataObject();
        //Удалить запись
        void DeleteDataObject(string question);
        //Удалить раздел "Предмет"
        void DeleteSubject(string nameSubject);
        //Удалить раздел "Тема"
        void DeleteDataTheme(string nameSubject, string nameTheme);
        //Добавить изображение в коллекцию
        void AddImage(string name, string uri);
        //Удалить изображение из коллекцию по ключу
        void DeleteImage(string name);
        //Добавить аудио в коллекцию
        void AddAudio(string name, string uri);
        //Удалить аудио из коллекцию по ключу
        void DeleteAudio(string name);


        // Запросить список предметов
        string[] QuerySubjectsList();
        //Обработать выбор вопроса
        void SelectedQuestion(string question);
        //Обработать выбор предмета
        string[] SelectedSubject(string subject);
        //Обработать выбор темы
        string[] SelectedTheme(string subject, string theme);
        //Обработать выбор изображения
        void SelectionImage(string name);
        //Обработать выбор аудио
        void SelectionAudio(string name);


        //Обновить интерфейс пользователя
        void RefreshUserInterface();
    }
}
