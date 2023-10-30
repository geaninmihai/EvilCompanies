using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

using EvilCompanies.Models;

namespace EvilCompanies
{
    public partial class EvilApiService
    {
        private readonly HttpClient httpClient;

        public EvilApiService(IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient("EvilApi");
        }

        partial void OnGetAll(HttpRequestMessage request);
        partial void OnGetAllResponse(HttpResponseMessage response);

        public async Task<IEnumerable<EvilCompanies.Models.EvilApi.GetAll>> GetAll()
        {
            var uri = new Uri(httpClient.BaseAddress, $"data");

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAll(request);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            OnGetAllResponse(response);
            return await response.Content.ReadFromJsonAsync<IEnumerable<EvilCompanies.Models.EvilApi.GetAll>>();
        }

        partial void OnEdit(HttpRequestMessage request);
        partial void OnEditResponse(HttpResponseMessage response);

        public async Task<EvilCompanies.Models.EvilApi.GetAll> Edit(int id, Models.EvilApi.GetAll company)
        {
            var uri = new Uri(httpClient.BaseAddress, $"data/{id}");

            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Content = JsonContent.Create<Models.EvilApi.GetAll>(company);

            OnEdit(request);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            OnEditResponse(response);
            return await response.Content.ReadFromJsonAsync<EvilCompanies.Models.EvilApi.GetAll>();
        }

        partial void OnGet(HttpRequestMessage request);
        partial void OnGetResponse(HttpResponseMessage response);

        public async Task<EvilCompanies.Models.EvilApi.GetAll> Get(int id)
        {
            var uri = new Uri(httpClient.BaseAddress, $"data/{id}");

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGet(request);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            OnGetResponse(response);
            return await response.Content.ReadFromJsonAsync<EvilCompanies.Models.EvilApi.GetAll>();
        }

        partial void OnDelete(HttpRequestMessage request);
        partial void OnDeleteResponse(HttpResponseMessage response);

        public async Task<EvilCompanies.Models.EvilApi.GetAll> Delete(int id)
        {
            var uri = new Uri(httpClient.BaseAddress, $"data/{id}");

            var request = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDelete(request);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            OnDeleteResponse(response);
            return await response.Content.ReadFromJsonAsync<EvilCompanies.Models.EvilApi.GetAll>();
        }
    }
}