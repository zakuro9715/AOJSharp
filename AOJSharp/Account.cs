using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuZakuro.Aoj
{
  public struct Account
  {
    private readonly string username;
    private readonly string password;

    public string Username { get { return username; } }
    public string Password { get { return password; } }

    public Account(string _username, string _password)
    {
      username = _username;
      password = _password;
    }
  }
}
