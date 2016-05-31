using System;

namespace Mnemonic.View
{
    public interface IViewTestMode : IDataContainer
    {
        string Answer { get; }
        string[] WrongAnswers { get; }


        //Задать список ложных ответов
        void SetWrongAnswers();
        //Взять следующий в списке вопрос
        void GetNextQuestion();
        //Послать ответ
        void SendAnswer(string answer);

        //Повторить ответ
        void RepeatQuestion(string question);
        //Повторить тему
        void RepeatTheme(string subject, string theme);
        //Повторить предмет
        void RepeatSubject(string subject);
        //Повторить вопросы с оценкой меньше заданной
        void RepeatByRating(int rating);
        //Повторить вопросы старше заданной даты
        void RepearByDate(DateTime date, bool complitely);
    }
}