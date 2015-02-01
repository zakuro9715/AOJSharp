using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YuZakuro.Aoj.Test
{
  [TestClass]
  public class ProgrammingLanguageTest
  {
    [TestMethod]
    public void TestToOptionValue()
    {
      foreach (ProgrammingLanguage v in Enum.GetValues((typeof(ProgrammingLanguage))))
      {
        Assert.IsNotNull(v.ToOptionValue());
      }
    }

    [TestMethod]
    public void TestFromStringWithCorrectValue()
    {
      Assert.AreEqual(ProgrammingLanguage.C, ProgrammingLanguageHelper.FromString("C"));
    }

    [TestMethod]
    public void TestFromStringWithSpecialValue()
    {
      var values = new Dictionary<string, ProgrammingLanguage>(){
        {"C#", ProgrammingLanguage.Csharp},
        {"js", ProgrammingLanguage.JavaScript},
      };
      foreach(var t in values)
      {
        Assert.AreEqual(t.Value, ProgrammingLanguageHelper.FromString(t.Key));
      }
    }

    [TestMethod]
    public void TestFromStringWithInvalidValue()
    {
      try
      {
        ProgrammingLanguageHelper.FromString("Invalid value");
      }
      catch
      {
        return;
      }
      Assert.Fail();
    }
  }
}
