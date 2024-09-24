using System.ComponentModel.DataAnnotations;
using AdsConfiguration.Domain.Enum;

namespace AdsConfiguration.Domain.Entity;

public class Ads
{
    [Key]
    public int adId { get; set; }
    public string adDescription { get; set; }
    public DateTime adCreationDate { get; set; }
    public adStatusEnum adStatus { get; set; }
    public decimal? adBalance { get; set; }
    public string? adExternalId { get; set; }
    public int adTotalLeads { get; set; }
}