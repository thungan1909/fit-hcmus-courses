using System;
using System.Collections.Generic;

namespace W6_1110
{
    internal class MessageQueue
    {
        private List<Member> members;
        private List<Article> articles;

        NewsChannel Owner;

        internal void Queue(Member member, Article article)
        {
            members.Add(member);
            articles.Add(article);
        }
        internal bool NeedToFlush()
        {
            return (members.Count == 10);
        }

        public MessageQueue(NewsChannel newsChannel)
        {
            this.Owner = newsChannel;
        }

        internal void Flush()
        {
            for (int i = 0; i < members.Count; i++)
            {
                members[i].Notify(this.Owner, articles[i]);
            }
            members.Clear();
            articles.Clear();
        }

      
       
    }
}