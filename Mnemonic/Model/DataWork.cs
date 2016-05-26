using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mnemonic.Model
{
    internal class DataWork : IDataWork
    {
        private XDocument currentDataBase;
        private const string NAMEOFROOTNODE = "MnemonicDataBase";

        public bool CreateNewDB(string path)
        {
            XDocument xDoc = new XDocument(new XElement(NAMEOFROOTNODE));
            try
            {
                xDoc.Save(path);
                this.currentDataBase = xDoc;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool OpenDB(string path)
        {
            try
            {//todo -- ТЕСТ проверить корректность при эксепшине, не затрется ли переменная
                currentDataBase = XDocument.Load(path);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool SaveChangesDB(string path)
        {
            if (currentDataBase == null)
                return this.CreateNewDB(path);

            try
            {
                currentDataBase.Save(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddSubjectToDB(string nameSubject)
        {
            if (_FindSubject(nameSubject) != null) return false;

            XElement newSubj = new XElement("Subject");
            newSubj.Add(new XAttribute("Name", nameSubject));
            currentDataBase.Root.Add(newSubj);
            return true;
        }

        public bool AddThemeToDB(string nameSubject, string nameTheme)
        {
            XElement subject = _FindSubject(nameSubject);

            if (subject == null || _FindTheme(subject, nameTheme) != null)
                return false;

            XElement newTheme = new XElement("Theme");
            newTheme.Add(new XAttribute("Name", nameTheme));
            subject.Add(newTheme);
            return true;
        }

        public bool DeleteSubjectFromDB(string nameSubject)
        {
            XElement subject = _FindSubject(nameSubject);
            if (subject == null) return false;
            subject.Remove();
            return true;
        }

        public bool DeleteThemeFromDB(string nameSubject, string nameTheme)
        {
            XElement subject = _FindSubject(nameSubject);
            if (subject == null) return false;

            XElement theme = _FindTheme(subject, nameTheme);
            if (theme == null) return false;

            theme.Remove();
            return true;
        }

        public bool AddNewDataObject(DataObject newDataObject)
        {
            if (newDataObject == null || _FindObjectData(newDataObject.Subject, newDataObject.Theme, newDataObject.Question) != null)
                return false;

            XElement newDataObj = _DataObjToXElement(newDataObject);
            if (newDataObj == null) return false;

            XElement destinationTheme = _FindTheme(newDataObject.Subject, newDataObject.Theme);
            destinationTheme.Add(newDataObj);
            return true;
        }

        public bool DeleteDataObject(string subject, string theme, string dataObject)
        {
            XElement elementDataObj = _FindObjectData(subject, theme, dataObject);
            if (elementDataObj == null) return false;

            elementDataObj.Remove();
            return true;
        }

        public bool ChangeDataObject(DataObject dataObject)
        {
            if (dataObject == null) return false;

            XElement oldDataObj = _FindObjectData(dataObject.Subject, dataObject.Theme, dataObject.Question);
            if (oldDataObj == null) return false;

            oldDataObj.ReplaceWith(_DataObjToXElement(dataObject));
            return true;
        }

        public string[] GetListSubjects()
        {
            if (currentDataBase == null || !currentDataBase.Root.Elements().Any()) return null;

            return _FormList(currentDataBase.Root);
        }

        public string[] GetListThemes(string bySubject)
        {
            XElement subjectElem = _FindSubject(bySubject);
            if (subjectElem == null || !subjectElem.Elements().Any()) return null;

            return _FormList(subjectElem);
        }

        public string[] GetListQuestions(string bySubject, string byTheme)
        {
            XElement themeElem = _FindTheme(bySubject, byTheme);
            if (themeElem == null || !themeElem.Elements().Any()) return null;

            int i = 0;
            string[] questionsList = new string[themeElem.Elements().Count()];
            foreach (XElement dataObjElem in themeElem.Elements())
            {
                questionsList[i] = dataObjElem.Element("Question").Value;
                i++;
            }

            return questionsList;
        }

        public DataObject QueryByQuestion(string subject, string theme, string dataObject)
        {
            XElement element = _FindObjectData(subject, theme, dataObject);

            return _XElementToDataObj(element);
        }

        public DataObject[] QueryBySubject(string subject)
        {
            XElement subjElem = _FindSubject(subject);
            if (subjElem == null || !subjElem.Elements().Any()) return null;
            
            DataObject[] finalArr = null;
            foreach (var themeElem in subjElem.Elements())
            {
                DataObject[] tempArr = QueryByTheme(subject, themeElem.FirstAttribute.Value);
                if (tempArr != null)
                    finalArr = finalArr?.Concat(tempArr).ToArray() ?? tempArr;
            }

            return finalArr;
        }

        public DataObject[] QueryByTheme(string subject, string theme)
        {
            XElement themeElem = _FindTheme(subject, theme);
            if (themeElem == null || !themeElem.Elements().Any()) return null;
            
            DataObject[] objOfTheme = new DataObject[themeElem.Elements().Count()];
            for (int i = 0; i < themeElem.Elements().Count(); i++)
            {
                XElement item = themeElem.Elements().ElementAt(i);
                objOfTheme[i] = _XElementToDataObj(item);
            }

            return objOfTheme;
        }

        public DataObject[] QueryByLastRepeat(DateTime lastRepeat)
        {
            if (currentDataBase == null) return null;
            var query = (from subjElement in currentDataBase.Root.Elements()
                                    from themeElem in subjElement.Elements()
                                    from dataElem in themeElem.Elements()
                                    where DateTime.Parse(dataElem.Element("LastRepeat").Value) <= lastRepeat
                                    select dataElem);


            DataObject[] objByRepeatTime = new DataObject[query.Count()];
            for (int i = 0; i < query.Count(); i++)
            {
                objByRepeatTime[i] = _XElementToDataObj(query.ElementAt(i));
            }

            return objByRepeatTime;
        }

        private XElement _FindSubject(string nameSubject)
        {
            var subjectQuery = from e in currentDataBase.Root.Elements()
                               where e.FirstAttribute.Value == nameSubject
                               select e;

            if (subjectQuery.Any())
                return subjectQuery.Single();

            return null;
        }

        private XElement _FindTheme(XElement subject, string nameTheme)
        {
            var themeQuery = from e in subject.Elements()
                             where e.FirstAttribute.Value == nameTheme
                             select e;

            if (themeQuery.Any())
                return themeQuery.Single();

            return null;
        }
        private XElement _FindTheme(string subject, string nameTheme)
        {
            return _FindTheme(_FindSubject(subject), nameTheme);
        }

        private XElement _FindObjectData(string subjectName, string themeName, string dataObject)
        {
            XElement theme = _FindTheme(subjectName, themeName);

            if (theme == null) return null;

            var questions = from q in theme.Elements(nameof(DataObject))
                            where q.Element(nameof(DataObject.Question)).Value == dataObject
                            select q;

            if (questions.Any())
                return questions.Single();

            return null;
        }

        private XElement _DictionaryToXElement(string parentName, Dictionary<string, string> dictionary)
        {
            XElement parentElement = new XElement(parentName);
            if (dictionary != null)
            {
                foreach (var elemDic in dictionary)
                {
                    XElement newItem = new XElement("Item");
                    newItem.Add(new XAttribute("Name", elemDic.Key));
                    newItem.Add(new XAttribute("URI", elemDic.Value));
                    parentElement.Add(newItem);
                }
            }

            return parentElement;
        }

        private Dictionary<string, string> _XElementToDictionary(XElement element)
        {
            if (element.IsEmpty) return null;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var item in element.Elements())
                dic.Add(item.FirstAttribute.Value, item.LastAttribute.Value);

            return dic;
        }
        private DataObject _XElementToDataObj(XElement element)
        {
            if (element == null) return null;

            DataObject dataObject = new DataObject();
            foreach (var property in typeof(DataObject).GetProperties())
            {
                if (property.PropertyType == typeof(string))
                    property.SetValue(dataObject, element.Element(property.Name).Value);
                if (property.PropertyType == typeof(int))
                    property.SetValue(dataObject, Convert.ToInt32(element.Element(property.Name).Value));
                if (property.PropertyType == typeof(Dictionary<string, string>))
                    property.SetValue(dataObject, _XElementToDictionary(element.Element(property.Name)));
                if (property.PropertyType == typeof(DateTime))
                    property.SetValue(dataObject, DateTime.Parse(element.Element(property.Name).Value));
                if (property.PropertyType.IsEnum)
                {
                    object enumObj = Enum.Parse(property.PropertyType, element.Element(property.Name).Value);
                    property.SetValue(dataObject, enumObj);
                }
            }

            return dataObject;
        }

        private XElement _DataObjToXElement(DataObject dataObject)
        {
            XElement newDataObj = new XElement(nameof(DataObject));

            foreach (PropertyInfo property in typeof(DataObject).GetProperties())
            {
                newDataObj.Add(property.PropertyType == typeof(Dictionary<string, string>)
                    ? _DictionaryToXElement(property.Name, property.GetValue(dataObject) as Dictionary<string, string>)
                    : new XElement(property.Name, property.GetValue(dataObject)));
            }

            return newDataObj;
        }
        private static string[] _FormList(XElement element)
        {
            string[] themesList = new string[element.Elements().Count()];
            int i = 0;
            foreach (XElement xElement in element.Elements())
            {
                themesList[i] = xElement.FirstAttribute.Value;
                i++;
            }

            return themesList;
        }
    }
}
