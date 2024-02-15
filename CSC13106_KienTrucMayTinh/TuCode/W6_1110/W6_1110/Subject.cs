using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W6_1110
{
    public class Subject
    {
        protected List<Observer> subcribers = new List<Observer>();
        //Subcribe any observer and return success/fail subcribe
        public bool Subcribe(Observer o)
        {
            subcribers.Add(o);
            return true;
        }
        public bool UnSubscribe(Observer o) { 
            subcribers.Remove(o);
            return true;
        }
        public void NotifyAll()
        {
            foreach (Observer o in subcribers)
            {
                o.Notify(this);
            }
        }
    }
}