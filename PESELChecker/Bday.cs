using System;
namespace PESELChecker
{
    public class Bday
    {
        public int[] BdayToArray(string argInput)
        {
            char[] delimiterChars = { '.', '/', '-' };
            string[] dateOriginal = argInput.Split(delimiterChars);
            int[] digits = new int[8];
            int[] orderedDigits = new int[6];
            int x = 0;
            for (int i = 0; i < dateOriginal.Length; i++)
            {
                foreach (char c in dateOriginal[i])
                {
                    digits[x] = CharExtensions.CharToInt(c);
                    x++;
                }
            }

            orderedDigits[0] = digits[6];
            orderedDigits[1] = digits[7];
            orderedDigits[2] = digits[2];
            orderedDigits[3] = digits[3];
            orderedDigits[4] = digits[0];
            orderedDigits[5] = digits[1];

            return orderedDigits;
        }
    }
}
