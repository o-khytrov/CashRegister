using CashRegister.Api.Models.Dfs.Enums;
using CashRegister.Api.Models.Dfs.Responses.Enums;

namespace CashRegister.Api.Models.Dfs.Responses;

public class DocumentInfoByLocalNumberResponse
{
    public string NumFiscal { get; set; }

    public EDfsDocumentType Doc { get; set; }

    public EDfsCheckDocumentType CheckDocumentType { get; set; }

    public bool Revoked { get; set; }
}