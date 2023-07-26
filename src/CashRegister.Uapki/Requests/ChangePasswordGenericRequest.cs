namespace CashRegister.Uapki.Requests;

internal class ChangePasswordGenericRequest : BaseGenericRequest<ChangePasswordParameters>
{
    private const string MethodName = "CREATE_KEY";

    public ChangePasswordGenericRequest(string oldPassword, string newPassword)
        : base(MethodName)
    {
        Parameters = new ChangePasswordParameters
        {
            OldPassword = oldPassword,
            NewPassword = newPassword
        };
    }
}