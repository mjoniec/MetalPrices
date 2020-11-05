﻿using MetalApi.GuandlModel;
using MetalReadModel;
using Model;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace MetalApi.Providers
{
    public class FallbackMetalsPricesProvider : IMetalsPricesProvider
    {
        //public async Task<MetalPrices> Get(MetalType metalType, DateTime start, DateTime end)
        //{
        //    string json;
        //    var metalPrices = new MetalPrices();
        //    string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) 
        //        + "//MetalPricesFallbackData//";
            
        //    if (metalType == MetalType.Gold)
        //    {
        //        path += "goldPricesFallback.json";
        //        metalPrices.Currency = Currency.AUD;
        //    }
        //    else
        //    {
        //        path += "silverPricesFallback.json";
        //        metalPrices.Currency = Currency.USD;
        //    }

        //    json = await File.ReadAllTextAsync(path);

        //    metalPrices = json
        //        .Deserialize()
        //        .Map(start, end);

        //    metalPrices.DataSource = DataSource.Fallback;

        //    return metalPrices;
        //}

        public async Task<string> Get(MetalType metalType)
        {
            string json;
            //var metalPrices = new MetalPrices();
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
                + "//MetalPricesFallbackData//";

            if (metalType == MetalType.Gold)
            {
                path += "goldPricesFallback.json";
                //metalPrices.Currency = Currency.AUD;
            }
            else
            {
                path += "silverPricesFallback.json";
                //metalPrices.Currency = Currency.USD;
            }

            json = await File.ReadAllTextAsync(path);

            return json;

            //metalPrices = json
            //    .Deserialize()
            //    .Map();

            //metalPrices.DataSource = DataSource.Fallback;

            //return metalPrices;
        }
    }
}
