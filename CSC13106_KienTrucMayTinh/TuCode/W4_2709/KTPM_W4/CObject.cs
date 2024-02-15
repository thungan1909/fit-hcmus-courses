using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTPM_W4
{
    public class CObject
    {
        protected int handle = 0;



         protected bool SetAttributeValue( string strAtttributeName, string StrValue)
        {
            return CObjectManager.SetAttributeValue(this.handle, strAtttributeName, StrValue);
        }

        protected string GetAttributeValue( string strAtttributeName)
        {
            return CObjectManager.GetAttributeValue(this.handle, strAtttributeName);
        }
    }
}