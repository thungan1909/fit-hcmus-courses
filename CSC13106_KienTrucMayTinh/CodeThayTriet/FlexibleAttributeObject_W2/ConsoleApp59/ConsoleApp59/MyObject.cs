using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp59
{
    public class MyObject
    {
        protected Dictionary<string, object> attributes= 
            new Dictionary<string, object>();

        protected Dictionary<string, MyFunction> methods = 
            new Dictionary<string, MyFunction>();

        protected int ID;
        public MyObject()
        {
            MyObject.Register(this);
        }

        public MyObject(string strType)
        {
            MyObject.Register(this);
            populateCommonAttributesOfThisTypePlease(strType);
        }

        private void populateCommonAttributesOfThisTypePlease(string strType)
        {
            AttributeManager.HelpMePlease(this, strType);
        }

        private static Dictionary<int, MyObject> allObjects
            = new Dictionary<int, MyObject>();

        private static int NextAvailbleID = 1;
        private bool bAutoAddNew = true;

        private static void Register(MyObject obj)
        {
            allObjects.Add(NextAvailbleID, obj);
            obj.ID = NextAvailbleID++;
        }

        public object getAttributeValue(string attributeName)
        {
            if (attributes.ContainsKey(attributeName))
                return attributes[attributeName];
            return null;
        }

        public bool setAttributeValue(string attributeName, 
            object newValue)
        {
            if (attributes.ContainsKey(attributeName))
            {
                attributes[attributeName] = newValue;
                return true;
            }
            else if (bAutoAddNew)
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