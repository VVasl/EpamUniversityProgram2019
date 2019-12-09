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
        private readonly IPublicClientApplication msalClient;
        private readonly string[] scopes;
        private  IAccount userAccount;

        public DeviceCodeAuthProvider(string appId, string[] scopes)
        {
            this.scopes = scopes;

            this.msalClient = PublicClientApplicationBuilder
                .Create(appId)
                .WithTenantId("organizations")
                .Build();
        }

        public async Task<string> GetAccessToken()
        {
            if (userAccount == null)
            {
                try
                {
                    var result = await msalClient.AcquireTokenWithDeviceCode(scopes, callback => {
                        Console.WriteLine(callback.Message);
                        return Task.FromResult(0);
                    }).ExecuteAsync();

                    userAccount = result.Account;
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
                var result = await msalClient
                    .AcquireTokenSilent(scopes, userAccount)
                    .ExecuteAsync();

                return result.AccessToken;
            }
        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("bearer", await GetAccessToken());
        }
    }
}
