using System;

namespace YearApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();

            // Get 2 digit year input
            Console.WriteLine("Please enter the last 2 digits of your graduation year:");
            string tdyInput = Console.ReadLine();
            int tdy;
            while (!int.TryParse(tdyInput, out tdy))
            {
                Console.Error.WriteLine($"Invalid input: {tdyInput}");
                Console.WriteLine("Please enter the last 2 digits of your graduation year:");
                tdyInput = Console.ReadLine();
            }

            // Get current year input
            Console.WriteLine("Please enter your current year (default to current system year if leave empty):");
            string cyInput = Console.ReadLine();
            int cy;
            if (string.IsNullOrWhiteSpace(cyInput) || !int.TryParse(cyInput, out cy))
            {
                cy = DateTime.Now.Year;
                Console.WriteLine($"Invalid or empty input detected. Defaulting to current system year: {cy}.");
            }

            // Calculate and output full-digit year
            int fdy = program.GetYear(tdy, cy);
            Console.WriteLine($"The full digits of your graduation year is {fdy}.\n");

            // ====================== Test Cases (uncomment to run) ==========================
            // Normal Cases
            /*
            Console.WriteLine(program.GetYear(07, 2015));  // Current century, returns 2007
            Console.WriteLine(program.GetYear(18, 2015));  // Current century, returns 2018
            Console.WriteLine(program.GetYear(07, 1998));  // Next century, returns 2007
            Console.WriteLine(program.GetYear(97, 2001));  // Previous century, returns 1997
            */
            // Edge Cases
            /*
            Console.WriteLine(program.GetYear(10, 2000));  // On the edge, returns 2010
            Console.WriteLine(program.GetYear(11, 2000));  // Out-of-bound, returns -1
            Console.WriteLine(program.GetYear(50, 2000));  // On the edge, returns 1950
            Console.WriteLine(program.GetYear(49, 2000));  // Out-of-bound, returns -1
            Console.WriteLine(program.GetYear(123, 2017)); // Bad 2-digit year, returns -1
            Console.WriteLine(program.GetYear(-10, 2017)); // Bad 2-digit year, returns -1
            */
            // ===============================================================================
        }

        /// <summary>
        /// Get the full-digit year based on 2-digit year
        /// </summary>
        /// <param name="twoDigitYear">The 2-digit year</param>
        /// <param name="currentYear">The current year (full-digit)</param>
        /// <returns>The corresponding full-digit year; -1 if out of range</returns>
        private int GetYear(int twoDigitYear, int currentYear)
        {
            // Out of range - return -1 directly
            if (twoDigitYear > 99 || twoDigitYear < 0) { return -1; }

            // Calculate the upper and lower bounds from current year
            int lowerBound = currentYear - 50;
            int upperBound = currentYear + 10;

            // Get the first 2 digits of the current year
            int currentYearFirstTwoDigit = currentYear / 100;
            // Calculate the 3 full-digit year possibilities
            int fourDigitYear1 = currentYearFirstTwoDigit * 100 + twoDigitYear;
            int fourDigitYear2 = (currentYearFirstTwoDigit - 1) * 100 + twoDigitYear;
            int fourDigitYear3 = (currentYearFirstTwoDigit + 1) * 100 + twoDigitYear;

            // Test if any of the 3 possibilities are within the range
            if (fourDigitYear1 >= lowerBound && fourDigitYear1 <= upperBound)
            {
                return fourDigitYear1;
            }
            else if (fourDigitYear2 >= lowerBound && fourDigitYear2 <= upperBound)
            {
                return fourDigitYear2;
            }
            else if (fourDigitYear3 >= lowerBound && fourDigitYear3 <= upperBound)
            {
                return fourDigitYear3;
            }
            return -1;
        }
    }
}
