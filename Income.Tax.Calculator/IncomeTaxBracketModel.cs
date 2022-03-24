namespace Income.Tax.Calculator;

public class IncomeTaxBracketDetails
{
    public IncomeTaxBracketDetails(TaxBracketName name, int min, int max, decimal centsPerDollar, int baseTax)
    {
        Name = name;
        TaxBracketMin = min;
        TaxBracketMax = max;
        CentsPerDollar = centsPerDollar;
        BaseTax = baseTax;
    }

    public TaxBracketName Name { get; set; }
    public int TaxBracketMin { get; set; }
    public int TaxBracketMax { get; set; }
    public decimal CentsPerDollar { get; set; }
    public int BaseTax { get; set; }
}

public enum TaxBracketName
{
    TaxBracket1,
    TaxBracket2,
    TaxBracket3,
    TaxBracket4,
    TaxBracket5
};