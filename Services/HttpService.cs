using enesens_mobile.Context;

namespace enesens_mobile.Services;

public class HttpService : HttpClient
{
    private readonly string _baseUrl = "http://201.6.243.3:8090/";
    public string _csrfToken = string.Empty;

    public HttpService(CookieHandler cookieHandler): base(cookieHandler)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await SetToken();
            SetDefaultHeaders();
        });
    }

    public void SetDefaultHeaders()
    {
        if (_csrfToken == string.Empty) return;

        DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
        DefaultRequestHeaders.Add("X-XSRF-TOKEN", _csrfToken);
        
        Console.WriteLine("Successfully set headers.");
    }

    public async Task SetToken()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl);
        var response = await SendAsync(request);
        _csrfToken = response.Headers.GetValues("XSRF-TOKEN").First();

        Console.WriteLine("Successfully set cookies.");
    }
}