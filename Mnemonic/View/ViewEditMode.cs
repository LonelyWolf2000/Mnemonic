using System;
using System.Collections.Generic;
using System.Linq;
using Mnemonic.Controller;
using Mnemonic.Model;

namespace Mnemonic.View
{
    internal class ViewEditMode : IViewEditMode
    {
        internal delegate void OnFileLoaded();
        internal delegate void ChangeFields();

        private static IViewEditMode _instance;
        private AgentController _agentController;
        private string _lastDBOpen_URI;
        private bool _isDataBaseLoaded;

        public event ChangeFields changeFieldsEvent;
        public event OnFileLoaded onFileLoadedEvent;

        public static IViewEditMode Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new ViewEditMode();
                return _instance;
            }
        }
        public bool IsDataBaseLoaded
        {
            get { return _isDataBaseLoaded; }
        }

        public ViewEditMode()
        {
            _isDataBaseLoaded = false;
            _agentController = AgentController.Instance;
        }

        //private bool isResetRaiting;
        public string Question { get; set; }
        public string Subject { get; set; }
        public string Theme { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
        public Dictionary<string, string> Images { get; set; }
        public Dictionary<string, string> Audios { get; set; }
        public int Rating { get; set; }
        public ModeTest ModeTest { get; set; }
        public ModeRepeat ModeRepeat { get; set; }
        public DateTime RepeatTime { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsResetRaiting { get; set; }

        public string[] SubjectsList { get; set; }

        public string[] ThemesList { get; set; }

        public string[] QuestionsList { get; set; }

        public void CreateNewBD(string path)
        {
            _agentController.CreateNewDb(path);
            _isDataBaseLoaded = true;
            onFileLoadedEvent?.Invoke();
        }
        public void SaveFileDB(string path)
        {
            _agentController.SaveFileDb(path);
        }
        public void OpenDataBase(string path)
        {
            _isDataBaseLoaded =_agentController.OpenDataBase(path);
            if(!IsDataBaseLoaded) return;

            SubjectsList = _agentController.QuerySubjectsList();
            if (SubjectsList != null)
                ThemesList = SelectedSubject(SubjectsList.First());
            if (ThemesList != null)
                QuestionsList = SelectedTheme(SubjectsList.First(), ThemesList.First());

            _lastDBOpen_URI = path;
            onFileLoadedEvent?.Invoke();
        }

        public void NewSubject(string nameSubject)
        {
            _agentController.NewSubject(nameSubject);
            SubjectsList = QuerySubjectsList();
        }

        public void NewTheme(string nameSubject, string nameTheme)
        {
            _agentController.NewTheme(nameSubject, nameTheme);
            ThemesList = SelectedSubject(nameSubject);
        }

        public void NewDataObject()
        {
            ResetFields();
        }

        public void SaveDataObject()
        {
            _agentController.SaveDataObject(Question);
            QuestionsList = _agentController.QueryQuestionsList(Subject, Theme);
            _agentController.SaveFileDb(_lastDBOpen_URI);
        }

        public void DeleteDataObject(string dataObject)
        {
            _agentController.DelDataObject(this.Question);
        }

        public void DeleteSubject(string nameSubject)
        {
            _agentController.DelSubject(nameSubject);
            SubjectsList = QuerySubjectsList();
        }

        public void DeleteDataTheme(string nameSubject, string nameTheme)
        {
            _agentController.DelTheme(nameSubject, nameTheme);
            ThemesList = SelectedSubject(nameSubject);
        }

        public void AddImage(string name, string uri)
        {
            if(this.Images == null)
                this.Images = new Dictionary<string, string>();

            this.Images.Add(name, uri);
        }

        public void DeleteImage(string name)
        {
            if (this.Images != null && this.Images.ContainsKey(name))
                this.Images.Remove(name);
        }

        public void AddAudio(string name, string uri)
        {
            if (this.Audios == null)
                this.Audios = new Dictionary<string, string>();

            this.Audios.Add(name, uri);
        }

        public void DeleteAudio(string name)
        {
            if (this.Audios != null && this.Audios.ContainsKey(name))
                this.Audios.Remove(name);
        }

        public string[] QuerySubjectsList()
        {
            return _agentController.QuerySubjectsList();
        }

        public void SelectedQuestion(string question)
        {
            _agentController.QueryQuestiuon(question);
        }
        
        public string[] SelectedSubject(string subject)
        {
            ThemesList = _agentController.QueryThemesList(subject);
            return ThemesList;
        }

        public string[] SelectedTheme(string subject, string theme)
        {
            QuestionsList = _agentController.QueryQuestionsList(subject, theme);
            return QuestionsList;
        }

        public void SelectionImage(string name)
        {
            throw new NotImplementedException();
        }

        public void SelectionAudio(string name)
        {
            throw new NotImplementedException();
        }

        public void RefreshUserInterface()
        {
            this.changeFieldsEvent?.Invoke();
        }
        
        private void ResetFields()
        {
            this.Question = null;
            this.Theme = null;
            this.Definition = null;
            this.Images = null;
            this.Audios = null;
            this.Rating = 0;
            this.ModeTest = ModeTest.Writen;
            this.ModeRepeat = ModeRepeat.Twice_a_Day;
            this.RepeatTime = new DateTime();
            this.IsCompleted = false;
            this.IsResetRaiting = false;
        }
    }
}
