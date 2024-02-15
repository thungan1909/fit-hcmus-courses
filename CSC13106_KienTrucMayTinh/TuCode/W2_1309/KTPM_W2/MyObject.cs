using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTPM_W2
{
    public class MyObject
    {
        protected Dictionary<string, object> attributes = new Dictionary<string, object>();
        protected Dictionary<string, MyFunction> methods = new Dictionary<string, MyFunction>();

        protected int ID;
        public MyObject()
        {
            MyObject.Register(this);
        }

        public MyObject(string strType)
        {
            MyObject.Register(this);
            listCommonAttributeOfThisType(strType);
        }

        private  void listCommonAttributeOfThisType(string strType)
        {

            AttributeManager.HelpMePlease(this, strType);
        }

        private static Dictionary<int, MyObject> allObjects = new Dictionary<int, MyObject>();
        private static int nextAvailbleID = 1;
        private bool autoAddNew = true;

        private static void Register(MyObject obj)
        {
            allObjects.Add(nextAvailbleID, obj);
            obj.ID = nextAvailbleID++;
        }
        public object getAttributeValue(string attributeName)
        {
            if(attributes.ContainsKey(attributeName))  //nếu trong phần thuộc tính có giá trị này
            {
                return attributes[attributeName];      //thì sẽ dựa vào tên để lấy giá trị tương ứng
            }
            return null;
        }

        public bool setAttributeValue(string attributeName, object newValue)
        {
            if (attributes.ContainsKey(attributeName)) //nếu có tồn tại tên attribute này
            {
                attributes[attributeName] = newValue;
                return true;
            }
            else if (autoAddNew)
            {
                attributes.Add(attributeName, newValue);
                return true;
            }
            return false;
        }
        public object this[string attributeName]
        {
            get {
                return getAttributeValue(attributeName);
            }
            set {
                setAttributeValue(attributeName, value);
                 
            }
        }
    }
}