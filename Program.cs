//Author: Anthony S. West - 2022/08/01 - Checks two strings and compares for an anagram (fast, well, for C# anyway lol)

using System;

//net 6 is really screwy with console apps not needing an explicit main function - bleh - doing it the old way
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace TestAnagram
{
    internal class Program
    {
        // ----------------------------------------------------------------------------------------
        static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Must have two args, both strings.");
                return 1;
            }

            string str1 = args[0], str2 = args[1];

            Console.WriteLine($"1: \"{str1}\", 2: \"{str2}\"");

            bool isAnagram = IsAnagram(str1, str2);

            Console.WriteLine($"Is anagram? {isAnagram}");
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();
            return 0;
        }

        // ----------------------------------------------------------------------------------------
        static bool IsAnagram(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return false;

            if (str1.Length != str2.Length)
                return false;

            str1 = str1.ToLower();
            str2 = str2.ToLower();

            if (str1 == str2)
                return true;

            const int nAlphaChars = 26;
            int[] str1AlphaCounts = new int[nAlphaChars];
            int[] str2AlphaCounts = new int[nAlphaChars];

            foreach (char ch in str1)
            {
                int idx = ch - 'a';

                if (idx >= 0 && idx < nAlphaChars)
                    str1AlphaCounts[idx]++;
            }

            foreach (char ch in str2)
            {
                int idx = ch - 'a';

                if (idx >= 0 && idx < nAlphaChars)
                    str2AlphaCounts[idx]++;
            }

            return CountsTheSame(str1AlphaCounts, str2AlphaCounts);
        }

        // ----------------------------------------------------------------------------------------
        private static bool CountsTheSame(int[] str1AlphaCounts, int[] str2AlphaCounts)
        {
            if (null == str1AlphaCounts || null == str2AlphaCounts)
                return false;

            if (str1AlphaCounts.Length != str2AlphaCounts.Length)
                return false;

            for (int i = 0; i < str1AlphaCounts.Length; i++)
            {
                if (str1AlphaCounts[i] != str2AlphaCounts[i])
                    return false;
            }

            return true;
        }

        // ----------------------------------------------------------------------------------------

        // ----------------------------------------------------------------------------------------
    }
}
