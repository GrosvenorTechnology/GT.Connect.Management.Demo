namespace GT.Connect.Management.Demo.Core;

public class ApiTestBase
{
    protected async Task<IConnectApi> GetClient()
    {
        var authApi = RestService.For<IConnectApi>(
            new HttpClient()
            {
                BaseAddress = new Uri(Settings.GtConnectUrl)
            });

        var tokenResponse = await authApi.GetAccessToken(Settings.TenantId, Settings.TokenRequest);

        //You should cache the token at this point, this is not done here to keep the example simple
        Assert.AreEqual("Bearer", tokenResponse.Token_Type);

        return RestService.For<IConnectApi>(
            new HttpClient(new AuthHeaderHandler(tokenResponse.Access_Token))
            {
                BaseAddress = new Uri(Settings.GtConnectUrl)
            });
    }
}
