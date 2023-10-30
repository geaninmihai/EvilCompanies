using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using EvilCompanies.Models;

namespace EvilCompanies.Controllers
{
    [Route("api/oauth/evilapi")]
    public class EvilApiController : OAuthAuthenticationCodeControllerBase
    {
        public EvilApiController(IConfiguration configuration, IHttpClientFactory httpClientFactory) : base(configuration, httpClientFactory)
        {
        }

        public override string ClientId { get => configuration["EvilApi:ClientId"]; }
        public override string ClientSecret { get => configuration["EvilApi:ClientSecret"]; }
        public override string AuthorizationEndpoint { get => configuration["EvilApi:AuthorizationEndpoint"]; }
        public override string TokenEndpoint { get => configuration["EvilApi:TokenEndpoint"]; }
        public override string Scope { get => configuration["EvilApi:Scope"]; }
        public override string RedirectUri { get => $"{Request.Scheme}://{Request.Host}/api/oauth/evilapi/callback"; }
        public override string Key { get; } = "EvilApi.AuthenticationCode";

        [HttpGet("authorize")]
        public override IActionResult Authorize(string redirectUrl)
        {
            return base.Authorize(redirectUrl);
        }

        [HttpGet("callback")]
        public override async Task<IActionResult> Callback(string code, string error, string error_description, string state)
        {
            return await base.Callback(code, error, error_description, state);
        }

        [HttpPost("token")]
        public override async Task<IActionResult> Token()
        {
            return await base.Token();
        }
    }
}