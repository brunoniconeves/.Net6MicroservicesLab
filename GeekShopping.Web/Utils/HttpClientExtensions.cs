using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType 
            = new MediaTypeHeaderValue("application/json");
        
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"something went wrong calling the API: {response.ReasonPhrase}");
            }

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true });
        }

        public static async Task<HttpResponseMessage> PostAsJson<T>(
            this HttpClient client, 
            string url, T data)       
        {
            var dataAsString = JsonSerializer.Serialize(data);            
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return await client.PostAsync(url, content);
        }

        public static async Task<HttpResponseMessage> PutAsJson<T>(
            this HttpClient client,
            string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return await client.PutAsync(url, content);
        }

    }
}
