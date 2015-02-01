using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace YuZakuro.Aoj
{
  public enum ProgrammingLanguage
  {
    C = 0, Cpp, Cpp11, Java, Csharp, D, Ruby, Python, Python3, Php, JavaScript
  }

  public static class ProgrammingLanguageHelper
  {
    private static List<string> optionValues = "C C++ C++11 JAVA C# D Ruby Python Python3 PHP JavaScript".Split(' ').ToList();
    
    private static Dictionary<string, ProgrammingLanguage> fromStringTable = new Dictionary<string, ProgrammingLanguage>()
    {
      {"c", ProgrammingLanguage.C},
      {"cpp", ProgrammingLanguage.Cpp},
      {"c++", ProgrammingLanguage.Cpp},
      {"cpp11", ProgrammingLanguage.Cpp11},
      {"c++11", ProgrammingLanguage.Cpp11},
      {"java", ProgrammingLanguage.Java},
      {"csharp", ProgrammingLanguage.Csharp},
      {"c-sharp", ProgrammingLanguage.Csharp},
      {"c#", ProgrammingLanguage.Csharp},
      {"d", ProgrammingLanguage.D},
      {"ruby", ProgrammingLanguage.Ruby},
      {"python", ProgrammingLanguage.Python},
      {"python3", ProgrammingLanguage.Python3},
      {"php", ProgrammingLanguage.Php},
      {"js", ProgrammingLanguage.JavaScript},
      {"javascript", ProgrammingLanguage.JavaScript},
    };

    public static string ToOptionValue(this ProgrammingLanguage p)
    {
      try
      {
        return optionValues[(int)p];
      }
      catch(IndexOutOfRangeException e)
      {
        throw new NotImplementedException(string.Format("Convertion from {0} to option value is not supported", p), e);
      }
    }

    public static ProgrammingLanguage FromString(string s)
    {
      Contract.Requires<ArgumentNullException>(s != null);
      try 
      {
        return fromStringTable[s.ToLowerInvariant()];
      }
      catch(KeyNotFoundException e)
      {
        throw new ArgumentException(string.Format("{0} is a unknown programming language.", s), e);
      }
    }
  }
}
