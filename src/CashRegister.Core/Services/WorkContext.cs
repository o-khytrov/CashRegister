using CashRegister.Api.Models.Dfs.Responses.Entities;

namespace CashRegister.Models.Services;

public class WorkContext
{
    public WorkContext(BusinessUnit businessUnit, TransactionsRegistrarItem cashRegister, ulong nextLocalDocumentNumber)
    {
        BusinessUnit = businessUnit;
        CashRegister = cashRegister;
        NextLocalDocumentNumber = nextLocalDocumentNumber;
        Testing = false;
    }

    public bool Testing { get; set; } = true;

    public BusinessUnit BusinessUnit { get; }

    public TransactionsRegistrarItem CashRegister { get; }

    public ulong NextLocalDocumentNumber { get; }

    public string Cashier { get; set; }
}