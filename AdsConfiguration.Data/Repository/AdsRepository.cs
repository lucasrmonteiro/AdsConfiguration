using AdsConfiguration.Data.Context;
using AdsConfiguration.Data.Interfaces;
using AdsConfiguration.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AdsConfiguration.Data.Repository;

public class AdsRepository : IAdsRepository
{
    private readonly ApiContext _context;
    private readonly ILogger<AdsRepository> _logger;
    
    public AdsRepository(ApiContext context , ILogger<AdsRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task<IEnumerable<Ads>> GetAds()
    {
        try
        {
            return await _context.Adss.ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting ads");
            return null;
        }

    }
    
    public async Task<Ads> UpsertAds(Ads ads)
    {
        try
        {
            var existingAds = await _context.Adss.
                FirstOrDefaultAsync(x => x.adId == ads.adId);
        
            if (existingAds == null)
            {
                await _context.Adss.AddAsync(ads);
            }
            else
            {
                _context.Adss.Update(ads);
            }
        
            await _context.SaveChangesAsync();
        
            return ads;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting ads");
            return null;
        }
    }
}