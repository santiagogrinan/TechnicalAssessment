using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "This is a test string";

            Encoder encoder = new Encoder();

            string crypt = encoder.Encode(test);

            Console.WriteLine("//=====================================================================");
            Console.WriteLine(test + " --> " + crypt);
            Console.WriteLine("//=====================================================================");

            string plain = encoder.Decode(crypt);

            Console.WriteLine("//=====================================================================");
            Console.WriteLine(crypt + " --> " + plain);
            Console.WriteLine("//=====================================================================");

            if (crypt == plain)
                Console.WriteLine("Test succeeded");
            else
                Console.WriteLine("Test failed");
        }     
    }
}
