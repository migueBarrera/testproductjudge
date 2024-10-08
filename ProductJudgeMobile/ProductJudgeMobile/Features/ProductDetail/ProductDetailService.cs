﻿using Microsoft.Extensions.Logging;
using ProductJudge.Mobile.DAL.API;
using SecretAligner.Telemedicine.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductJudgeMobile.Features.ProductDetail
{
    public class ProductDetailService
    {
        private readonly IProductsApi productApi;
        private readonly ILogger<ProductDetailService> logger;

        public ProductDetailService(ILogger<ProductDetailService> logger, IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;

            var httpClient = httpClientFactory.CreateClient(HttpClients.FAKE_API);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            productApi = Refit.RestService.For<IProductsApi>(httpClient);
        }
    }
}
