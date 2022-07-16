﻿using System;

namespace _1.WarmUp.Easy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             
               Write code that meets the following requirements:
                   - loops through all integers from 1 to 100 and prints to the console according to the following rules
                       - where the integer is a multiple of 3, the console prints the word 'Sockeye'
                       - where the integer is a multiple of 5, the console prints the word 'Consulting' 
                       - where the integer is a multiple of both 3 and 5, the console prints the words 'Sockeye Consulting'
                       - otherwise the console simply prints the integer value
              
             
                   - example output:
             
                   1
                   2
                   Sockeye
                   4
                   Consulting

               Please do this work yourself - you should be able to do this easily without any 3rd party libraries
             
             */

            // YOUR CODE GOES HERE :)

            int t3 = 0;
            int t5 = 0;
            for (int i = 1; i <= 100; i++)
            {
                t3 = i % 3;
                t5 = i % 5;

                if (t3 == 0 && t5 == 0)
                {
                    Console.Write("Sockeye Consulting\r\n");
                }
                else if (t3 == 0)
                {
                    Console.Write("Sockeye\r\n");
                }
                else if (t5 == 0)
                {
                    Console.Write("Consulting\r\n");
                }
                else
                {
                    Console.Write(i.ToString() + "\r\n");
                }
            }

            Console.WriteLine("\r\n\r\nCompleted -- Press any key to quit");


            Console.ReadKey();
        }
    }
}
