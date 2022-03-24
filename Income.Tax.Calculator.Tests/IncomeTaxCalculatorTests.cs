using System;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace Income.Tax.Calculator.Tests;

public class IncomeTaxCalculatorTests
{
    private readonly IncomeTaxCalculator _subject;

    private int _income;
    private int _tax;
    private Exception? _recordedException;

    public IncomeTaxCalculatorTests()
    {
        _subject = new IncomeTaxCalculator();
    }
    
    [Theory]
    [InlineData(15000,0)]
    [InlineData(25000,1292)]
    [InlineData(35000,3192)]
    [InlineData(45000,5092)]
    [InlineData(65456,11740.20)]
    [InlineData(100000,22967)]
    [InlineData(120000,29467)]
    [InlineData(135322,35136.14)]
    [InlineData(179000,51297)]
    [InlineData(180761,52009.45)]
    [InlineData(384525,143703.25)]
    public void ItShouldCalculateIncomeTaxCorrectly(int income, int expectedTax)
    {
        this.Given(x => GivenIncome(income))
            .When(x => WhenCalculateIncomeTaxIsCalled())
            .Then(x => ThenTheTaxCalculationShouldBe(expectedTax))
            .And(x => ThenThereShouldBeNoException())
            .BDDfy();
    }
    
    private void GivenIncome(int income)
    {
        _income = income;
    }
    
    private void GivenInvalidIncome(int income)
    {
        _income = income;
    }

    private void WhenCalculateIncomeTaxIsCalled()
    {
        try
        {
            _tax = _subject.CalculateIncomeTax(_income);
        }
        catch (Exception e)
        {
            _recordedException = e;
        }
    }
    
    private void ThenTheTaxCalculationShouldBe(int expectedTax)
    {
        _tax.ShouldBe(expectedTax);
    }
    
    private void ThenThereShouldBeNoException()
    {
        _recordedException.ShouldBeNull();
    }
}

