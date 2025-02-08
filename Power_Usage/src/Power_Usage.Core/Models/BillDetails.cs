namespace Power_Usage.Core.Models;

public record BillDetails(string TierName, int Consumtion, decimal Rate, decimal Total)
{
}