using System;
using System.Globalization;

namespace Income.Tax.Calculator;

    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Enter taxable income:");
            try
            {
                var income = Convert.ToInt32(Console.ReadLine());
                var incomeTaxCalculator = new IncomeTaxCalculator();
                var incomeTaxCalculated = incomeTaxCalculator.CalculateIncomeTax(income);
                Console.WriteLine(incomeTaxCalculated.ToString("C0", CultureInfo.CurrentCulture));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured calculating income tax: {ex.Message}");
            }
        }
    }
