using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp61
{
    public class CObjectManager
    {
        internal static bool SetAttributeValue(int handle, string strAttributeName, string strValue)
        {
            return SObjectManager.SetAttributeValue(
                handle, strAttributeName, strValue);
        }

        internal static int CreateRemoteObject(string strRemoteType)
        {
            return SObjectManager.CreateObject(strRemoteType);
        }

        internal static string GetAttributevalue(int handle, string strAttributeName)
        {
            return SObjectManager.GetAttributeValue(
                handle, strAttributeName);
        }
    }
}