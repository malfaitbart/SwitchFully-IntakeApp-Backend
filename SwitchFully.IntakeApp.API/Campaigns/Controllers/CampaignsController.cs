using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.API.Campaigns.Mappers;
using SwitchFully.IntakeApp.API.Interfaces;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Service.Campaigns;

namespace SwitchFully.IntakeApp.API.Campaigns.Controllers
{
    [Route("api/[controller]")]
	[Authorize]
    [ApiController]
    public class CampaignsController : ControllerBase, IController<Campaign, CampaignDTO_Return>
    {
        private readonly ICampaignService _campaignService;
        private readonly ICampaignMapper _campaignMapper;

        public CampaignsController(ICampaignService campaignService, ICampaignMapper campaignMapper)
        {
            _campaignService = campaignService;
            _campaignMapper = campaignMapper;
        }
		[HttpPost]
		public Task<ActionResult<CampaignDTO_Return>> Create(Campaign objectToCreate)
		{
			throw new NotImplementedException();
		}
		[HttpGet]
		public async Task<ActionResult<List<CampaignDTO_Return>>> GetAll()
		{
			return _campaignMapper.CampaignListToCampaignDTOReturnList(await _campaignService.GetAllCampaigns());
		}
		[HttpGet]
		[Route("id:int")]
		public Task<ActionResult<CampaignDTO_Return>> GetById(int id)
		{
			throw new NotImplementedException();
		}
		[HttpPut]
		public Task<ActionResult<CampaignDTO_Return>> Update(Campaign objectToUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
