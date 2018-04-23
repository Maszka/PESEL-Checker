using System;
using System.Globalization;

namespace PESELChecker
{
    public class Bday
    {
        public int[] BdayToArray(string argInput)
        {
            int[] orderedDigits = new int[6];
            try
            {
                var plCulture = CultureInfo.CreateSpecificCulture("pl-PL");
                var bDate = DateTime.Parse(argInput, plCulture);
                char[] delimiterChars = { '.', '/', '-' };
                string[] dateOriginal = argInput.Split(delimiterChars);
                int[] digits = new int[8];
                int x = 0;

                if (bDate.Year > 1999)
                {
                    dateOriginal[1] = (int.Parse(dateOriginal[1]) + 20).ToString();
                }
                else if (bDate.Year < 1900 && bDate.Year >= 1800)
                {
                    dateOriginal[1] = (int.Parse(dateOriginal[1]) + 80).ToString();
                }

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
            }

            catch (FormatException)
            {
                throw new FormatException("Birdthday format not correct.");
            }

            return orderedDigits;

        }
    }
}
