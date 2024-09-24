using Xunit;
using Moq;
using AdsConfiguration.Application.Interfaces;
using AdsConfiguration.Domain.Entity;
using AdsConfiguration.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdsConfiguration.Data.Interfaces;

namespace AdsConfiguration.Application.Tests.Services
{
    public class AdsServiceTests
    {
        [Fact]
        public async Task GetAds_ReturnsAdsList()
        {
            // Arrange
            var mockAdsRepository = new Mock<IAdsRepository>();
            var adsList = new List<Ads>
                { new Ads { adId = 1, adDescription = "Ad1" }, new Ads { adId = 2, adDescription = "Ad2" } };
            mockAdsRepository.Setup(repo => repo.GetAds()).ReturnsAsync(adsList);
            var adsService = new AdsService(mockAdsRepository.Object);

            // Act
            var result = await adsService.GetAds();

            // Assert
            Assert.Equal(adsList, result);
        }

        [Fact]
        public async Task UpsertAds_ReturnsUpdatedAd()
        {
            // Arrange
            var mockAdsRepository = new Mock<IAdsRepository>();
            var ad = new Ads { adId = 1, adDescription = "Ad1" };
            mockAdsRepository.Setup(repo => repo.UpsertAds(ad)).ReturnsAsync(ad);
            var adsService = new AdsService(mockAdsRepository.Object);

            // Act
            var result = await adsService.UpsertAds(ad);

            // Assert
            Assert.Equal(ad, result);
        }
    }
}