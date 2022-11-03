using DoodStream.Extentions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace DoodStream.Code;

public class BaseConfigure
{
    public string Key;
    private string BaseUrl = "https://doodapi.com/api/";
    public Dictionary<string, string> data = new Dictionary<string, string>();

    public BaseConfigure(string key)
    {
        if (string.IsNullOrEmpty(Key))
        {
            lock (this)
            {
                Key = key;
            }
        }
    }

    private string GenerateUrlQueryString(Dictionary<string, string> collection)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append($"key={Key}");
        foreach (var kvp in collection)
        {
            builder.Append($"&{kvp.Key}={kvp.Value}");
        }
        return builder.ToString() ?? string.Empty;
    }

    public async Task<T> GetAPI<T>(string path, string method, Dictionary<string, string> req = null)
    {
        if (string.IsNullOrEmpty(Key))
            return default(T);

        var url = $"{BaseUrl}{path}/{method}?{GenerateUrlQueryString(req)}";

        using HttpClient client = new();
        using var request = new HttpRequestMessage(new HttpMethod("GET"), url);
        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            return default(T);

        var responseString = await response.Content.ReadAsStringAsync();

        if (responseString.Contains("Not enough reports data", StringComparison.OrdinalIgnoreCase))
            responseString = responseString.Replace("\"result\":{}", "");

        var content = JsonConvert.DeserializeObject<T>(responseString);

        data.Clear();

        return content ?? default(T);
    }

    public async Task<T> PostAPI<T>(IFormFile file, string uploadUrl, string? folderId = null)
    {
        if (string.IsNullOrEmpty(Key))
            return default(T);

        using HttpClient client = new();
        using var request = new HttpRequestMessage(new HttpMethod("POST"), $"{uploadUrl}?{Key}");

        request.Headers.TryAddWithoutValidation("Accept", "application/json");

        var multipartContent = new MultipartFormDataContent();
        multipartContent.Add(new StringContent(Key), "api_key");
        multipartContent.Add(new ByteArrayContent(file.ConvertToByte()), "file", file.FileName);
        if (!string.IsNullOrEmpty(folderId))
            multipartContent.Add(new StringContent(folderId), "fld_id");

        request.Content = multipartContent;

        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        { data.Clear(); return default(T); }

        var content = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

        data.Clear();

        return content ?? default(T);
    }

    public async Task<T> PostAPI<T>(string path, string uploadUrl, string? folderId = null)
    {
        if (string.IsNullOrEmpty(Key))
            return default(T);

        using HttpClient client = new();
        using var request = new HttpRequestMessage(new HttpMethod("POST"), $"{uploadUrl}?{Key}");

        request.Headers.TryAddWithoutValidation("Accept", "application/json");

        var multipartContent = new MultipartFormDataContent();
        multipartContent.Add(new StringContent(Key), "api_key");
        var file = File.ReadAllBytes(path);
        multipartContent.Add(new ByteArrayContent(file), "file", Path.GetFileName(path));
        if (!string.IsNullOrEmpty(folderId))
            multipartContent.Add(new StringContent(folderId), "fld_id");

        request.Content = multipartContent;


        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        { data.Clear(); return default(T); }

        var content = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

        data.Clear();

        return content ?? default(T);
    }
}