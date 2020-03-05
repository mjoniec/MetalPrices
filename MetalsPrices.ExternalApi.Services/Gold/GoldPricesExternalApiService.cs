﻿using MetalsPrices.Abstraction.MeralPricesServices;
using MetalsPrices.Abstraction.MetalPricesDataProviders;
using MetalsPrices.ExternalApi.Services.GuandlService;
using MetalsPrices.Model;
using System.Threading.Tasks;

namespace MetalsPrices.ExternalApi.Services.Gold
{
    public class GoldPricesExternalApiService : IMetalPricesService
    {
        private readonly IMetalsPricesDataProvider _goldPricesExternalApiClient;
        private readonly GuandlMetalDataJsonDeserializer _guandlMetalDataJsonDeserializer;
        private readonly GuandlMetalModelToMetalModelConverter _guandlMetalModelToMetalModelConverter;

        public GoldPricesExternalApiService()
        {
            _goldPricesExternalApiClient = new GoldPricesExternalApiClient();
            _guandlMetalDataJsonDeserializer = new GuandlMetalDataJsonDeserializer();
            _guandlMetalModelToMetalModelConverter = new GuandlMetalModelToMetalModelConverter();
        }

        public async Task StartPreparingPrices()
        {
            await _goldPricesExternalApiClient.StartPreparingPrices();
        }

        public MetalPrices GetPrices()
        {
            var dailyPrices = _goldPricesExternalApiClient.Prices;

            if (dailyPrices == null) return null;

            var externalGoldModel = _guandlMetalDataJsonDeserializer.DeserializeDataFromMessage(dailyPrices);

            if (externalGoldModel == null) return null;

            var goldModel = _guandlMetalModelToMetalModelConverter.ConvertExternalModel(externalGoldModel);

            return goldModel;
        }
    }
}
