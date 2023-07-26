namespace CashRegister.Models.Services;

public interface IAvailabilityService
{
    public bool IsAvailable { get; }

    public void SetAvailability(bool isAvailable);
}

public class AvailabilityService : IAvailabilityService
{
    private bool _isAvailable = true;

    private bool isDfsAvailabe()
    {
        return _isAvailable;
    }

    public bool IsAvailable => isDfsAvailabe();

    public void SetAvailability(bool isAvailable)
    {
        _isAvailable = isAvailable;
    }
}