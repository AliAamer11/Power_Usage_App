public static class BillingCalculatorHelpers
{
    public static void ValidateBillValues(int consumptionInKWh, DateOnly startAt, DateOnly endAt)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(consumptionInKWh,
            nameof(consumptionInKWh));

        if (startAt > endAt)
        {
            throw new ArgumentException("the start date must not be after the end at",
                nameof(startAt));
        }
    }
}