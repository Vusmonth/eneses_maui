using System.Net;

namespace enesens_mobile.Context;

public class CookieHandler : HttpClientHandler
{
    public CookieContainer CookieContainer { get; }

    public CookieHandler()
    {
        CookieContainer = new CookieContainer();
        this.UseCookies = true;
        this.CookieContainer = CookieContainer;
    }
}