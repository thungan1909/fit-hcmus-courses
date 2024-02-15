using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp61
{
    public class CObject
    {
        protected int handle = 0;

        protected bool SetAttributeValue(
            string strAttributeName, string strValue)
        {
            return CObjectManager.SetAttributeValue(
                this.handle, strAttributeName, strValue);
        }

        protected string GetAttributeValue(
            string strAttributeName)
        {
            return CObjectManager.GetAttributevalue(
                this.handle, strAttributeName);   
        }

    }
}