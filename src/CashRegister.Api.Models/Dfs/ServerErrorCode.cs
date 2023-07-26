namespace CashRegister.Api.Models.Dfs;

public enum ServerErrorCode
{
    Ok,

    TransactionsRegistrarAbsent,

    OperatorAccessToTransactionsRegistrarNotGranted,

    InvalidTin,

    ShiftAlreadyOpened,

    ShiftNotOpened,

    LastDocumentMustBeZRep,

    CheckLocalNumberInvalid,

    ZRepAlreadyRegistered,

    DocumentValidationError,

    PackageValidationError,

    InvalidQueryParameter,

    CryptographyError
}