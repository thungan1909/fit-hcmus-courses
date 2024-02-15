using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W6_1110
{
    public class NewsChannel
    {
        protected Dictionary<int, Article> articles = new Dictionary<int, Article>();
        protected Dictionary<int, Member> subscibers = new Dictionary<int, Member>();
        protected Dictionary<int, List<String>> preferences = new Dictionary<int, List<String>>();

        public bool Subscribe(Member member, List<String> keywords)
        {
            subscibers.Add(member.ID, member);
            preferences.Add(member.ID, keywords);
            return true;
        }

        public bool Unsubscribe(int ID)
        {
            subscibers.Remove(ID);
            preferences.Remove(ID);
            return true;
        }
        public bool PostArticle(Article article, Member author)
        {
            if (IsMember(author))
            {
                articles.Add(article.ID, article);
                NotifyAll(article);
                return true;
            }
            return false;

        }

        private bool IsMember(Member author)
        {
            return subscibers.ContainsKey(author.ID);
        }

        private ContentChecker contentChecker = new DefaultContentChecker();
        public string channelName;

        public NewsChannel(string channelName)
        {
            this.channelName = channelName;
        }

        private void NotifyAll(Article article)
        {
            foreach (int id in articles.Keys)
            {
                if (contentChecker.isAppropriate(article, subscibers[id], preferences[id]))
                {
                    //subscibers[id].Notify(this, article);

                    EnqueueNotification(subscibers[id], article);
                }
            }
        }

        MessageQueue mq = new MessageQueue(this);
        private void EnqueueNotification(Member member, Article article)
        {
            mq.Queue(member, article);
            if (mq.NeedToFlush())
            {
                mq.Flush();
            }
        }
    }
}