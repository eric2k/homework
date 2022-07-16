using System;
using System.Collections.Generic;

namespace _2.Puzzle.Medium
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  Write code that meets the following requirements:
             *      - takes input of an arbitrary list of strings (examples provided in Resource.cs
             *      - for each string, looks at the other strings to search for anagrams (ignoring case)
             *      - returns a list of lists, where
             *          - each list contains the anagrams of the first string (not case sensitive)
             *          - list of lists is sorted alphabetically by the first item in each list
             *          - each list is also sorted alphabetically
             *          - the string occurs only once in any of the output lists
             *          - the list of lists contains all the strings in the input, but only once
             *          - does not contain duplicates or whitespace values
             *      - if the word does not have an anagram, it is still added as the only element  
             *      - does NOT use any NuGet packages or 3rd party libraries (only stuff that comes with .Net)
             *      - however, feel free to add methods or classes as you see fit
             *      
             *
             *
             *  example output:
             *
             *  given a list such as:  { "Kyoto", "London", "Portland", "Tokyo", "Wichita", "Donlon", "Anchorage" }
             *
             *  proper output should be:
             *
             *      Anchorage
             *      Donlon, London
             *      Kyoto, Tokyo
             *      Portland
             *      Wichita
             *
             *  improper output would be: 
             *      Kyoto, Tokyo
             *      London, Donlon
             *      Tokyo, Kyoto
             *      Wichita
             *      Donlon, London
             *      Anchorage
             *
             *  
             *  Example lists of anagrams are included in Resources.cs, but your code should work for ANY list of strings
             *
             *
             *
             *  Your code should be in the Output method below.
             *  
             *  You can do this challenge without using any 3rd party libraries - remember - we want to see YOUR work
             */


            foreach (var list in Output(Resource.SimpleList))
            {
                Console.WriteLine(string.Join(",", list));
            }

            Console.WriteLine("\r\n\r\nSimpleList complete.\r\n");

            foreach (var list in Output(Resource.HarderList))
            {
                Console.WriteLine(string.Join(",", list));
            }

            Console.WriteLine("\r\n\r\nHarderList complete.\r\n\r\n");

        }

        static IEnumerable<IEnumerable<string>> Output(IEnumerable<string> input1)
        {
            List<string> input = new List<string>();
            foreach (string sNew in input1)
            {
                if ((sNew + "") != "")
                    input.Add(sNew.Trim());
            };
            input.Sort();

            var output = new List<List<string>>();

            foreach (string sNew in input)
            {
                bool bFound = false;

                foreach (List<string> oList in output)
                {
                    if (AnagramsCompare(sNew, oList[0]))
                    {
                        bFound = true;

                        bool bSame = false;

                        foreach (string sOriginal in oList)
                        {
                            if (sOriginal == sNew)
                            {
                                bSame = true;
                                break;
                            }
                        }

                        if (!bSame) oList.Add(sNew);

                        break;
                    }
                }
                if (!bFound)
                {
                    var aa = new List<string>();
                    aa.Add(sNew);
                    output.Add(aa);
                }
            }
            return output;
        }

        private static bool AnagramsCompare(string firstString, string secondString)
        {
            if (secondString == null)
            {
                return false;
            }
            if (firstString.Length != secondString.Length)
            {
                return false;
            }
            //Convert string to character array  
            char[] firstCharsArray = firstString.ToLower().ToCharArray();
            char[] secondCharsArray = secondString.ToLower().ToCharArray();
            //Sort array  
            Array.Sort(firstCharsArray);
            Array.Sort(secondCharsArray);
            //Check each character and position.  
            for (int i = 0; i < firstCharsArray.Length; i++)
            {
                if (firstCharsArray[i].ToString() != secondCharsArray[i].ToString())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
