using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mnemonic.Controller;

namespace Mnemonic
{
    static class Program
    {//Todo -- почистить.
        private static AgentController _eventController;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _eventController = AgentController.Instance;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Testing();
        }

        static void Testing()
        {
            //Testes.TestingDataWork.CreateNewDB("testDB.xml");
            //Testes.TestingDataWork.OpenDB("testDataObj.xml");
            Testes.TestingDataWork.OpenDB("testDB.xml");
            //Testes.TestingDataWork.DeleteSubjectFromDB("Предмет 18");
            //Testes.TestingDataWork.DeleteThemeFromDB("Предмет 17", "Тема 3");
            //Testes.TestingDataWork.AddNewDataObject("Вопрос: тест коллекций");
            //Testes.TestingDataWork.DeleteDataObject();
            //Testes.TestingDataWork.QueryByQuestion("Предмет 8", "Тема 0", "Вопрос 0");
            //Testes.TestingDataWork.ChangeDataObject("Предмет 8", "Тема 0", "Вопрос 0");
            //Testes.TestingDataWork.GetListSubjects();
            //Testes.TestingDataWork.GetListQuestion();

            Testes.TestingDataWork.QueryByTheme();

            //Testes.TestingDataWork.SaveChangesDB("testDB.xml");
        }

        static void _FillTestDB()
        {
            for (int i = 0; i < 20; i++)
            {
                Testes.TestingDataWork.AddSubjectToDB("Предмет " + i);
                for (int t = 0; t < 5; t++)
                {
                    Testes.TestingDataWork.AddThemeToDB("Предмет " + i, "Тема " + t);
                }
            }
        }

        //static void _FillThemeDB()
        //{
        //    for (int q = 0; q < 5; q++)
        //    {
        //        Testes.TestingDataWork.AddNewDataObject("Вопрос " + q);
        //    }
        //}

        static void _FillDataObj()
        {
            for (int i = 0; i < 10; i++)
            {
                Model.DataObject dataObject = new Model.DataObject();
                dataObject.LastRepeat = DateTime.Today - TimeSpan.FromDays(i);
                dataObject.Subject = "Предмет 8";
                dataObject.Theme = "Тема 2";
                dataObject.Question = "Вопрос " + i;
                Testes.TestingDataWork.AddNewDataObject(dataObject);
            }
        }
    }
}
