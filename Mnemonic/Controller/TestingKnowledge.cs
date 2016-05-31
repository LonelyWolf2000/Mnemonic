using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mnemonic.Model;

namespace Mnemonic.Controller
{
    internal class TestingKnowledge : ITestingKnowledge
    {
        private IDataWork _dataWork;
        private List<DataObject> _repeatingList;

        public List<DataObject> RepeatingList
        {
            get { return _repeatingList; }
        }

        public TestingKnowledge()
        {
            _dataWork = AgentController.Instance.DataWork;
            _repeatingList = FormRepeatingList();
        }

        public void CaptureAnswer(int rating)
        {
            throw new NotImplementedException();
        }

        public void CaptureAnswer(bool isRight)
        {
            throw new NotImplementedException();
        }

        public List<DataObject> FormRepeatingList()
        {
            return _FilterByComplete(_dataWork.QueryByLastRepeat(DateTime.Today - TimeSpan.FromDays(1)));
        }

        public List<DataObject> FormRepeatingList(string subject)
        {
            return _FilterByComplete(_dataWork.QueryBySubject(subject));
        }

        public List<DataObject> FormRepeatingList(DateTime date)
        {
            return _FilterByComplete(_dataWork.QueryByLastRepeat(date));
        }

        public List<DataObject> FormRepeatingList(string subject, string theme)
        {
            return _FilterByComplete(_dataWork.QueryByTheme(subject, theme));
        }

        public List<DataObject> FormRepeatingList(string subject, int rating)
        {
            return _FilterByComleteAndRating(_dataWork.QueryBySubject(subject), rating);
        }

        public List<DataObject> FormRepeatingList(DateTime date, string subject)
        {
            return _FilterByComleteAndSubject(_dataWork.QueryByLastRepeat(date), subject);
        }

        public List<DataObject> FormRepeatingList(string subject, string theme, int rating)
        {
            return _FilterByComleteAndRating(_dataWork.QueryByTheme(subject, theme), rating);
        }

        public List<DataObject> FormRepeatingList(DateTime date, string subject, string theme)
        {
            throw new NotImplementedException();
        }

        public void NextQuestion()
        {
            throw new NotImplementedException();
        }

        public void NextQuestion(string subject)
        {
            throw new NotImplementedException();
        }

        public void NextQuestion(string subject, string theme)
        {
            throw new NotImplementedException();
        }


        private List<DataObject> _FilterByComplete(DataObject[] dataObjects)
        {
            List<DataObject> dataObjectsList = new List<DataObject>();
            foreach (DataObject data in dataObjects)
            {
                if(!data.Completed)
                    dataObjectsList.Add(data);
            }

            return dataObjectsList.Count > 0 ? dataObjectsList : null;
        }

        private List<DataObject> _FilterByComleteAndRating(DataObject[] dataObjects, int rating)
        {
            List<DataObject> dataObjectsList = new List<DataObject>();
            foreach (DataObject data in dataObjects)
            {
                if (!data.Completed && data.Rating <= rating)
                    dataObjectsList.Add(data);
            }

            return dataObjectsList.Count > 0 ? dataObjectsList : null;
        }

        private List<DataObject> _FilterByComleteAndSubject(DataObject[] dataObjects, string subject)
        {
            List<DataObject> dataObjectsList = new List<DataObject>();
            foreach (DataObject data in dataObjects)
            {
                if (!data.Completed && data.Subject == subject)
                    dataObjectsList.Add(data);
            }

            return dataObjectsList.Count > 0 ? dataObjectsList : null;
        }
    }
}
