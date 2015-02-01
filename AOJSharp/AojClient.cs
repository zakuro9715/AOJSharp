using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.IO;

namespace YuZakuro.Aoj
{
  public class AojClient
  {
    private Encoding encoding = Encoding.GetEncoding("Shift_JIS");

    private readonly Account account;
    public Account Account { get { return account; } }

    public AojClient(Account _account)
    {
      account = _account;
    }

    private byte[] BuildSubmissionRequestBody(int problemNo, ProgrammingLanguage language, string code)
    {
      StringBuilder sb = new StringBuilder();
      var data = new Dictionary<string, string>()
      {
        {"userID", Account.Username},
        {"password", Account.Password},
        {"problemNO", problemNo.ToString()},
        {"language", language.ToOptionValue()},
        {"sourceCode", code},
      };

      foreach (var t in data)
        sb.AppendFormat("{0}={1}&", t.Key, HttpUtility.UrlEncode(t.Value, encoding));
      // Remove trailing &
      sb.Remove(sb.Length - 1, 1);

      return Encoding.ASCII.GetBytes(sb.ToString());
    }

    private void WriteRequestBody(WebRequest request, byte[] data)
    {
      using (var stream = request.GetRequestStream())
        stream.Write(data, 0, data.Length);
    }

    private int GetRid()
    {
      var request = HttpWebRequest.Create("http://judge.u-aizu.ac.jp/onlinejudge/status.jsp");
      request.Method = "GET";
      
      string html;
      using(var res = request.GetResponse())
        using(var reader = new StreamReader(res.GetResponseStream()))
          html = reader.ReadToEnd();

      var regexp = new System.Text.RegularExpressions.Regex(@"review.jsp\?rid=\d+");
      var match = regexp.Match(html);
      return int.Parse(match.Value.Substring("review.jsp?rid=".Length));
    }

    public int Submit(int problemNo, string language, string code)
    {
      return Submit(problemNo, ProgrammingLanguageHelper.FromString(language), code);
    }

    public int Submit(int problemNo, ProgrammingLanguage language, string code)
    {
      var request = HttpWebRequest.Create("http://judge.u-aizu.ac.jp/onlinejudge/servlet/Submit");

      request.Method = "POST";
      request.ContentType = "application/x-www-form-urlencoded";

      byte[] encodedData = BuildSubmissionRequestBody(problemNo, language, code);
      request.ContentLength = encodedData.Length;
      WriteRequestBody(request, encodedData);

      var res = request.GetResponse();
      return GetRid();
    }
  }
}
