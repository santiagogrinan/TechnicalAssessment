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
            Test("This is a test string", "Test 1");
            Test("other test", "Test 2");
            Test("abc", "Test 3");
            Test("1", "Test 4");
        } 

        static void Test(string text, string testName)
        {
            Encoder encoder = new Encoder();

            string crypt = encoder.Encode(text);

            Console.WriteLine("//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine();
            Console.WriteLine("Test : " + testName);
            Console.WriteLine();

            Console.WriteLine("//=====================================================================");
            Console.WriteLine();
            Console.WriteLine(text + " --> " + crypt);
            Console.WriteLine();

            string plain = encoder.Decode(crypt);

            Console.WriteLine("//=====================================================================");
            Console.WriteLine();
            Console.WriteLine(crypt + " --> " + plain);
            Console.WriteLine();

            Console.WriteLine("//=====================================================================");
            Console.WriteLine();
            if (text == plain)
                Console.WriteLine("Test succeeded");
            else
                Console.WriteLine("Test failed");

            Console.WriteLine();
        }
    }
}
