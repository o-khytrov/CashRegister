namespace CashRegister.Uapki.Requests;

public interface IStorageOpenParameters
{
    string Provider { get; }

    string? Storage { get; set; }

    StorageOpenMode OpenMode { get; set; }
}