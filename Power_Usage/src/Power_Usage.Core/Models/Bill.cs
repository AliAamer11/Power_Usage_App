
using Power_Usage.Core.Enums;

namespace Power_Usage.Core.Models;

public record Bill(BillingType BillingType, DateOnly StartAt, DateOnly EndAt, List<BillDetails> Breakdown)
{
    public decimal Total => Math.Round(Breakdown.Sum(x => x.Total), 2);
}
