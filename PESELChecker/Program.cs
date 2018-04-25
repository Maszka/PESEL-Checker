using System;
using System.Text.RegularExpressions;
using System.IO;

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
                bool continuePeselChecking = true;

                do
                {
                    Console.WriteLine("Enter the option. M for manual and F for file");
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToLower())
                    {
                        case "m":
                            Console.WriteLine("Enter your date of birth (DD/MM/YYYY)");
                            int[] bdayArray = bday.BdayToArray(Console.ReadLine());

                            Console.WriteLine("Enter your gender (F/M)");
                            string gender = Console.ReadLine();
                            genderCorrectness.GenderCorrectnessChecking(gender);

                            Console.WriteLine("Enter your PESEL number");
                            string pesel = Console.ReadLine();
                            Console.WriteLine(peselCorrectness.CorrectnessChecinkg(bdayArray, gender, pesel));
                            break;

                        case "f":
                            PeselCorrectnessFromFile.CorrectnessCheckingFromFile();
                            Console.WriteLine("File updated");
                            break;

                        default:
                            Console.WriteLine("Error!");
                            break;
                    }
                    Console.WriteLine("Do you want to continue? Y/N");
                    string decision = Console.ReadLine();

                    if (decision.ToLower() == "n")
                    {
                        continuePeselChecking = false;
                    }

                } while (continuePeselChecking);


             } 
                catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }   
        }
    }
}
