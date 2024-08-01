using System.Text.Json;
using System.Web;

namespace enesens_mobile.Services;

public class AuthService(HttpService httpClient)
{
    public async Task Login(string email, string password)
    {
        try
        {
            var content = new { login = email, credential = password };

            var url = $"http://201.6.243.3:8090/api/signin";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonSerializer.Serialize(content), null, "application/json");
            
            var response = await httpClient.SendAsync(request);
            Console.WriteLine("Login success");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}