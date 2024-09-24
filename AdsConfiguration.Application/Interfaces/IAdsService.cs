using AdsConfiguration.Domain.Entity;

namespace AdsConfiguration.Application.Interfaces;

public interface IAdsService
{
    Task<IEnumerable<Ads>> GetAds();
    Task<Ads> UpsertAds(Ads ads);
}