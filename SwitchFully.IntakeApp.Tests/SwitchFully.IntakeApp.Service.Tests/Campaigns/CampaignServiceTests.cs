using Microsoft.EntityFrameworkCore;
using NSubstitute;
using SwitchFully.IntakeApp.Data;
using SwitchFully.IntakeApp.Data.Repositories.Campaigns;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Service.Campaigns;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SwitchFully.IntakeApp.Service.Tests.CampaignsTests
{
    public class CampaignServiceTests
    {

        private static DbContextOptions<SwitchFullyIntakeAppContext> CreateNewInMemoryDatabase()
        {
            return new DbContextOptionsBuilder<SwitchFullyIntakeAppContext>()
                .UseInMemoryDatabase("SwitchDb" + Guid.NewGuid().ToString("N"))
                .Options;
        }

        [Fact]
        public async void GivenGetAllCampaigns_whenAllCampaignsRequested_ReturnAllCampaigns()
        {
            var testCampaign = Campaign.CreateNewCampaign("java", "VAB", new DateTime(2018, 04, 21), new DateTime(2018, 06, 22));

            using (var context = new SwitchFullyIntakeAppContext(CreateNewInMemoryDatabase()))
            {
                context.Campaigns.Add(testCampaign);
                context.SaveChangesAsync();
                var repo = new CampaignRepository(context);
                var service = new CampaignService(repo);
                var result = await service.GetAllCampaigns();

                Assert.IsType<List<Campaign>>(result);
                Assert.NotEmpty(result);
            };
        }

        [Fact]
        public async void GivenGetSingleCampaignHappyPath_whenASingleCampaignIsRequested_ReturnTheCampaign()
        {
            var testCampaign = Campaign.CreateNewCampaign("java", "VAB", new DateTime(2018, 04, 21), new DateTime(2018, 06, 22));

            using (var context = new SwitchFullyIntakeAppContext(CreateNewInMemoryDatabase()))
            {
                context.Campaigns.Add(testCampaign);
                context.SaveChangesAsync();
                var repo = new CampaignRepository(context);
                var service = new CampaignService(repo);
                var result = await service.GetSingleCampaignByID(testCampaign.CampaignId.ToString());

                Assert.Equal(testCampaign.CampaignId.ToString(), result.CampaignId.ToString());
            };
        }

        [Fact]
        public async void GivenGetSingleCampaignUnHappyPath_whenASingleCampaignIsRequestedAndNotFound_ReturnTheCampaign()
        {
            var testCampaign = Campaign.CreateNewCampaign("java", "VAB", new DateTime(2018, 04, 21), new DateTime(2018, 06, 22));

            using (var context = new SwitchFullyIntakeAppContext(CreateNewInMemoryDatabase()))
            {

                var repo = new CampaignRepository(context);
                var service = new CampaignService(repo);
                var result = await service.GetSingleCampaignByID(Guid.NewGuid().ToString());

                Assert.Null(result);
            }

        }

    }
}


