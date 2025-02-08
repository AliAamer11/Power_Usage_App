using Power_Usage.Core.Configration;
using Power_Usage.Core.Enums;
using Power_Usage.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Usage.Core.Service
{
    public static class BreakdownClaculator
    {
        public static List<BillDetails> Calculate(int consumptionInKWh, List<Tier> tiers)
        {
            if (consumptionInKWh == 0)
            {
                return [];
            }
            List<BillDetails> breakdown = [];
            int prevoisUpperLimit = 0;
            int remainingConsumption = consumptionInKWh;
            foreach (var tier in tiers)
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
            return breakdown;
        }
    }
}
