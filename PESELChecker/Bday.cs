using System;
namespace PESELChecker
{
    public class Bday
    {
        public int[] BdayToArray(string input)
        {
            char[] delimiterChars = { '.', '/', '-' };
            string[] dateOriginal = input.Split(delimiterChars);
            int[] digits = new int[8];
            int x = 0;
            for (int i = 0; i < dateOriginal.Length; i++)
            {
                foreach (char c in dateOriginal[i])
                {
                    digits[x] = CharExtensions.CharToInt(c);
                    x++;
                }
            }

            return digits;
        }
    }
}
