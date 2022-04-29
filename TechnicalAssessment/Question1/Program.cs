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
            try
            {
                Test("This is a test string", "Test 1");
                Test("other test", "Test 2");
                Test("abc", "Test 3");
                Test("abcde", "Test 4");
                Test("1", "Test 5");
                Test("This is a large text that allow know if working well with big string", "Test 6");
                Test("Test special caracter \"&\"", "Test 7");
                Test("Test new line \n Second line", "Test 8");
                TestAlphanumericCharacters();
                TestAllCharacter();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        //=====================================================================
        static void Test(string text, string testName)
        {
            Encoder encoder = new Encoder();

            Console.WriteLine("//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine();
            Console.WriteLine("Test : " + testName);
            Console.WriteLine();

            string crypt = encoder.Encode(text);

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

            if (text != plain)
                throw new Exception("Test : " + testName + " faild with text : " + text);

            Console.WriteLine("Test succeeded");
        }

        //=====================================================================
        static void TestAlphanumericCharacters()
        {
            char[] text = new char[95];

            for (int i = 0; i < text.Length; i++)
                text[i] = (char)((int)' ' + i);

            Test(new string(text), "AlphanumericCharacters");
        }

        //=====================================================================
        static void TestAllCharacter()
        {
            char[] text = new char[255];

            for (int i = 0; i < text.Length; i++)
                text[i] = (char)i;

            Test(new string(text), "AllCharecters");
        }
    }
}
