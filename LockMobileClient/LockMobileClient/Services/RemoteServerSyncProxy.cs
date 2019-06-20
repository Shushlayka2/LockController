using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LockMobileClient.Services
{
    public class RemoteServerSyncProxy : IRemoteServerSyncProxy
    {
        protected HttpClient HttpClient { get; } = new HttpClient();

        public RemoteServerSyncProxy()
        {
            HttpClient.BaseAddress = new Uri(SettingsService.BaseAddress);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public (string deviceId, string config) Register(string code)
        {
            (string deviceId, string config) tuple = (null, null);

            var response = HttpClient.PostAsJsonAsync("api/registry", code).Result;
            if (response.IsSuccessStatusCode)
            {
                tuple = response.Content.ReadAsAsync<(string, string)>().Result;
            }
            return tuple;
        }
    }
}
