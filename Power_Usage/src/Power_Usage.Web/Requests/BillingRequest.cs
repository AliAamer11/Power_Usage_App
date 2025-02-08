using Power_Usage.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Power_Usage.Web.Requests;
public class BillingRequest
{
    [Range(0, int.MaxValue, ErrorMessage = "Consumption must be a non-negative value.")]
    public int Consumption { get; set; }

    public DateOnly StartAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly EndAt { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddMonths(1));

    public BillingType BillingType { get; set; }
}
