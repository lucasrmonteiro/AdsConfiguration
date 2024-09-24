using AdsConfiguration.Application.Interfaces;
using AdsConfiguration.Data.Interfaces;
using AdsConfiguration.Domain.Entity;

namespace AdsConfiguration.Application.Services;

public class AdsService : IAdsService
{
    private readonly IAdsRepository _adsRepository;
    
    public AdsService(IAdsRepository adsRepository)
    {
        _adsRepository = adsRepository;
    }
    
    public async Task<IEnumerable<Ads>> GetAds()
    {
        return await _adsRepository.GetAds();
    }
    
    public async Task<Ads> UpsertAds(Ads ads)
    {
        return await _adsRepository.UpsertAds(ads);
    }
}