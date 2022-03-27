namespace EVoucherManagementSystem.Communication;

using EVoucherManagementSystem.Models;
public class AuthenticationResponse
{
    public AuthenticateUsers user { get; set; }
    public string accessToken { get; set; }
}
public class AuthenticateUsers
{
    public string id { get; set; }
    public string userName { get; set; }
    public string phoneNo { get; set; }
}

