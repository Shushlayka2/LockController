using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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

        public async Task<(string deviceId, string lockId, string config)> RegisterAsync(string code)
        {
            (string deviceId, string lockId, string config) tuple = (null, null, null);

            var response = await HttpClient.PostAsJsonAsync("api/registry", code);
            if (response.IsSuccessStatusCode)
            {
                tuple = response.Content.ReadAsAsync<(string, string, string)>().Result;
            }
            return tuple;
        }
    }
}
