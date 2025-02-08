using Power_Usage.Core.Configration;
using Power_Usage.Core.Enums;
using Power_Usage.Core.Models;

namespace Power_Usage.Core.Service;

public static class BillingCalculator
{
    public static Bill CalculateResidentialBill(int consumptionInKWh, DateOnly startAt, DateOnly endAt)
    {
        // handle parameters
        BillingCalculatorHelpers.ValidateBillValues(consumptionInKWh, startAt, endAt);
        var breakdown = BreakdownClaculator.Calculate(consumptionInKWh, BillingConfiration.ResidentTiers);
        return new Bill(BillingType.Residential, startAt, endAt, breakdown);
    }


    public static Bill CalculateCommercialBill(int consumptionInKWh, DateOnly startAt, DateOnly endAt)
    {
        // handle parameters
        BillingCalculatorHelpers.ValidateBillValues(consumptionInKWh, startAt, endAt);
        var breakdown = BreakdownClaculator.Calculate(consumptionInKWh, BillingConfiration.CommercialTiers);
        return new Bill(BillingType.Commerial, startAt, endAt, breakdown);

    }
}
