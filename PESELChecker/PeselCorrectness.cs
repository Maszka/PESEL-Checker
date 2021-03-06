﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PESELChecker
{
    public class PeselCorrectness
    {
        public string CorrectnessChecinkg(int[] argBdayArray, string argGender, string argPesel)
        {
            bool _bdayComparing = BdayComparing(argBdayArray, argPesel);
            bool _genderChecking = GenderChecing(argGender, argPesel);
            bool _controlNumberChecking = ControlNumberChecking(argPesel);
            string result = "";

            if (!_bdayComparing)
            {
                result += "PESEL incorrect. Birthday date comparison failed;";
            }
            if (!_genderChecking)
            {
                result += "PESEL incorrect. Gender comparison failed;";
            }
            if (!_controlNumberChecking)
            {
                result += "PESEL incorrect. Control number is wrong;";
            }
            if (_bdayComparing&&_genderChecking&&_controlNumberChecking)
            {
                result += "PESEL correct!;";
            }

            return result;

            }

            private static int[] PeselConverter(string argPesel)
            {
                var peselNum = argPesel.Select(x => new string(x, 1)).ToArray();
                int[] peselConverted = new int[11];

                for (int i = 0; i < peselConverted.Length; i++)
                {
                    if (!int.TryParse(peselNum[i], out peselConverted[i]))
                    {
                        throw new ArgumentException("Provide numeric value of PESEL");
                    }
                    if (peselNum.Length < 11 || peselNum.Length > 11)
                    {
                        throw new ArgumentException("Wrong length of the PESEL");
                    }
                }
                return peselConverted;
            }

            private static bool BdayComparing(int[] argBdayArray, string argPesel)
            {

                int[] peselConverted = PeselConverter(argPesel);
                bool z = true;

                for (int i = 0; i < 6; i++)
                {
                    if (argBdayArray[i] != peselConverted[i])
                        z = false;
                }
                return z;

            }

            private static bool GenderChecing(string argGender, string argPesel)
            {
                int[] peselConverted = PeselConverter(argPesel);
                bool z = true;

                if (peselConverted[9] % 2 == 0 && argGender.ToLower() != "f")
                {
                    z = false;
                }
                else if (peselConverted[9] % 2 != 0 && argGender.ToLower() != "m")
                {
                    z = false;
                }


                return z;
            }

            private static bool ControlNumberChecking(string argPesel)
            {

                int[] peselConverted = PeselConverter(argPesel);
                bool z = true;
                int controlNumber;

                int cn = 9 * peselConverted[0] + 7 * peselConverted[1] + 3 * peselConverted[2] + peselConverted[3] + 9 * peselConverted[4] + 7 * peselConverted[5] + 3 * peselConverted[6] + peselConverted[7] + 9 * peselConverted[8] + 7 * peselConverted[9];

                controlNumber = cn % 10;

                if (controlNumber != peselConverted[10])
                    z = false;

                return z;
            }

        }
    }

