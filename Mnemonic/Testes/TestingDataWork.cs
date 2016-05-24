using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mnemonic.Model;

namespace Mnemonic.Testes
{
    static class TestingDataWork
    {
        public static IDataWork dataWork;

        static TestingDataWork()
        {
            dataWork = new DataWork();
        }
        public static void CreateNewDB(string path)
        {
            dataWork.CreateNewDB(path);
        }

        public static void OpenDB(string path)
        {
            dataWork.OpenDB(path);
        }

        public static void SaveChangesDB(string path)
        {
            dataWork.SaveChangesDB(path);
        }

        public static void AddSubjectToDB(string nameSubject)
        {
            dataWork.AddSubjectToDB(nameSubject);
        }

        public static void AddThemeToDB(string nameSubject, string nameTheme)
        {
            dataWork.AddThemeToDB(nameSubject, nameTheme);
        }

        public static void DeleteSubjectFromDB(string nameSubject)
        {
            dataWork.DeleteSubjectFromDB(nameSubject);
        }

        public static void DeleteThemeFromDB(string nameSubject, string nameTheme)
        {
            dataWork.DeleteThemeFromDB(nameSubject, nameTheme);
        }

        public static void AddNewDataObject(DataObject dataObject)
        {
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("Name 1", "URI 1");
            //dic.Add("Name 2", "URI 2");
            //dic.Add("Name 3", "URI 3");
            //Dictionary<string, string> dic2 = new Dictionary<string, string>();
            //dic2.Add("Img1", "URI 1");
            //DataObject newDataObject = new DataObject {Question = question, Subject = "Предмет 8", Theme = "Тема 0",
            //    Audios = dic, Images = dic2};

            dataWork.AddNewDataObject(dataObject);
        }

        public static void DeleteDataObject()
        {
            dataWork.DeleteDataObject("Предмет 1", "Тема 2", "Вопрос 0");
        }

        public static void QueryByQuestion(string subject, string theme, string dataObject)
        {
            DataObject dataObj = dataWork.QueryByQuestion(subject, theme, dataObject);
            CreateNewDB("testDataObj.xml");
            dataWork.AddSubjectToDB(subject);
            dataWork.AddThemeToDB(subject, theme);
            dataWork.AddNewDataObject(dataObj);
            dataWork.SaveChangesDB("testDataObj.xml");
        }

        public static void ChangeDataObject(string subject, string theme, string dataObject)
        {
            DataObject dataObj = dataWork.QueryByQuestion(subject, theme, dataObject);
            dataObj.Definition = "Ololo.....";

            if(dataWork.ChangeDataObject(null))
                dataWork.SaveChangesDB("testDataObj.xml");
        }

        public static void GetListSubjects()
        {
            string[] subjList = dataWork.GetListSubjects();
            int i = 0;
        }
        public static void GetListThemes()
        {
            string[] themeList = dataWork.GetListThemes("Предмет 20");
            int i = 0;
        }
        public static void GetListQuestion()
        {
            string[] questionList = dataWork.GetListQuestions("Предмет 8", "Тема 0");
            int i = 0;
        }

        public static void QueryByLastRepeat()
        {
            DataObject[] d = dataWork.QueryByLastRepeat(DateTime.Today - TimeSpan.FromDays(3));
            int i = 0;
            foreach (var o in d)
            {
                i++;
            }
        }
        public static void QueryBySubject()
        {
            DataObject[] d = dataWork.QueryBySubject("Предмет 8");
            int i = 0;
            foreach (var o in d)
            {
                i++;
            }
        }
        public static void QueryByTheme()
        {
            DataObject[] d = dataWork.QueryByTheme("Предмет 0", "Тема 1");
            int i = 0;
            foreach (var o in d)
            {
                i++;
            }
        }
    }
}
