using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class HelloWorld
    {

        interface IRenameRule
        {
            string Rename(string original);
        }

        class ReplaceRule : IRenameRule
        {
            public List<string> Needles { get; set; }
            public string Replacer { get; set; }

            public ReplaceRule(List<string> needles, string replacer)
            {
                this.Needles = needles;
                this.Replacer = replacer;
            }

            public string Rename(string original)
            {
                string result = original;

                foreach (var needle in Needles)
                {
                    result = result.Replace(needle, Replacer);
                }

                return result;
            }
        }

        class AddPrefixRule : IRenameRule
        {
            public string Prefix { get; set; }
            public AddPrefixRule(string prefix)
            {
                Prefix = prefix;
            }

            public string Rename(string original)
            {
                string result = "";

                result = $"{Prefix}{original}";

                return result;
            }
        }

        class AllLowerRule : IRenameRule
        {
            public string Rename(string original)
            {
                return original.ToLower();
                //   var builder = new StringBuilder();

                //   foreach(var c in original) {
                //       builder.Add(c.ToLower());
                //   }

                //   var result = builder.ToString();
                //   return result;
            }
        }

        interface IRenameRuleParser
        {
            IRenameRule Parse(string line);
        }

        // Replace ["vietnamworks.com", "a", "b"] => ""
        class ReplaceRuleParser : IRenameRuleParser
        {
            public static string MagicWord = "Replace";

            public IRenameRule Parse(string line)
            {
                string[] tokens = line.Split(new string[] { "Replace " }, StringSplitOptions.None);
                string[] parts = tokens[1].Split(new string[] { " => " }, StringSplitOptions.None);
                // Remove []
                string[] words = parts[0].Substring(1, parts[0].Length - 2).Split(new string[] { ", " }, StringSplitOptions.None);
                List<string> needles = new List<string>();
                foreach (string word in words)
                {
                    needles.Add(word.Substring(1, word.Length - 2));
                }

                string replacement = parts[1].Substring(1, parts[1].Length - 2);

                IRenameRule rule = new ReplaceRule(needles, replacement);
                return rule;
            }
        }

        // AddPrefix "CV "
        class AddPrefixRuleParser : IRenameRuleParser
        {
            public static string MagicWord = "AddPrefix";

            public IRenameRule Parse(string line)
            {
                string[] tokens = line.Split(new string[] { "AddPrefix " }, StringSplitOptions.None);

                string prefix = tokens[1].Replace("\"", "");
                IRenameRule rule = new AddPrefixRule(prefix);

                return rule;
            }
        }

        class AllLowerRuleParser : IRenameRuleParser
        {
            public static string MagicWord = "AllLower";

            public IRenameRule Parse(string line)
            {
                IRenameRule rule = new AllLowerRule();

                return rule;
            }
        }

        class RuleParserFactory
        {
            private Dictionary<string, IRenameRuleParser> _prototypes = null;

            public RuleParserFactory()
            { // Configuration
                _prototypes = new Dictionary<string, IRenameRuleParser>() {
            {AddPrefixRuleParser.MagicWord, new AddPrefixRuleParser() },
            {ReplaceRuleParser.MagicWord, new ReplaceRuleParser()},
            {AllLowerRuleParser.MagicWord, new AllLowerRuleParser()}
        };
            }

            public IRenameRuleParser Create(string choice)
            {
                IRenameRuleParser parser = _prototypes[choice];
                return parser;
            }
        }

        static void Main()
        {
            // string filename1 = "The-quick-brown.fox";

            // IRenameRule rule1 = new ReplaceRule(new List<string>() {"-", "."}, " ");
            // string newname1 = rule1.Rename(filename1);

            // Console.WriteLine(newname1);

            // string filename2 = "Tran Cong Minh CV.pdf";
            // IRenameRule rule2 = new ReplaceRule(new List<string>() {" "}, "-");
            // string newname2 = rule2.Rename(filename2);

            // Console.WriteLine(newname2);

            // string filename3 = "How to play piano youtube.com.mp3";
            // IRenameRule rule3 = new ReplaceRule(new List<string>() {"youtube.com"} , "");
            // string newname3 = rule3.Rename(filename3);

            // Console.WriteLine(newname3);


            // string filename4 = "Tran Duy Quang.pdf";
            // IRenameRule rule4 = new AddPrefixRule("CV ");
            // string newname4 = rule4.Rename(filename4);
            // Console.WriteLine(newname4);

            // string original = "How to play piano youtube.com.mp3";
            // var preset = new List<IRenameRule>() {rule4, rule3, rule2};

            // string newname = original;

            // foreach(var rule in preset) {
            //     newname = rule.Rename(newname);
            // }
            // Console.WriteLine(newname);


            // // haystack: đống rơm
            // // rule => needle (kim)  ==> replacer
            // string newname = filename.Replace("brown", "fox");
            // Console.WriteLine(newname);
            RuleParserFactory factory = new RuleParserFactory();
            List<IRenameRule> rules = new List<IRenameRule>();

            using (var reader = new StreamReader("preset01.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    // Trích xuất từ đầu tiên để biết nên tạo ra luật gì
                    int firstSpaceIndex = line.IndexOf(" ");
                    string firstWord = "";
                    if (firstSpaceIndex > 0)
                    {
                        firstWord  = line.Substring(0, firstSpaceIndex);
                    } else
                    {
                        firstWord = line;
                    }

                    IRenameRuleParser parser = factory.Create(firstWord);
                    IRenameRule rule = parser.Parse(line);
                    rules.Add(rule);

                    Console.WriteLine(firstWord);
                }
            }

            string original = "Do Hai Thang vietnamworks.com.pdf";
            string newname = original;

            foreach (var rule in rules)
            {
                newname = rule.Rename(newname);
            }
            Console.WriteLine(newname);
        }
    }