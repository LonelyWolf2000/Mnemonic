using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mnemonic.Model;
using Mnemonic.View;

namespace Mnemonic.Controller
{
    internal class BaseController
    {
        private static BaseController _instance;
        //private IDataWork _dataWork;
        //private IViewEditMode _viewEditMode;
        //public IDataWork DataWork => _dataWork;
        //public IViewEditMode ViewEditMode => _viewEditMode;

        public static BaseController Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new BaseController();
                return _instance;
            }
        }

        //public BaseController()
        //{
        //    _dataWork = new DataWork();
        //    _viewEditMode = View.ViewEditMode.Instance;
        //}

        internal DataObject InitDataObject()
        {
            DataObject dataObject = new DataObject();

            PropertyInfo[] propertyesView = typeof(ViewEditMode).GetProperties();
            foreach (PropertyInfo propObj in typeof(DataObject).GetProperties())
            {
                var prop = from p in propertyesView
                           where p.Name == propObj.Name
                           select p;
                if (prop.Any())
                    propObj.SetValue(dataObject, prop.Single().GetValue(ViewEditMode.Instance));
            }

            return dataObject;
        }

        internal void SetPropertyViewEditMode(DataObject dataObject)
        {
            PropertyInfo[] propertyesView = typeof (ViewEditMode).GetProperties();
            foreach (PropertyInfo propObj in typeof(DataObject).GetProperties())
            {
                var prop = from p in propertyesView
                               where p.Name == propObj.Name
                               select p;
                if(prop.Any())
                    prop.Single().SetValue(ViewEditMode.Instance, propObj.GetValue(dataObject));
            }
        }
    }
}
