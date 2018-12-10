using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.API.Campaigns.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SwitchFully.IntakeApp.Controller.Tests.Campaigns
{
    public class SwitchFullyControllerTests
    {
        [Fact]
        public void GivenCampaignDTOCreateToCampaign_WhenCreatingACampaignFromCampaignDTO_ThenCampaignIsCreated()
        {
            var CampaignDTOCreate = new CampaignDTO_Create()
            {
                Client = "VAB",
                Name = "Java",
                StartDate = new DateTime(2018, 04, 21),
                EndDate = new DateTime(2018, 06, 21)
            };

            var campaignMapper = new CampaignMapper();
            var result = campaignMapper.CampaignDTOCreateToCampaign(CampaignDTOCreate);

            Assert.Equal("Java", result.Name);
            Assert.Equal("VAB", result.Client);
            Assert.True(result.Status == false);
        }
        [Fact]
        public void GivenCampaignDTOCreateToCampaignWithActiveCampaign_WhenCreatingACampaignFromCampaignDTO_ThenCampaignIsCreatedWithStatusTrue()
        {
            var CampaignDTOCreate = new CampaignDTO_Create()
            {
                Client = "VAB",
                Name = "Java",
                StartDate = new DateTime(2012, 04, 21),
                EndDate = new DateTime(2030, 06, 21)
            };

            var campaignMapper = new CampaignMapper();
            var result = campaignMapper.CampaignDTOCreateToCampaign(CampaignDTOCreate);

            Assert.Equal("Java", result.Name);
            Assert.Equal("VAB", result.Client);
            Assert.True(result.Status == true);
        }
    }
}
