using Blazored.LocalStorage;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MiniBlog.Client.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        public bool IsLoggedIn { get; set; }

        public LoginService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task Login(LoginDetails loginDetails)
        {
            var response = await _httpClient.PostAsync($"api/login", JsonContent.Create(loginDetails));

            if (response.IsSuccessStatusCode)
            {
                await SaveToken(response);
                await SetAuthorizationHeader();

                IsLoggedIn = true;
            }
        }

        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("authToken");
            IsLoggedIn = false;
        }

        public async Task SaveToken(HttpResponseMessage response)
        {
            var token = await response.Content.ReadFromJsonAsync<JwToken>();
            await _localStorageService.SetItemAsync("authToken", token.Token);
        }

        public async Task SetAuthorizationHeader()
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = await _localStorageService.GetItemAsync<string>("authToken");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
