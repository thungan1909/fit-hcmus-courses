using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp61
{
    public class CPhanSo : CObject
    {

        public CPhanSo()
        {
            this.handle = CObjectManager.CreateRemoteObject("SFraction");
            this.TuSo = 0;
            this.MauSo = 1;
        }

        public CPhanSo(int tuso, int mauso)
        {
            this.handle = CObjectManager.CreateRemoteObject("SFraction");
            this.TuSo = tuso;
            this.MauSo = mauso;
        }

        public int TuSo
        {
            get
            {
                return int.Parse(GetAttributeValue("Numerator"));
            }
            set
            {
                SetAttributeValue("Numerator", value.ToString());
            }
        }

        public int MauSo
        {
            get
            {
                return int.Parse(GetAttributeValue("Denominator"));
            }
            set
            {
                SetAttributeValue("Denominator", value.ToString());
            }
        }


    }
}