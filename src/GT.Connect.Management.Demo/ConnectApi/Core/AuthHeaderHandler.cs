using System.Net.Http.Headers;

namespace GT.Connect.Management.Demo.ConnectApi.Core;

public class AuthHeaderHandler : DelegatingHandler
{
    private readonly string _token;

    public AuthHeaderHandler(string token)
    {
        InnerHandler = new HttpClientHandler();
        _token = token;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}
