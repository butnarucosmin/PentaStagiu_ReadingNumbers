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

                File.WriteAllText("correctNumbers.txt", "");

                foreach (var c in correctNumbers)
                {
                    if (!string.IsNullOrEmpty(c))
                    {
                        File.AppendAllText("correctNumbers.txt", c + " ");
                    }
                }
                File.WriteAllText("incorrectNumbers.txt", incorrectNumbers);                
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

                foreach (var c in file)
                {
                    if (char.IsDigit(c))
                    {
                        File.AppendAllText("correctNumbers.txt", c + " ");
                    }

                    else
                    {
                        File.AppendAllText("incorrectNumbers.txt", c.ToString());
                    }
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
            FileReader_Digits();
        }
    }
}