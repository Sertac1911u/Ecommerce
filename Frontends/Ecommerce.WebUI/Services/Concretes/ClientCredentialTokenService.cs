﻿using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Settings;
using IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Ecommerce.WebUI.Services.Concretes
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly ClientSettings _clientSettings;
        public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IMemoryCache memoryCache, IOptions<ClientSettings> clientSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
            _memoryCache = memoryCache;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetToken()
        {
            if (_memoryCache.TryGetValue("ecommercetoken", out string cachedToken))
            {
                return cachedToken;
            }
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });
            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.EcommerceVisitorClient.ClientId,
                ClientSecret = _clientSettings.EcommerceVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

            if (tokenResponse.IsError)
            {
                throw new Exception("Token alınamadı: " + tokenResponse.ErrorDescription);
            }
            _memoryCache.Set("ecommercetoken", tokenResponse.AccessToken, TimeSpan.FromSeconds(tokenResponse.ExpiresIn));
            return tokenResponse.AccessToken;
        }
    }
}
