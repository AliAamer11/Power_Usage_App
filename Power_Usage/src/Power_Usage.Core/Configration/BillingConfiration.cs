using Power_Usage.Core.Models;

namespace Power_Usage.Core.Configration;

public class BillingConfiration
{
    public static readonly List<Tier> ResidentTiers = [
        new Tier{Name = "Up to 160 kWh",UpperLimmitInKwh = 160,Rate=0.05m},
        new Tier{Name = "Up to 300 kWh",UpperLimmitInKwh = 300,Rate=0.10m},
        new Tier{Name = "Up to 500 kWh",UpperLimmitInKwh = 500,Rate=0.12m},
        new Tier{Name = "Up to 600 kWh",UpperLimmitInKwh = 600,Rate=0.16m},
        new Tier{Name = "Up to 750 kWh",UpperLimmitInKwh = 750,Rate=0.22m},
        new Tier{Name = "Up to 1000 kWh",UpperLimmitInKwh = 1000,Rate=0.27m},
        new Tier{Name = "Above 1000 kWh",UpperLimmitInKwh = int.MaxValue,Rate=0.37m},
        ];

    public static readonly List<Tier> CommercialTiers = [
        new Tier{Name = "Up to 200 kWh",UpperLimmitInKwh = 200,Rate=0.08m},
        new Tier{Name = "Up to 500 kWh",UpperLimmitInKwh = 500,Rate=0.15m},
        new Tier{Name = "Above to 500 kWh",UpperLimmitInKwh = int.MaxValue,Rate=0.25m},
 ];
}
