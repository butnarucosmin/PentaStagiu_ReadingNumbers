using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ReadingNumbers
{
    class Program
    {        
        static void FileReader_Numbers()
        {
            try
            {
                var file = File.ReadAllText("numbers.txt");

                string[] correctNumbers = Regex.Split(file, @"\D+");
                string incorrectNumbers = Regex.Replace(file, @"[\d-]", string.Empty);

                var numbersList = new List<int>();

                File.WriteAllText("correctNumbers.txt", "");

                foreach (var c in correctNumbers)
                {
                    if (!string.IsNullOrEmpty(c))
                    {
                        File.AppendAllText("correctNumbers.txt", c + " ");
                        numbersList.Add(Convert.ToInt32(c));
                    }
                }
                File.WriteAllText("incorrectNumbers.txt", incorrectNumbers); 
                
                foreach(var value in numbersList)
                {
                    Console.WriteLine(value);
                }
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine("File is missing!\n {0}", ex);
            }
        }

        static void FileReader_Digits()
        {
            try
            {
                var file = File.ReadAllText("numbers.txt");
                var digitsList = new List<char>();

                foreach (var c in file)
                {
                    if (char.IsDigit(c))
                    {
                        File.AppendAllText("correctNumbers.txt", c + " ");
                        digitsList.Add(c);
                    }

                    else
                    {
                        File.AppendAllText("incorrectNumbers.txt", c.ToString());
                    }
                }

                foreach(var value in digitsList)
                {
                    Console.WriteLine(value);
                }
            }
            catch (FileNotFoundException ex)
            {
                System.Console.WriteLine("File is missing!\n {0}", ex);
            }
        }

        static void Main(string[] args)
        {
            FileReader_Numbers();
            Console.WriteLine();
            FileReader_Digits();
        }
    }
}