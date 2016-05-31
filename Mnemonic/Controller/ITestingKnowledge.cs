using System;
using System.Collections.Generic;
using Mnemonic.Model;

namespace Mnemonic.Controller
{
    internal interface ITestingKnowledge
    {
        //Коллекция вопрос на повторение/тестирование
        List<DataObject> RepeatingList { get; }

        //Методы для формирования коллекции вопросов на повторение/тестирование
        List<DataObject> FormRepeatingList();
        List<DataObject> FormRepeatingList(DateTime date);
        List<DataObject> FormRepeatingList(string subject);
        List<DataObject> FormRepeatingList(DateTime date, string subject);
        List<DataObject> FormRepeatingList(string subject, int rating);
        List<DataObject> FormRepeatingList(string subject, string theme);
        List<DataObject> FormRepeatingList(DateTime date, string subject, string theme);
        List<DataObject> FormRepeatingList(string subject, string theme, int rating);

        //Методы "шагания" по коллекции
        void NextQuestion();
        void NextQuestion(string subject);
        void NextQuestion(string subject, string theme);

        //Методы обработки ответов в соответствии с заданым режимом
        void CaptureAnswer(bool isRight);
        void CaptureAnswer(int rating);
    }
}
