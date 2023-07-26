namespace CashRegister.Uapki.Requests;

internal class GetCsrGenericRequest : BaseGenericRequest<GetCsrParameters>
{
    private const string MethodName = "GET_CSR";

    public GetCsrGenericRequest(string? signAlgorithm = null)
        : base(MethodName)
    {
        Parameters = new GetCsrParameters
        {
            SignAlgorithm = signAlgorithm
        };
    }
}