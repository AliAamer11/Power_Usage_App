using FluentAssertions;
using Power_Usage.Core.Enums;
using Power_Usage.Core.Models;
using Power_Usage.Core.Service;

namespace Power_Usage.Core.Test;
public class BillingCalculatorTests
{
    private static readonly DateOnly DefaultStartDate = new(2024, 1, 1);
    private static readonly DateOnly DefaultEndDate = new(2024, 1, 31);

    [Theory]
    [InlineData(-1)]
    public void CalculateResidentialCost_ShouldThrowExceptionForInvalidConsumptionValue(int consumtion)
    {
        Action act = () => BillingCalculator.CalculateResidentialBill(consumtion, DefaultStartDate, DefaultEndDate);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData("2024-01-31", "2024-01-01")]
    public void CalculateResidentialCost_ShouldThrowArgumentInvalidRangeExceptionForInvalidDateRane(string startAt, string endAt)
    {
        var startDate = DateOnly.Parse(startAt);
        var endDate = DateOnly.Parse(endAt);
        Action act = () => BillingCalculator.CalculateResidentialBill(100, startDate, endDate);

        act.Should().Throw<ArgumentException>();
    }


    [Theory]
    [InlineData(-1)]
    public void CalculateCommercialCost_ShouldThrowExceptionForInvalidConsumptionValue(int consumtion)
    {
        Action act = () => BillingCalculator.CalculateCommercialBill(consumtion, DefaultStartDate, DefaultEndDate);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData("2024-01-31", "2024-01-01")]
    public void CalculateCommercialCost_ShouldThrowArgumentInvalidRangeExceptionForInvalidDateRane(string startAt, string endAt)
    {
        var startDate = DateOnly.Parse(startAt);
        var endDate = DateOnly.Parse(endAt);
        Action act = () => BillingCalculator.CalculateCommercialBill(100, startDate, endDate);

        act.Should().Throw<ArgumentException>();
    }
    [Theory]
    [MemberData(nameof(GetValidateResidentialBillingData))]
    public void CalculateResidentialCost_ShouldReturnExpectedValue(int consumtion, Bill expected)
    {
        var result = BillingCalculator.CalculateResidentialBill(consumtion, DefaultStartDate, DefaultEndDate);
        result.Should().BeEquivalentTo(expected);
    }


    [Theory]
    [MemberData(nameof(GetValidateCommercialBillingData))]
    public void CalculateCommercialCost_ShouldReturnExcpectedValue(int consumtion, Bill expected)
    {
        var result = BillingCalculator.CalculateCommercialBill(consumtion, DefaultStartDate, DefaultEndDate);
        result.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> GetValidateCommercialBillingData() =>
        new List<object[]>
        {
            new object[] {
                0,
                new Bill(
                    BillingType: BillingType.Commerial,
                    StartAt: DefaultStartDate,
                    EndAt: DefaultEndDate,
                    Breakdown: []
                )
            },
            new object[] {
                50,
                new Bill(
                    BillingType: BillingType.Commerial,
                    StartAt: DefaultStartDate,
                    EndAt: DefaultEndDate,
                    Breakdown: new List<BillDetails> {
                        new BillDetails("Up to 200 kWh", 50, 0.08m, 4.00m)
                    }
                )
            },
            new object[] {
                160,
                new Bill(
                    BillingType: BillingType.Commerial,
                    StartAt: DefaultStartDate,
                    EndAt: DefaultEndDate,
                    Breakdown: new List<BillDetails> {
                        new BillDetails("Up to 200 kWh", 160, 0.08M, 12.80M)
                    }
                )
            },
        };
    public static IEnumerable<object[]> GetValidateResidentialBillingData() =>
        new List<object[]>
        {
            new object[] {
                0,
                new Bill(
                    BillingType: BillingType.Residential,
                    StartAt: DefaultStartDate,
                    EndAt: DefaultEndDate,
                    Breakdown: []
                )
            },
            new object[] {
                50,
                new Bill(
                    BillingType: BillingType.Residential,
                    StartAt: DefaultStartDate,
                    EndAt: DefaultEndDate,
                    Breakdown: new List<BillDetails> {
                        new BillDetails("Up to 160 kWh", 50, 0.05m, 2.50m)
                    }
                )
            },
            new object[] {
                160,
                new Bill(
                    BillingType: BillingType.Residential,
                    StartAt: DefaultStartDate,
                    EndAt: DefaultEndDate,
                    Breakdown: new List<BillDetails> {
                        new BillDetails("Up to 160 kWh", 160, 0.05m, 8.00m)
                    }
                )
            },
        };
}