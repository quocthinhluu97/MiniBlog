using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MiniBlog.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace MiniBlog.Client
{
    public class AppState
    {
        private readonly HttpClient _httpClient;

        public AppState(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
        }

    }
}
