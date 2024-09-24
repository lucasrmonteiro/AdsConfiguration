using AdsConfiguration.Domain.Entity;

namespace AdsConfiguration.Data.Interfaces;

public interface IAdsRepository
{
    Task<IEnumerable<Ads>> GetAds();
    Task<Ads> UpsertAds(Ads ads);
}