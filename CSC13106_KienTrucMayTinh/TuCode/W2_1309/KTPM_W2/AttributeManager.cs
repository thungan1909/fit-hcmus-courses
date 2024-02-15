using System;

namespace KTPM_W2
{
    internal class AttributeManager
    {
        internal static bool HelpMePlease(MyObject myObject, string strType)
        {
            if (strType == "Sinh Viên")
            {
                myObject["MSSV"] = "19120302";
                myObject["Họ và chữ lót"] = "Đoàn Thu";
                myObject["Tên"] = "Ngân";
                myObject["GPA"] = "8.1";
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