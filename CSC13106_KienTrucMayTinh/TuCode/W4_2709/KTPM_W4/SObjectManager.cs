using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTPM_W4
{
    public class SObjectManager
    {
        private static Dictionary<int, SObject> objects = new Dictionary<int, SObject>();
        private static int NextAvailableHandle = 1;

        public static void RegisterObject(SObject sObject)
        {
            sObject.Handle = SObjectManager.NextAvailableHandle++;
            SObjectManager.objects.Add(sObject.Handle,sObject); // Object khi được tạo lập sẽ có ID phân biệt và được quản lý tập trung

        }

        internal static int CreateObject(string strRemoteType)
        {
            switch (strRemoteType)
            {
                case "SFraction":
                    return new SFraction().Handle;
                case "SStudent":
                    return new SStudent().Handle;

            }
            return 0;
        }

        public static string GetAttributeValue(int handle, string strAttributeName)
        {
            if (CheckObject(handle))
            {
                SObject obj = FindObjectByHandle(handle);
                return obj.GetAttributeValue(strAttributeName);
            }
            return "";
        }

        public static bool SetAttributeValue(int handle, string strAttributeName, string newValue)
        {
            if (CheckObject(handle))
            {
                SObject obj = FindObjectByHandle(handle);
                return obj.SetAttributeValue(strAttributeName,newValue);
            }
            return false;
        }

        public static string ExecuteMethod(int handle, string strHandleMethod, string paramenter)
        {
            if (CheckObject(handle))
            {
                SObject obj = FindObjectByHandle(handle);
                return obj.ExecuteMethod(strHandleMethod, paramenter);
            }
            return "";
        }

        private static SObject FindObjectByHandle(int handle)
        {
            return objects[handle];
        }

        private static bool CheckObject(int handle)
        {
            return objects.ContainsKey(handle); //tìm xem có chứa handle không
        }
    }
}