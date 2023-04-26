using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APIClient
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> SendRequest(HttpMethod httpMethod, string requestUri, HttpContent httpContent = null)
        {
            if (!Uri.TryCreate(requestUri, UriKind.Absolute, out var uri))
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent($"Invalid URL: {requestUri}");
                return response;
            }

            var request = new HttpRequestMessage(httpMethod, uri);
            request.Content = httpContent;
            return await _httpClient.SendAsync(request);
        }
    }

    public class ApiResponse<T>
    {
        public string? Message
        {
            get; set;
        }
        public HttpStatusCode StatusCode
        {
            get; set;
        }
        public T? Data
        {
            get; set;
        }
    }

    public class User
    {
        public int id
        {
            get; set;
        }
        public string? email
        {
            get; set;
        }
        public string? first_name
        {
            get; set;
        }
        public string? last_name
        {
            get; set;
        }
        public string? avatar
        {
            get; set;
        }
    }
}