using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch_Rename
{
    class JsonRuleFormat : IContract
    {
        public Dictionary<string, object> Input { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Rename(string original)
        {
            return "";
        }

        public void Reset()
        {

        }

        public bool Show()
        {
            return true;
        }
    }
}
