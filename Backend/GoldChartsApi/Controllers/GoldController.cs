﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GoldChartsApi.Services;
using System.Threading.Tasks;
using CurrencyDataProvider.ReadModel;
using MetalsDataProvider.ReadModel;

namespace GoldChartsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoldController : ControllerBase
    {
        CombineCurrencyAndMetalDataService _combineCurrencyAndMetalDataService;

        public GoldController(CombineCurrencyAndMetalDataService combineCurrencyAndMetalDataService)
        {
            _combineCurrencyAndMetalDataService = combineCurrencyAndMetalDataService;
        }

        // https://localhost:44314/api/Gold/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var prices = await _combineCurrencyAndMetalDataService.GetMetalpricesInCurrency(Currency.USD, Metal.Gold);

            if (prices == null)
            {
                return NoContent();
            }

            return Ok(prices);
        }
    }
}
