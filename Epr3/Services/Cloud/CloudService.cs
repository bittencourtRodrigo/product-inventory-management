using Epr3.Data;
using Firebase.Auth;
using Firebase.Auth.Providers;
using System.Text;
using System.Text.Json;
namespace Epr3.Services.Cloud
{
    public class CloudService : ICloudService
    {
        public async Task<HttpResponseMessage> PostJson<T>(T content, string stringConnection)
        {
            string json = JsonSerializer.Serialize(content);
            HttpClient httpClient = new HttpClient();
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(stringConnection, httpContent);
        }

        public async Task<string> Login(string emailUser, string password)
        {
            FirebaseAuthConfig config = new FirebaseAuthConfig()
            {
                ApiKey = FirebaseConstants.ApiKey,
                AuthDomain = FirebaseConstants.Domain,
                Providers = new FirebaseAuthProvider[] { new EmailProvider() }
            };
            FirebaseAuthClient client = new FirebaseAuthClient(config);
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
        
        public async Task Register(string emailUser, string password)
        {
            FirebaseAuthConfig config = new FirebaseAuthConfig()
            {
                ApiKey = FirebaseConstants.ApiKey,
                AuthDomain = FirebaseConstants.Domain,
                Providers = new FirebaseAuthProvider[] { new EmailProvider() }
            };
            FirebaseAuthClient client = new FirebaseAuthClient(config);
            try
            {
                await client.CreateUserWithEmailAndPasswordAsync(emailUser, password);
            }
            catch (FirebaseAuthException e)
            {
                throw new FirebaseAuthException(e.Message, e.Reason);
            }
        }
    }
}