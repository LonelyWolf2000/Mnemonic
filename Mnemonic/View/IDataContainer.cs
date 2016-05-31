using System;
using System.Collections.Generic;

namespace Mnemonic.View
{
    public interface IDataContainer
    {
        string[] SubjectsList { get; }
        string[] ThemesList { get; }
        string[] QuestionsList { get; }

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