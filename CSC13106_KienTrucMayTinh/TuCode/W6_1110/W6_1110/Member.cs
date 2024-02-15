using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W6_1110
{
    public class Member
    {
        private static int NextAvailableID = 1;
        public string FullName;

        public Member(string FullName)
        {
            this.FullName = FullName;
            this.ID = Member.NextAvailableID++;
        }

        public int ID { get; internal set; }

        internal void Notify(NewsChannel newsChannel, Article article)
        {
            Console.WriteLine(this.FullName + " reads " + article.content);
        }
    }
}