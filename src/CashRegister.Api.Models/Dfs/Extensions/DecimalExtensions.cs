namespace CashRegister.Api.Models.Dfs.Extensions;

public static class DecimalExtensions
{
    public static decimal Round2(this decimal val)
    {
        return Math.Round(val, 2, MidpointRounding.AwayFromZero);
    }

    public static decimal Round3(this decimal val)
    {
        return Math.Round(val, 3, MidpointRounding.AwayFromZero);
    }
}