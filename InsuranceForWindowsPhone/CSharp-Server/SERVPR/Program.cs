using System;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SERVPL
{
    static class Program
    {
        private const char LengthPrefixDelimiter = ';';
        private static AutoResetEvent _flipFlop = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            IPHostEntry ipHostInfo = Dns.GetHostByName(Dns.GetHostName());
            IPEndPoint localEP = new IPEndPoint(ipHostInfo.AddressList.First(), 11852);
            Console.WriteLine("Local address and port : {0}", localEP);
            Server Server1 = new Server();
            Console.ReadLine();

        }
        
    }
}