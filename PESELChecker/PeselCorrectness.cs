using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PESELChecker
{
    public class PeselCorrectness
    {
        public void CorrectnessChecinkg(int[] argBdayArray, string argGender, string argPesel)
        {
            bool z = true;
            int controlNumber;
            //int[] bdayInPesel = new int[6];

            //string[] peselNum = Regex.Split(argPesel, string.Empty);
            var peselNum = argPesel.Select(x => new string(x, 1)).ToArray();
            int[] peselConverted = new int[11];

            for (int i = 0; i < peselConverted.Length; i++)
            {
                if (!int.TryParse(peselNum[i], out peselConverted[i]))
                {
                    throw new ArgumentException("Provide numeric value of PESEL");
                }
            }

            for (int i = 0; i < 6; i++)
            {
                if (argBdayArray[i] != peselConverted[i])
                    z = false;
            }


            if (peselConverted[9] % 2 == 0 && argGender.ToLower() != "f")
            {
                z = false;
            }
            else if (peselConverted[9] % 2 != 0 && argGender.ToLower() != "m")
            {
                z = false;
            }

            //9×a + 7×b + 3×c + 1×d + 9×e + 7×f + 3×g + 1×h + 9×i + 7×j

            int cn = 9 * peselConverted[0] + 7 * peselConverted[1] + 3 * peselConverted[2] + peselConverted[3] + 9 * peselConverted[4] + 7 * peselConverted[5] + 3 * peselConverted[6] + peselConverted[7] + 9 * peselConverted[8] + 7 * peselConverted[9];

            controlNumber = cn % 10;

            if (controlNumber != peselConverted[10])
                z = false;


            if(z){
                Console.WriteLine("PESEL correct");
            }
            else{
                Console.WriteLine("PESEL incorrect");
            }

        }

    }
}
