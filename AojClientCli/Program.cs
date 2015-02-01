using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuZakuro.Aoj.Cli 
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Type your name:");
      var usename = Console.ReadLine();
      Console.WriteLine("Type your password:");
      var password = Console.ReadLine();

      AojClient client = new AojClient(new Account(usename, password));

      while (true)
      {
        Console.WriteLine("ProblemNo:");
        int problemNo;
        while(!int.TryParse(Console.ReadLine(), out problemNo))
          Console.WriteLine("ProblemNo must be integer");

        Console.WriteLine("Language:");
        ProgrammingLanguage language;
        while(true)
        {
          var l = Console.ReadLine();
          try
          {
            language = ProgrammingLanguageHelper.FromString(l);
            break;
          }
          catch(ArgumentException)
          {
            Console.WriteLine("Invalid Language. Prease type again");
          }
        }

        Console.WriteLine("Source code:");
        StringBuilder sb = new StringBuilder();
        while(true)
        {
          var c =Console.Read();
          if(c == -1)
            break;
          sb.Append((char)c);
        }

        var rid = client.Submit(problemNo, language, sb.ToString());
        Console.WriteLine("Openning Browser...");
        System.Diagnostics.Process.Start(string.Format("http://judge.u-aizu.ac.jp/onlinejudge/review.jsp?rid={0}#1", rid));
      }
    }
  }
}
