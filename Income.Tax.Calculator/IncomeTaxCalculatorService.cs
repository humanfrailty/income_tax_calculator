using System;
using System.Collections.Generic;
using System.Linq;

namespace Income.Tax.Calculator;

public class IncomeTaxCalculator
{
    public int CalculateIncomeTax(int income)
    {
        var taxAmount = 0;

        var taxBrackets = GetTaxBracketDetailsByYear("2021-22");
        
        var taxBracket1 = taxBrackets.First(b => b.Name == TaxBracketName.TaxBracket1);
        var taxBracket2 = taxBrackets.First(b => b.Name == TaxBracketName.TaxBracket2);
        var taxBracket3 = taxBrackets.First(b => b.Name == TaxBracketName.TaxBracket3);
        var taxBracket4 = taxBrackets.First(b => b.Name == TaxBracketName.TaxBracket4);
        var taxBracket5 = taxBrackets.First(b => b.Name == TaxBracketName.TaxBracket5);
        
        if ( income < taxBracket1.TaxBracketMax)
        {
            return taxAmount;
        }

        var taxBracketForCalculation = income < taxBracket2.TaxBracketMax ? taxBracket2 :
            income < taxBracket3.TaxBracketMax ? taxBracket3 :
            income < taxBracket4.TaxBracketMax ? taxBracket4 :
            taxBracket5;
            
        taxAmount = Calculation(income, taxBracketForCalculation);

        return taxAmount;
    }

    private int Calculation(int income, IncomeTaxBracketDetails taxBracket)
    {
        var tax = taxBracket.BaseTax + (income - taxBracket.TaxBracketMin) * taxBracket.CentsPerDollar/100;
        return Convert.ToInt32(tax);
    }
    
    private List<IncomeTaxBracketDetails> GetTaxBracketDetailsByYear(string taxYear)
    {
        if (taxYear.Equals("2021-22"))
        {
            return new List<IncomeTaxBracketDetails>
            {
                new (name: TaxBracketName.TaxBracket1, min: 0, max: 18200, centsPerDollar: 0, baseTax: 0),
                new (name: TaxBracketName.TaxBracket2, min: 18201, max: 45000, centsPerDollar: 19, baseTax: 0),
                new (name: TaxBracketName.TaxBracket3, min: 45001, max: 120000, centsPerDollar: (decimal)32.5, baseTax:5092),
                new (name: TaxBracketName.TaxBracket4, min: 120001, max: 180000, centsPerDollar: 37, baseTax: 29467),
                new (name: TaxBracketName.TaxBracket5, min: 180001, max: Int32.MaxValue, centsPerDollar: 45, baseTax: 51667)
            };
        }
        throw new Exception(message:"Tax year not implemented");
    }
}

