using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp61
{
    public class SObject
    {
        protected int handle;

        public int Handle { 
            get => handle; 
            set => handle = value; 
        }

        public SObject()
        {
            SObjectManager.RegisterObject(this);
        }

        public virtual string GetAttributeValue(string strAttributeName)
        {
            return "";
        }

        public virtual bool SetAttributeValue(string strAttributeName, string newValue)
        {
            return true;
        }

        public virtual string ExecuteMethod(string strMethodName, string parameters)
        {
            return "";
        }
    }
}