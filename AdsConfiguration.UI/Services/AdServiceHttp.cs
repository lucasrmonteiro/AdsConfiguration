using System.Text.Json;
using AdsConfiguration.Domain.Entity;
using AdsConfiguration.Domain.Enum;
using AdsConfiguration.UI.Model;

namespace AdsConfiguration.UI.Services;

public class AdsServiceHttp
{
    private readonly HttpClient _httpClient;

    public AdsServiceHttp(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AdModel>> GetAdsAsync()
    {
        var response = await _httpClient.GetAsync("ads");
        
        var content = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(content))
            return new List<AdModel>(); 
        
        var data = JsonSerializer.Deserialize<List<Ads>>(content);
        
        if (data == null || !data.Any())
        {
            return new List<AdModel>();
        }
        
        return data.Select(ad => new AdModel
        {
            AdId = ad.adId,
            AdDescription = ad.adDescription,
            AdStatus = ad.adStatus.ToString(),
            AdTotalLeads = ad.adTotalLeads
        }).ToList();
    }

    public async Task SaveAsync(AdModel ad)
    {
        var ads = new Ads()
        {
            adId = ad.AdId,
            adDescription = ad.AdDescription,
            adStatus = Enum.Parse<adStatusEnum>(ad.AdStatus),
            adTotalLeads = ad.AdTotalLeads
        };
        await _httpClient.PostAsJsonAsync("save/ads", ads);
    }
}