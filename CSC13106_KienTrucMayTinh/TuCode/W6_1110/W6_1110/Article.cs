using System;
using System.Collections.Generic;

namespace W6_1110
{
    public class Article
    {
        private static int NextAvailableID = 1;
        public List<String> keywords = new List<String>();
        public string content;

        public Article(string content, List<string> keywords)
        {
            this.content = content;
            this.keywords = keywords;
            this.ID = Article.NextAvailableID++;
        }

        public int ID { get; internal set; }
    }
}