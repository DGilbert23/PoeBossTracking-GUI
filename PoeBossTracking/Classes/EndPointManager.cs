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
                HttpResponseMessage response = await httpClient.GetAsync(GlobalVariables.ApiUrl + "boss/league");
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();
                List<Boss> bossList = JsonSerializer.Deserialize<List<Boss>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                bossList.Sort((x, y) => x.bossName.CompareTo(y.bossName));

                return bossList;
            }
            catch (HttpRequestException e)
            {
                //Display error message somehow & handle gracefully
                throw e;
            }
        }

        public async Task<List<Item>> GetAllDropsByBossId(string bossName)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(GlobalVariables.ApiUrl + "boss/" + bossName);
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();
                List<Item> itemList = JsonSerializer.Deserialize<List<Item>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                itemList.Sort((x, y) => x.itemName.CompareTo(y.itemName));
                return itemList;
            }
            catch (HttpRequestException e)
            {
                //Display error message somehow & handle gracefully
                throw e;
            }
        }
        
        public async Task<List<LoggedKill>> GetAllKillsByBossUser(string bossId, string userName)
        {
            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, GlobalVariables.ApiUrl + "drops/kill/list/" + bossId);
                requestMessage.Headers.Add("appUserId", userName);
                var response = await httpClient.SendAsync(requestMessage);

                string jsonString = await response.Content.ReadAsStringAsync();
                List<LoggedKill> killList = JsonSerializer.Deserialize<List<LoggedKill>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return killList;
            }
            catch (HttpRequestException e)
            {
                //Display error message somehow & handle gracefully
                throw e;
            }
        }

        /*public async void LogNewKillAsync(string bossId, string userId, DateTime date)
        {
            try
            {
                LoggedKill newKill = new LoggedKill(null, bossId, userId, date);

                var stringContent = new StringContent(JsonSerializer.Serialize(newKill), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:8080/drops/kill/log", stringContent);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                //anything else?
                throw e;
            }
        }*/

        /*public async void LogNewDropAsync(string loggedKillId, string itemId, string itemValue)
        {
            try
            {
                LoggedDrop newDrop = new LoggedDrop(loggedKillId, itemId, itemValue);
                
                var stringContent = new StringContent(JsonSerializer.Serialize(newDrop), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:8080/drops/kill/log/drop", stringContent);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                //anything else?
                throw e;
            }
        }*/

        public async void LogKillAndDrops(string bossId, string userName, List<KillDrop> drops)
        {
            try
            {
                KillLog newKillLog = new KillLog(null, bossId, drops);

                var requestMessage = new HttpRequestMessage(HttpMethod.Put, GlobalVariables.ApiUrl + "drops/kills");
                requestMessage.Headers.Add("appUserId", userName);
                var stringContent = new StringContent(JsonSerializer.Serialize(newKillLog), Encoding.UTF8, "application/json");
                requestMessage.Content = stringContent;

                var response = await httpClient.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                //Display error message somehow & handle gracefully
                throw e;
            }
        }
    }
}

