using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Lightspeed.Api.Authorization;
using Lightspeed.Api.Exceptions;
using Lightspeed.Api.Models.Status;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lightspeed.Api.Services;

public abstract class ServiceBase
{
    public static RateLimits? RateLimits { get; protected set; }

    private readonly ApiSecrets _apiSecrets;

    private readonly HttpClient _httpClient;

    public Error? LastError { get; protected set; }

    public HttpStatusCode LastRequestStatus { get; protected set; }
    
    private readonly JsonSerializerSettings _serializerSettings = new ()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        }
    };

    protected ServiceBase(ApiSecrets apiSecrets, HttpClient httpClient)
    {
        _apiSecrets = apiSecrets;
        _httpClient = httpClient;
    }
    
    /// <summary>
    /// Gets the API result.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="httpMethod">The HTTP method.</param>
    /// <param name="endPoint">The end point.</param>
    /// <param name="post">The post.</param>
    /// <returns></returns>
    public async Task<TResult?> GetApiResult<TResult>(HttpMethod httpMethod, string endPoint, object? post = null)
    {
        var request = await GetHttpRequestMessage(httpMethod, endPoint, post);
        var apiResult = await _httpClient.SendAsync(request);
        ProcessHttpHeaders(apiResult);
        return await GetProcessedResult<TResult>(apiResult);
    }
    
    /// <summary>
    /// Call an API endpoint without expecting a result.
    /// </summary>
    /// <param name="httpMethod">The HTTP method.</param>
    /// <param name="endPoint">The end point.</param>
    /// <param name="post">The post.</param>
    public async Task CallApi(HttpMethod httpMethod, string endPoint, object? post = null)
    {
        var request = await GetHttpRequestMessage(httpMethod, endPoint, post);
        var apiResult = await _httpClient.SendAsync(request);
        ProcessHttpHeaders(apiResult);
    }

    /// <summary>
    /// Gets the HTTP request message.
    /// </summary>
    /// <param name="httpMethod">The HTTP method.</param>
    /// <param name="endPoint">The end point.</param>
    /// <param name="post">The post.</param>
    /// <returns></returns>
    private async Task<HttpRequestMessage> GetHttpRequestMessage(HttpMethod httpMethod, string endPoint, object? post = null)
    {
        return await Task.Run(() =>
        {
            var endpoint = $"{_apiSecrets.Cluster.GetClusterUrl()}/{_apiSecrets.Language.GetLanguageCode()}/{endPoint}";
            var result = new HttpRequestMessage(httpMethod, endpoint);
            result.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            result.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_apiSecrets.ApiKey}:{_apiSecrets.ApiSecret}"))
            );

            if (post != null)
            {
                result.Content = new StringContent(JsonConvert.SerializeObject(post, _serializerSettings));
            }

            return result;
        });
    }

    /// <summary>
    /// Processes the HTTP headers.
    /// </summary>
    /// <param name="httpResponseMessage">The HTTP response message.</param>
    private void ProcessHttpHeaders(HttpResponseMessage httpResponseMessage)
    {
        LastRequestStatus = httpResponseMessage.StatusCode;
        
        if (httpResponseMessage.Headers.Contains("x-ratelimit-remaining"))
        {
            RateLimits = new RateLimits(
                httpResponseMessage.Headers.GetValues("x-ratelimit-limit").First(),
                httpResponseMessage.Headers.GetValues("x-ratelimit-remaining").First(),
                httpResponseMessage.Headers.GetValues("x-ratelimit-reset").First());
        }
    }

    /// <summary>
    /// Gets the processed (deserialized) result.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="httpResponseMessage">The HTTP response message.</param>
    /// <returns></returns>
    private async Task<TResult?> GetProcessedResult<TResult>(HttpResponseMessage httpResponseMessage)
    {
        if (!httpResponseMessage.IsSuccessStatusCode)
            throw await GetHttpException(httpResponseMessage);

        return await GetDeserializedResponse<TResult>(httpResponseMessage);
    }

    /// <summary>
    /// Gets the HTTP exception.
    /// </summary>
    /// <param name="httpResponseMessage">The HTTP response message.</param>
    /// <returns></returns>
    private async Task<Exception> GetHttpException(HttpResponseMessage httpResponseMessage)
    {
        // First set the error message so it can be retrieved
        LastError = await GetDeserializedResponse<Error>(httpResponseMessage);

        // Throw specific exceptions for some headers.
        switch (httpResponseMessage.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
                return new UnauthorizedException();

            case HttpStatusCode.TooManyRequests:
                return new TooManyRequestsException();

            // For every other unsuccessful HTTP code, throw an HttpRequestException
            default:
                try
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    return e;
                }
                break;
        }

        // This should not happen
        return new Exception($"HttpRequestException occurred with message '{LastError?.Message ?? "Unknown error"}'");
    }

    /// <summary>
    /// Gets the deserialized response from the API.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="httpResponseMessage">The HTTP response message.</param>
    /// <returns></returns>
    private async Task<TResult?> GetDeserializedResponse<TResult>(HttpResponseMessage httpResponseMessage)
    {
        var msgString = await httpResponseMessage.Content.ReadAsStringAsync();

        try
        {
            return JsonConvert.DeserializeObject<TResult>(msgString);
        }
        catch
        {
            return default;
        }
    }
}