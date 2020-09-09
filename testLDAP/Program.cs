using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace testLDAP
{
    class Program
    {
        static readonly string domainName = ConfigurationManager.AppSettings["domainName"];
        static readonly string username = ConfigurationManager.AppSettings["username"];
        static readonly string password = ConfigurationManager.AppSettings["password"];

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(domainName);
                Console.WriteLine(username);
                Console.WriteLine(password);


                var p = new PrincipalContext(ContextType.Domain, domainName,
                    "", "");
                if (!p.ValidateCredentials(username, password))
                {
                    Console.WriteLine("Not Valid Credentials");
                }
                else
                {
                    Console.WriteLine("Valid Credentials!!!!");
                }

                StayOpen();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                StayOpen();

                throw;
            }
        }

        private static void StayOpen()
        {
            Console.ReadLine();
            Console.Read();
            Console.ReadKey(true);
        }
    }
}