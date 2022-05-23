using PoeBossTracking.Classes.dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PoeBossTracking.Classes
{
    internal class EndPointManager
    {
        public static HttpClient httpClient = new HttpClient();

        public async Task<List<Boss>> GetAllBossesForCurrentLeague()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("http://localhost:8080/boss/list/current");
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();
                List<Boss> bossList = JsonSerializer.Deserialize<List<Boss>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return bossList;
            }
            catch (HttpRequestException e)
            {
                //Display error message somehow & handle gracefully
                throw e;
            }
        }

        public async Task<List<Item>> GetAllDropsByBossName(string bossName)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("http://localhost:8080/boss/" + bossName);
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();
                List<Item> itemList = JsonSerializer.Deserialize<List<Item>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return itemList;
            }
            catch (HttpRequestException e)
            {
                //Display error message somehow & handle gracefully
                throw e;
            }
        }


        public async void LogNewKillAsync(string bossId, string userName, DateTime date)
        {
            try
            {
                LoggedKill newKill = new LoggedKill(null, bossId, userName, date);

                var stringContent = new StringContent(JsonSerializer.Serialize(newKill), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:8080/drops/kill/log", stringContent);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                //anything else?
                throw e;
            }
        }
    }
}

