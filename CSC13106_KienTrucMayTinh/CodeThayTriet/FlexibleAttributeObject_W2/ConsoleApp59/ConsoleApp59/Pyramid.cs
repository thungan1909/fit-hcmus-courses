using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp59
{
    public class Pyramid
    {
        private Pyramid()
        {
            nCount++;
        }

 /*       private static Pyramid instance = null;
        public static Pyramid Build()
        {
            if (instance == null)
            {
                instance = new Pyramid();
                return instance;
            }
            return null;
        }*/

        public static Pyramid Build()
        {
            if (CanBuild())
            {                
                return new Pyramid();
            }
            return null;

        }

        private static int nMaxInstances = 120;
        private static int nCount = 0;

        private static bool CanBuild()
        {
            return nCount < nMaxInstances;
        }
    }
}