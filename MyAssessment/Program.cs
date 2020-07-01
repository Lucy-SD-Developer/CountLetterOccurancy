using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssessment
{
    class Program
    {
        static int tableWidth = 120;

        static void Main(string[] args)
        {
            string inputString = "";
            foreach (string s in args)
            {
                inputString += s;
            }
            int[] inputChar = new int[26];
            string[] outputStr = new string[26];
            int count = 0;
            while (string.IsNullOrEmpty(inputString))
            {
                if (!string.IsNullOrEmpty(inputString))
                {
                    break;
                } else
                {
                    Console.WriteLine("Input can't be empty!");
                    inputString = Console.ReadLine().ToLower();
                }
            }

            string newString = RemoveSpecialCharacters(inputString);
            for (int i = 0; i < newString.Length; i++) {
                inputChar[newString[i] - 'a']++;
                count++;
            }

            // Print the value of the variable 
            PrintLine();
            PrintRow("A","B","C","D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z");
            PrintLine();
            
            for (int i = 0; i < 26; i++)
            {
                outputStr[i] = inputChar[i].ToString();
            }
            PrintRow(outputStr);
            PrintLine();
            Console.WriteLine("The text has been processed. Total letters counted: " + count);
        }

        static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

    }
}
