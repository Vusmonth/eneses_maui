using System.Net.Http.Json;
using enesens_mobile.Models;

namespace enesens_mobile.Services;

public class DashboardService(HttpService httpClient)
{
    public async Task<List<CompanyMetric>> GetMetrics()
    {
        try
        {
            var token = httpClient._csrfToken;
            var url = $"http://201.6.243.3:8090/security/api/view/allDashCompaniesPosition?_csrf={token}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(request);
            var parsedResponse = await response.Content.ReadFromJsonAsync<DefaultResponse<CompanyMetric>>();
            return parsedResponse.list;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<CompanyMetric>();
        }
    }
}