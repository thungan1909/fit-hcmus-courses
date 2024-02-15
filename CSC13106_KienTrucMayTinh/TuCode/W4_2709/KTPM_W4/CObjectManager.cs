using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTPM_W4
{
    public class CObjectManager
    {
        internal static bool SetAttributeValue(int handle, string strAttributeName, string strValue)
        {
            return SObjectManager.SetAttributeValue(handle, strAttributeName, strValue);
        }

        internal static int CreateRemoteObject(string strRemoteType)
        {
            return SObjectManager.CreateObject(strRemoteType);
        }

        internal static string GetAttributeValue(int handle, string strAtttributeName)
        {
                return SObjectManager.GetAttributeValue(handle, strAtttributeName);
        }
    }
}