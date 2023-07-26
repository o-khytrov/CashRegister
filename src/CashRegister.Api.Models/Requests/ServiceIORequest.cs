namespace CashRegister.Api.Models.Requests;

public class ServiceIoRequest
{
    public ulong CashRegisterId { get; set; }

    public decimal Amount { get; set; }
}

public record CashRegisterRequest(ulong CashRegisterId);