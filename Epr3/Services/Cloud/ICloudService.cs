namespace Epr3.Services.Cloud
{
    public interface ICloudService
    {
        Task<string> Login(string emailUser, string password);
        Task<HttpResponseMessage> PostJson<T>(T content, string stringConnection);
    }
}
