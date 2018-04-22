using System;
namespace PESELChecker
{
    public static class CharExtensions
    {
        public static int CharToInt(this char c)
        {
            if (c < '0' || c > '9')
            {
                throw new ArgumentException("Wrong format of birthday date");
            }

            return c - '0';
          
        }
    }
}
