using System;
namespace PESELChecker
{
    public class GenderCorrectness
    {
        public void GenderCorrectnessChecking(string argGender)
        {
            if (argGender.ToLower() != "f" && argGender.ToLower() != "m")
            {
                throw new ArgumentException("Gender is not in correct format. Enter F or M.");
            }
        }
    }
}
