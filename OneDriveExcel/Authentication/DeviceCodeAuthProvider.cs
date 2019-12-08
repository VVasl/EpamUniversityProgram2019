namespace OneDriveExcel
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.Graph;
    using Microsoft.Identity.Client;

    public class DeviceCodeAuthProvider : IAuthenticationProvider
    {
        private IPublicClientApplication _msalClient;
        private string[] _scopes;
        private IAccount _userAccount;

        public DeviceCodeAuthProvider(string appId, string[] scopes)
        {
            _scopes = scopes;

            _msalClient = PublicClientApplicationBuilder
                .Create(appId)
                .WithTenantId("organizations")
                .Build();
        }

        public async Task<string> GetAccessToken()
        {
            if (_userAccount == null)
            {
                try
                {
                    var result = await _msalClient.AcquireTokenWithDeviceCode(_scopes, callback => {
                        Console.WriteLine(callback.Message);
                        return Task.FromResult(0);
                    }).ExecuteAsync();

                    _userAccount = result.Account;
                    return result.AccessToken;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Error getting access token: {exception.Message}");
                    return null;
                }
            }
            else
            {
                var result = await _msalClient
                    .AcquireTokenSilent(_scopes, _userAccount)
                    .ExecuteAsync();

                return result.AccessToken;
            }
        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("bearer", await GetAccessToken());
        }
    }
}
