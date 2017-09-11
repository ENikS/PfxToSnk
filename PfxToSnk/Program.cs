using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace PfxToSnk
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var certificate = new X509Certificate2(args[0], args[2], X509KeyStorageFlags.Exportable);
                var privateKey = (RSACryptoServiceProvider)certificate.PrivateKey;
                File.WriteAllBytes(args[1], privateKey.ExportCspBlob(true));
            }
            catch 
            {
                PrintUsage();
            }
        }

        static void PrintUsage()
        {
            Console.WriteLine("\nUsage: PfxToSnk input.pfx output.snk password \n\n");
        }
    }
}
