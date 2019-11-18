using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MoodFull.RestClient
{
    public static class RestClientTasks<T>
    {
        private const string Url = "http://localhost:53772/Services/";

        
        
        
        public static async Task<List<T>> GetDataList(string url)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(Url + url);
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
            return taskModels;
        }

        public static async Task<T> GetData(string url, string username)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(Url + url + "/" + username);
            var taskModels = JsonConvert.DeserializeObject<T>(json);
            return taskModels;
        }

        public static async Task<bool> SearchData(string url, string username, string password)
        {
            try
            {
                var httpClient = new HttpClient();
                string json = await httpClient.GetStringAsync("iewfjfjfeiofewi" + url + "/" + username + "/" + password);
              
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            return true;
        }

        public static async Task<bool> PostData(string url, T t)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PostAsync(Url + url, httpContent);
            return result.IsSuccessStatusCode;
        }

        public static async Task<bool> PutData(string url, T t)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(t);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PutAsync(Url + url, httpContent);
            return result.IsSuccessStatusCode;
        }

        public static async Task<bool> DeleteData(string url, T t)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(Url + url),
                Content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json")
            };
            var response = await httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
    

    }
}
