using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightManagementBlazorServer.Services
{
    public class PassengerService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseApiUrl = "https://localhost:44334/api/Passenger";
        public PassengerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Passenger>> GetPassengersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Passenger>>(BaseApiUrl);
        }
        public async Task AddPassengerAsync(Passenger passenger)
        {
            var httpPostRequest = new HttpRequestMessage(HttpMethod.Post, BaseApiUrl);
            httpPostRequest.Content = new StringContent(JsonSerializer.Serialize(passenger), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPostRequest);
        }
        public async Task UpdatePassengerAsync(Passenger passenger)
        {
            var httpPutRequest = new HttpRequestMessage(HttpMethod.Put, BaseApiUrl);
            httpPutRequest.Content = new StringContent(JsonSerializer.Serialize(passenger), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(httpPutRequest);
        }
        public async Task<Passenger> GetPassengerByIdAsync(int passengerId)
        {
            return await _httpClient.GetFromJsonAsync<Passenger>($"{BaseApiUrl}/{passengerId}");

        }
        public async Task DeletePassengerAsync(int passengerId)
        {
            var httpDeleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"{BaseApiUrl}/{passengerId}");
            await _httpClient.SendAsync(httpDeleteRequest);
        }

        public async Task CheckInPassenger(int passengerId)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Put, $"{BaseApiUrl}/checkInPassenger/{passengerId}");
            await _httpClient.SendAsync(httpRequest);
        }
    }
}
