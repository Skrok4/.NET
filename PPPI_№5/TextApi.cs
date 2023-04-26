using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APIClient
{
    public class TextApi
    {
        private readonly ApiClient _apiClient;

        public TextApi(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ApiResponse<T>> Get<T>(string url) where T : class, new()
        {
            try
            {
                var response = await _apiClient.SendRequest(HttpMethod.Get, url);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(responseContent);
                    return new ApiResponse<T>
                    {
                        Message = "Success",
                        StatusCode = response.StatusCode,
                        Data = apiResponse.Data
                    };
                }

                return new ApiResponse<T>
                {
                    Message = $"Error: {responseContent}",
                    StatusCode = response.StatusCode,
                    Data = default(T)
                };
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<T>
                {
                    Message = $"Network error: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Data = default(T)
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Message = $"Exception: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Data = default(T)
                };
            }
        }

        public async Task<ApiResponse<T>> Post<T>(string url, object parameters)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(parameters));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await _apiClient.SendRequest(HttpMethod.Post, url, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var data = JsonConvert.DeserializeObject<T>(responseContent);
                    return new ApiResponse<T>
                    {
                        Message = "Success",
                        StatusCode = response.StatusCode,
                        Data = data
                    };
                }

                return new ApiResponse<T>
                {
                    Message = $"Error: {responseContent}",
                    StatusCode = response.StatusCode,
                    Data = default(T)
                };
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<T>
                {
                    Message = $"Network error: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Data = default(T)
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>
                {
                    Message = $"Exception: {ex.Message}",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Data = default(T)
                };
            }
        }
    }
}