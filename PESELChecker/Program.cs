using System;
using System.Text.RegularExpressions;

namespace PESELChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Bday bday = new Bday();
                PeselCorrectness peselCorrectness = new PeselCorrectness();
                GenderCorrectness genderCorrectness = new GenderCorrectness();

                Console.WriteLine("Enter your date of birth (DD/MM/YYYY)");
                int[] bdayArray = bday.BdayToArray(Console.ReadLine());

                Console.WriteLine("Enter your gender (F/M)");
                string gender = Console.ReadLine();
                genderCorrectness.GenderCorrectnessChecking(gender);

                Console.WriteLine("Enter your PESEL number");
                string pesel = Console.ReadLine();
                peselCorrectness.CorrectnessChecinkg(bdayArray, gender, pesel);
             } 
                catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }   
        }
    }
}
