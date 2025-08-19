using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal static class Class1
    {
        static void Main(String[] args)
        {
            Console.Title = "Bank Data Server";
            Console.WriteLine("Starting server...");

            var tcp = new NetTcpBinding();

            using (ServiceHost host = new ServiceHost(typeof(DataServer)))
            {
                host.AddServiceEndpoint(typeof(DataServerInterface), tcp,
                    "net.tcp://0.0.0.0:8100/DataService");

                host.Open();
                Console.WriteLine("System Online at net.tcp://0.0.0.0:8100/DataService");
                Console.WriteLine("Press ENTER to stop.");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
