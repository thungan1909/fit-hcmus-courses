using System.Collections.Generic;

namespace W6_1110
{
    internal class DefaultContentChecker : ContentChecker
    {
        public override bool isAppropriate(Article article, Member member, List<string> preference)
        {
            for (int i = 0; i < preference.Count; i++)
            {
                for (int j = 0; j < article.keywords.Count; j++)
                {
                    if (preference[i] == article.keywords[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}