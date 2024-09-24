using AdsConfiguration.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AdsConfiguration.Data.Context;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }

    public DbSet<Ads> Adss { get; set; }
}