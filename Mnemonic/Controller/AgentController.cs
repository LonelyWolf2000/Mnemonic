using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mnemonic.Model;
using Mnemonic.View;

namespace Mnemonic.Controller
{
    internal class AgentController //: BaseController
    {
        private static AgentController _instance;
        private BaseController _baseController;
        private IDataWork _dataWork;
        private IViewEditMode _viewEditMode;
        public static AgentController Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new AgentController();
                return _instance;
            }
        }

        public AgentController()
        {
            _instance = this;
            _baseController = BaseController.Instance;
            _dataWork = new DataWork();
            _viewEditMode = ViewEditMode.Instance;
        }

        public void CreateNewDb(string path)
        {
            _dataWork.CreateNewDB(path);
        }
        public void SaveFileDb(string path)
        {
            _dataWork.SaveChangesDB(path);
        }
        public void OpenDataBase(string path)
        {
            if(_dataWork.OpenDB(path))
                _dataWork.GetListSubjects();
        }
        public void NewSubject(string name)
        {
            _dataWork.AddSubjectToDB(name);
        }
        public void NewTheme(string nameSubject, string nameTheme)
        {
            _dataWork.AddThemeToDB(nameSubject, nameTheme);
        }
        public void SaveDataObject(string question)
        {
            if (_dataWork.QueryByQuestion(_viewEditMode.Subject, _viewEditMode.Theme, question) != null)
                _dataWork.ChangeDataObject(_baseController.InitDataObject());
            else
                _dataWork.AddNewDataObject(_baseController.InitDataObject());

        }
        public void DelDataObject(string question)
        {
            _dataWork.DeleteDataObject(_viewEditMode.Subject, _viewEditMode.Theme, question);
        }

        public void DelTheme(string nameSubject, string nameTheme)
        {
            _dataWork.DeleteThemeFromDB(nameSubject, nameTheme);
        }
        public void DelSubject(string name)
        {
            _dataWork.DeleteSubjectFromDB(name);
        }

        public string[] QuerySubjectsList()
        {
            return _dataWork.GetListSubjects();
        }
        public string[] QueryThemesList(string name)
        {
            return _dataWork.GetListThemes(name);
        }
        public string[] QueryQuestionsList(string subject, string theme)
        {
            return _dataWork.GetListQuestions(subject, theme);
        }
        public void QueryQuestiuon(string name)
        {
            DataObject dataObject = _dataWork.QueryByQuestion(_viewEditMode.Subject, _viewEditMode.Theme, name);
            if (dataObject == null) return;

            _baseController.SetPropertyViewEditMode(dataObject);
            _viewEditMode.RefreshUserInterface();
        }
    }
}
