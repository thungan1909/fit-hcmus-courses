/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;

class HelloWorld 
{
    interface InRenameRule {
        string Rename(string original);
    }
        
    class ReplaceRule : InRenameRule{
        public List<string> Needles { get; set; }
        public string Replacer { get; set;}
        
        //Truyen vao cac doi so cua luat
        public ReplaceRule(List <string> needles,string replacer)
        {
            this.Needles=needles;
            this.Replacer=replacer;
        }
        
        public string Rename(string original)
        {
            string result = original;
            
            foreach(var needle in Needles)
            {
                result=result.Replace(needle,Replacer);
            }
            return result;
        }
        
        
    }
    
    class AddPrefixRule: InRenameRule{
        public string Prefix {get;set;}
        public AddPrefixRule(string prefix)
        {
            Prefix=prefix;
        }
        public string Rename(string original)
        {
            string result="";
            result =$"{Prefix}{original}";
            return result;
        }
    }
  static void Main() {
    string fileName1="The quick brown fox";
    
    InRenameRule rule1=new ReplaceRule(new List<string>() {"-","."}," ");
    string newname1=rule1.Rename(fileName1);
    Console.WriteLine(newname1);
    
    string fileName2="Tran Cong Minh CV.pdf";
    InRenameRule rule2=new ReplaceRule(new List<string>() {" "},"-");
    string newname2=rule2.Rename(fileName2);
    Console.WriteLine(newname2);
    
    string fileName3="How to play piano youtube.com.mp3";
    InRenameRule rule3=new ReplaceRule(new List<string>() {"youtube.com"},"");
    string newname3=rule3.Rename(fileName3);
    Console.WriteLine(newname3);
    
    
    string fileName4="Tran Duy Quang.pdf";
    InRenameRule rule4=new AddPrefixRule("CV ");
    string newname4=rule4.Rename(fileName4);
    Console.WriteLine(newname4);
    
    string original="How to play piano youtube.com.mp3";
    var rules = new List<InRenameRule>(){rule4, rule3,rule2 };
    string newname=original;
    foreach (var rule in rules)
    {
        newname = rule.Rename(newname);
    }
    
    Console.WriteLine(newname);
     using (var reader = new StreamReader ("preset01.txt"))
    {
         while(!reader.EndOfStream)
         {
            string line=reader.ReadLine();
            Console.WriteLine(line);
         }
    }
  
   
  }
}
