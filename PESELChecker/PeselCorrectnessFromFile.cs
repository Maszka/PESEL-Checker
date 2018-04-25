using System;
using System.IO;

namespace PESELChecker
{
    public class PeselCorrectnessFromFile
    {
        public static void CorrectnessCheckingFromFile()
        {

            Bday bday = new Bday();
            PeselCorrectness peselCorrectness = new PeselCorrectness();
            GenderCorrectness genderCorrectness = new GenderCorrectness();

            string currentLine;
            string[] separatedData = new string[3];
            int[] bdayArrayFile = new int[6];
            string genderFile;
            string peselFile;
            string result;

            using (var w = new StreamWriter("PESELListChecked.csv"))
            {
                using (StreamReader sr = new StreamReader("PESELListToCheck.csv"))
                {

                    // currentLine will be null when the StreamReader reaches the end of file
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(currentLine); 
                        separatedData = currentLine.Split(";");
                        bdayArrayFile = bday.BdayToArray(separatedData[1]);
                        genderFile = separatedData[2];
                        peselFile = separatedData[0];
                        genderCorrectness.GenderCorrectnessChecking(genderFile);
                        result = peselCorrectness.CorrectnessChecinkg(bdayArrayFile, genderFile, peselFile);

                        var line = string.Format("{0};{1}", currentLine, result);
                        w.WriteLine(line);
                        w.Flush();

                    }

                }

            }
        }
    }
}
