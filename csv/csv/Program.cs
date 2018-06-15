using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace csv
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "TestData.csv";//@"c:\~\~\~\TestData.csv";
            var dat = File.ReadAllLines(file);
            Console.WriteLine(Header(dat.First()));
            foreach(var id in dat.Skip(1).Select(x => new BodyMass(x)))
            {
                Console.WriteLine(id.ToString());
            }
            Console.ReadKey();
        }
        private static string Header(string origialHeader)
        {
            var items = origialHeader.Split(',').Select(x => x.Trim());
            return $"{items.First()},{string.Join(",", items.Skip(1))},{string.Join(",", items.Skip(1).Zip(items.Skip(2), (first, second) => $"{first}と{second}との差"))}";
        }
    }
}
