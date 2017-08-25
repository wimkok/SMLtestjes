using System;
using System.IO;

namespace SMLtestjes
{
    class Program
    {
        // How it works https://peppol.helger.com/public/locale-en_US/menuitem-docs-doc-exchange
        static void Main(string[] args)
        {
            Smp smp = new Smp("9925:0316380841");
            Console.WriteLine(smp.ToString() + " Published=" + smp.Published);
            //Console.ReadKey();

            smp = new Smp("0106:tttestwimkok");
            Console.WriteLine(smp.ToString() + " Published="+ smp.Published);
            //Console.ReadKey();

            smp = new Smp("9908:889640782"); // 9908  NO: ORGNR 889640782
            Console.WriteLine(smp.ToString() + " Published=" + smp.Published);
            //Console.ReadKey();

            smp = new Smp("9925:BE0316380841"); // 9908  NO: ORGNR 889640782
            Console.WriteLine(smp.ToString() + " Published=" + smp.Published);
            Console.ReadKey();

        }
    }
}
