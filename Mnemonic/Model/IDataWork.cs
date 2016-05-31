namespace Mnemonic.Model
{
    internal interface IDataWork
    {
        // Создать новый пустой файл БД
        bool CreateNewDB(string path);
        //Открыть существующий файл БД
        bool OpenDB(string path);
        //Сохранить изменения в существующий файл БД
        bool SaveChangesDB(string path);

        //Добавить новый раздел "сфера/предмет" в открытую БД
        bool AddSubjectToDB(string nameSubject);
        //Добавить новый раздел "сфера/предмет" в открытую БД
        bool AddThemeToDB(string nameSubject, string nameTheme);
        //Удалить существующий раздел "сфера/предмет" из открытой БД со всем содержимым
        bool DeleteSubjectFromDB(string nameSubject);
        //Удалить существующий раздел "тема" из открытой БД со всем содержимым
        bool DeleteThemeFromDB(string nameSubject, string nameTheme);
        //Добавить новую запись в БД
        bool AddNewDataObject(DataObject newDataObject);
        //Удалить выбранную запись из БД
        bool DeleteDataObject(string subject, string theme, string dataObject);
        //Перезаписать существующую запись
        bool ChangeDataObject(DataObject dataObject);

        //Вернуть список предметов в БД
        string[] GetListSubjects();
        //Вернуть список тем в заданном предмете
        string[] GetListThemes(string bySubject);
        //Вернуть список вопросов в заданной теме
        string[] GetListQuestions(string bySubject, string byTheme);

        //Вернуть объект данных по полю "Изучаемый вопрос"
        DataObject QueryByQuestion(string subject, string theme, string dataObject);
        //Вернуть массив объектов данных по имени объекта
        DataObject[] QueryBySubject(string subject);
        DataObject[] QueryBySubject(string subject, bool isCompleteFilter);
        //Вернуть массив объектов данных по полю "тема"
        DataObject[] QueryByTheme(string subject, string theme);
        DataObject[] QueryByTheme(string subject, string theme, bool isCompleteFilter);
        //Вернуть массив объектов данных по дате последнего повтора
        DataObject[] QueryByLastRepeat(System.DateTime lastRepeat);
        DataObject[] QueryByLastRepeat(System.DateTime lastRepeat, bool isCompleteFilter);



    }
}
