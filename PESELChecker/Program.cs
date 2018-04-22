using System;
using System.Text.RegularExpressions;

namespace PESELChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            // ask user for 3 inputs: B-day, gender, PESEL
            // parameters that should be checked: 
            // - length
            // - numeric values
            // - gender
            // - correct B-day encoding
            // - cyfra kontrolna
            // catch exceptions: no numeric values in PESEL, birthday before and after some date, gender not in correct format

            try
            {
                Bday bday = new Bday();
                PeselCorrectness correctness = new PeselCorrectness();


                Console.WriteLine("Enter your date of birth (DD/MM/YYYY)");
                int[] bdayArray = bday.BdayToArray(Console.ReadLine());

                Console.WriteLine("Enter your gender (F/M)");
                string gender = Console.ReadLine();

                Console.WriteLine("Enter your PESEL number");
                string pesel = Console.ReadLine();
                correctness.CorrectnessChecinkg(bdayArray, gender, pesel);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
