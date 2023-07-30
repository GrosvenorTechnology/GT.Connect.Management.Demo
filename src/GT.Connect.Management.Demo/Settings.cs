using GT.Connect.Management.Demo.ConnectApi.Platform;

namespace GT.Connect.Management.Demo;

internal static class Settings
{
    internal static string GtConnectUrl => "https://api.gtconnectedservices.com";
    internal static Guid TenantId => new("<TENANT ID GOES HERE>");
    internal static TokenRequest TokenRequest => new(
            "username goes here",
            "password goes here",
            "client_Id goes here",
            "client_secret goes here",
            "grant_type goes here");
}
