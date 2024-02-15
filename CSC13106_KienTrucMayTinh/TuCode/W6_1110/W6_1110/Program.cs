using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W6_1110
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NewsChannel K19FIT = new NewsChannel("K19FIT");
            NewsChannel K19FIT4Fun = new NewsChannel("K19FIT4Fun");
            Member sv1 = new Member("Doan Thu Ngan");
            Member sv2 = new Member("Nguyen Van A");
            Member sv3 = new Member("Nguyen Van B");
            Member sv4 = new Member("Nguyen Van C");

            K19FIT.Subscribe(sv1, new List<string>
            {
                "family", "code", "work"
            });
            K19FIT.Subscribe(sv2, new List<string>
            {
                "family", "code", "eat"
            });

            Article a1 = new Article("content", new List<string> { "code" });
            K19FIT.PostArticle(a1, sv1);

        }
    }
}
