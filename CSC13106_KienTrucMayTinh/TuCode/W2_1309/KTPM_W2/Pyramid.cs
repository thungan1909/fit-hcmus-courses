using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KTPM_W2
{
    public class Pyramid
    {
        private Pyramid() //private giúp để kiểm soát việc tạo lập nếu có chỉ nằm trong lòng của class Pyramid thôi chứ không nằm ở chỗ khác
        {
            nCount++; // Tạo ra và tăng số lượng lên
        }
        /*     private static Pyramid instance = null;
             public static Pyramid Build()
             {
                 if (instance == null)  //Nếu chưa xây
                 {
                     instance = new Pyramid();
                     return instance;
                 }
                 return null;
             }
        //version đầu tiên để minh họa ý tưởng
        */
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