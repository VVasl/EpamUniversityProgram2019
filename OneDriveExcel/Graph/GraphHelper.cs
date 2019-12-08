namespace OneDriveExcel   
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.Graph;

    public class GraphHelper
    {
        private static GraphServiceClient graphClient;
        public static void Initialize(IAuthenticationProvider authProvider)
        {
            graphClient = new GraphServiceClient(authProvider);
        }

        public static async Task<User> GetMeAsync()
        {
            try
            {
                return await graphClient.Me.Request().GetAsync();
            }
            catch (ServiceException ex)
            {
                Console.WriteLine($"Error getting signed-in user: {ex.Message}");
                return null;
            }
        }

        public static async Task<Stream> GetFileAsync(string fileName)
        {
            try
            {
                var resultPage = await graphClient.Me.Drive.Root.ItemWithPath(fileName).Content
                .Request()
                .GetAsync();

                return resultPage;
            }
            catch (ServiceException ex)
            {
                Console.WriteLine($"Error getting file content: {ex.Message}");
                return null;
            }
        }
    }
}
