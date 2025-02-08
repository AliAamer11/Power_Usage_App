using Power_Usage.Core.Configration;
using Power_Usage.Core.Enums;
using Power_Usage.Core.Models;

namespace Power_Usage.Core.Service;

public static class BillingCalculator
{
    public static Bill CalculateResidentialBill(int consumptionInKWh, DateOnly startAt, DateOnly endAt)
    {
        // handle parameters
        ArgumentOutOfRangeException.ThrowIfNegative(consumptionInKWh,
            nameof(consumptionInKWh));

        if (startAt > endAt)
        {
            throw new ArgumentException("the start date must not be after the end at",
                nameof(startAt));
        }

        if (consumptionInKWh == 0)
        {
            return new Bill(BillingType.Residential, startAt, endAt, []);
        }

        List<BillDetails> breakdown = [];
        int prevoisUpperLimit = 0;
        int remainingConsumption = consumptionInKWh;
        foreach (var tier in BillingConfiration.ResidentTiers)
        {
            int tierCapacity = tier.UpperLimmitInKwh - prevoisUpperLimit;
            int tierConsumption = Math.Min(remainingConsumption, tierCapacity);
            if (tierConsumption <= 0) break;

            breakdown.Add(new BillDetails
            (
                TierName: tier.Name,
                Consumtion: tierConsumption,
                Rate: tier.Rate,
                Total: tierConsumption * tier.Rate
            ));

            remainingConsumption -= tierConsumption;
            prevoisUpperLimit = tier.UpperLimmitInKwh;
        }
        return new Bill(BillingType.Residential, startAt, endAt, breakdown);

    }


    public static Bill CalculateCommercialBill(int consumptionInKWh, DateOnly startAt, DateOnly endAt)
    {
        // handle parameters
        ArgumentOutOfRangeException.ThrowIfNegative(consumptionInKWh,
            nameof(consumptionInKWh));

        if (startAt > endAt)
        {
            throw new ArgumentException("the start date must not be after the end at",
                nameof(startAt));
        }

        if (consumptionInKWh == 0)
        {
            return new Bill(BillingType.Commerial, startAt, endAt, []);
        }

        List<BillDetails> breakdown = [];
        int prevoisUpperLimit = 0;
        int remainingConsumption = consumptionInKWh;
        foreach (var tier in BillingConfiration.CommercialTiers)
        {
            int tierCapacity = tier.UpperLimmitInKwh - prevoisUpperLimit;
            int tierConsumption = Math.Min(remainingConsumption, tierCapacity);
            if (tierConsumption <= 0) break;

            breakdown.Add(new BillDetails
            (
                TierName: tier.Name,
                Consumtion: tierConsumption,
                Rate: tier.Rate,
                Total: tierConsumption * tier.Rate
            ));

            remainingConsumption -= tierConsumption;
            prevoisUpperLimit = tier.UpperLimmitInKwh;
        }
        return new Bill(BillingType.Commerial, startAt, endAt, breakdown);

    }
}
