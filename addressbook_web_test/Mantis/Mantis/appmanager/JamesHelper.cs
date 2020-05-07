using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace Mantis 
{
    public class JamesHelper : HelperBase
    {
        public JamesHelper(ApplicationManager manager) : base(manager) { }

        public void Add(AccountData account)
        {
            if (Verify(account))
            {
                return;
            }
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            LoginJames(telnet);
            telnet.WriteLine("adduser " + account.Name + " " + account.Password);
            System.Console.Out.WriteLine(telnet.Read());
        }


        public void Delete(AccountData account)
        {
            if (! Verify(account))
            {
                return;
            }
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            LoginJames(telnet);
            telnet.WriteLine("deluser " + account.Name + " " + account.Password);
            System.Console.Out.WriteLine(telnet.Read());
        }

        public bool Verify(AccountData account)
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            LoginJames(telnet);
            telnet.WriteLine("verify " + account.Name + " " + account.Password);
            String s = telnet.Read();
            System.Console.Out.WriteLine(s);
            return !s.Contains("does not exist");

            //TelnetConnection telnet = LoginJames();
            //telnet.WriteLine("verify " + account.Name);
            //String s = (telnet.Read());
            //System.Console.Out.WriteLine(s);
            //return ! s.Contains("does not exist");
        }

        private void LoginJames(TelnetConnection telnet)
        {
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.Out.WriteLine(telnet.Read());
        }

    }
}
