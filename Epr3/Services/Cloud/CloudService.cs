using Firebase.Auth.Providers;
using Firebase.Auth;
using System.Text;
using Epr3.Data;
using System.Text.Json;

namespace Epr3.Services.Cloud
{
    public class CloudService : ICloudService
    {
        public async Task<HttpResponseMessage> PostJson<T>(T content, string stringConnection)
        {
            var json = JsonSerializer.Serialize(content);
            HttpClient httpClient = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(stringConnection, httpContent);
        }

        public async Task<string> Login(string emailUser, string password)
        {
            var config = new FirebaseAuthConfig()
            {
                ApiKey = FirebaseConstants.ApiKey,
                AuthDomain = FirebaseConstants.Domain,
                Providers = new FirebaseAuthProvider[] { new EmailProvider() }
            };

            var client = new FirebaseAuthClient(config);

            try
            {
                await client.SignInWithEmailAndPasswordAsync(emailUser, password);
                return client.User.Uid;
            }
            catch (FirebaseAuthException e)
            {
                throw new FirebaseAuthException("Email or password invalid.", e.Reason);
            }
        }
    }
}
