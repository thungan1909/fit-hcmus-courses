using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTPM_W4
{
    public class SFraction : SObject
    {
        private int numerator, denominator;
        public bool IsGreaterThan(double v)
        {
            return (1.0 * numerator / denominator ) > v;
        }
        public bool IsPositive()
        {
            return (numerator * denominator) > 0;
        }
        public void Normalize() //Tối gián
        {

        }
        public override string GetAttributeValue(string strAttributeName)
        {
            switch(BestMatch(strAttributeName))
            {
                case "numerator":
                    return numerator.ToString();
                case "denominator":
                    return denominator.ToString();
            }    
            return base.GetAttributeValue(strAttributeName);
        }

        private string BestMatch(string strAttributeName)
        {
            return strAttributeName.ToLower();
        }

        public override bool SetAttributeValue(string strAttributeName, string newValue)
        {
            switch (BestMatch(strAttributeName))
            {
                case "numerator":
                    {
                        int v = int.Parse(newValue); //parse để ép kiểu về int
                        numerator = v;
                        return true;
                    }
                case "denominator":
                    {
                        int v = int.Parse(newValue); //parse để ép kiểu về int
                        if (v != 0)
                        {
                            denominator = v;
                            return true;
                        }
                        return false;
                    }
            }
            return base.SetAttributeValue(strAttributeName, newValue);
        }
        public override string ExecuteMethod(string strMethodName, string parameters)
        {
            switch (BestMatch(strMethodName))
            {
                case "normalize":
                    {
                        Normalize();
                        return "";
                    }
                case "ispositive":
                    {
                        return IsPositive().ToString();
                    }
                case "isgreaterthan":
                    {
                        double v = double.Parse(parameters);
                        return IsGreaterThan(v).ToString();
                    }
            }
            return base.ExecuteMethod(strMethodName, parameters);
        }

       
    }
}