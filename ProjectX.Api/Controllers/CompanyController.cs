﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Commands.Auth;
using ProjectX.Common.Auth;
using ProjectX.Queries.Queries.Company;

namespace ProjectX.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ISender _sender;

        public CompanyController(ILogger<CompanyController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet("{companyUid}")]
        public async Task<Queries.Contracts.Responses.Company.CompanyDto> GetCompany([FromRoute] Guid companyUid)
        {
            return await _sender.Send(new GetCompanyQuery(companyUid));
        }

        [HttpPost]
        public async Task RegisterAccount([FromBody] RegisterAccountRequest accountRequest)
        {
            await _sender.Send(new RegisterAccountCommand(accountRequest));
        }
    }
}
