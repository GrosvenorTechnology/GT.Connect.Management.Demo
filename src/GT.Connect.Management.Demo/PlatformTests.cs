using GT.Connect.Management.Demo.ConnectApi.Platform;

namespace GT.Connect.Management.Demo;

[TestClass]
public class PlatformTests
{
    [TestMethod]
    public async Task GetAccessToken()
    {
        var authApi = RestService.For<IConnectApi>(
            new HttpClient()
            {
                BaseAddress = new Uri(Settings.GtConnectUrl)
            });

        var response = await authApi.GetAccessToken(Settings.TenantId, Settings.TokenRequest);

        Assert.AreEqual("Bearer", response.Token_Type);
    }

}
