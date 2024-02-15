using System;

namespace ConsoleApp59
{
    internal class AttributeManager
    {
        internal static bool HelpMePlease
            (MyObject myObject, string strType)
        {
            if (strType == "Sinh viên")
            {
                myObject["MSSV"] = "19120123";
                myObject["Họ và chữ lót"] = "...";
                myObject["Tên"] = "...";
                myObject["ĐTB"] = 9.87;
                return true;
            }
            else if (strType == "Môn học")
            {
                return true;
            }
            return false;

        }
    }
}