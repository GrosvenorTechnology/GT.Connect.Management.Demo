namespace GT.Connect.Management.Demo.ConnectApi.Platform;

public interface IConnectApiPlatform
{
    [Post("/api/tenants/{tenantId}/auth/token")]
    Task<TokenResponse> GetAccessToken(Guid tenantId, [Body] TokenRequest request);
}




