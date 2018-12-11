using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwitchFully.IntakeApp.API.Campaigns.DTO;
using SwitchFully.IntakeApp.API.Campaigns.Mappers;
using SwitchFully.IntakeApp.Domain.Campaigns;
using SwitchFully.IntakeApp.Service.Campaigns;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.Campaigns.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class CampaignsController : ControllerBase
	{
		private readonly ICampaignService _campaignService;
		private readonly ICampaignMapper _campaignMapper;

		public CampaignsController(ICampaignService campaignService, ICampaignMapper campaignMapper)
		{
			_campaignService = campaignService;
			_campaignMapper = campaignMapper;
		}
		[HttpPost]
		public async Task<ActionResult<CampaignDTO_Return>> Create(CampaignDTO_Create campaignDTO)
		{
			var campaignToCreate = await _campaignService.CreateNewCampaign(_campaignMapper.CampaignDTOCreateToCampaign(campaignDTO));
			return _campaignMapper.CampaignToCampaignDTOReturn(campaignToCreate);
		}
		[HttpGet]
		public async Task<ActionResult<List<CampaignDTO_Return>>> GetAll()
		{
			return Ok(_campaignMapper.CampaignListToCampaignDTOReturnList(await _campaignService.GetAllCampaigns()));
		}
		[HttpGet]
		[Route("id:string")]
		public async Task<ActionResult<CampaignDTO_Return>> GetById(string id)
		{
			var campaign = await _campaignService.GetSingleCampaignByID(id);
			if (campaign == null)
			{
				return BadRequest("Id not found");
			}
			var campaignToReturn = _campaignMapper.CampaignToCampaignDTOReturn(campaign);

			return Ok(campaignToReturn);
		}
		[HttpPut]
		public Task<ActionResult<CampaignDTO_Return>> Update(Campaign objectToUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
