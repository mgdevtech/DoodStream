using DoodStream.Dtos.File;

namespace DoodStream.Code;

public class ManageExtraAPI : BaseConfigure
{
    private string BaseUrl = "//dood.re";
    private InfoDto Info;
    public ManageExtraAPI(string fileCode, string key) : base(key)
    {
        if (Info == null)
        {
            Info = new ManageFileAPI(Key).GetFileInfoAsync(fileCode).Result;
        }
    }

    /// <summary>
    /// Load splash image via URL directly
    /// ex: (https://dood.so/e/xxx?c_poster=https://example.com/image.jpg)
    /// </summary>
    /// <param name="imageUrl">Image URL to add as splash Image</param>
    /// <returns>Embed URL OR ""</returns>
    public string RemoteSplashImage(string imageUrl)
    {
        if (Info == null)
            return string.Empty;
        return $"{BaseUrl}{Info.Result[0].Protected_Embed}?c_poster={imageUrl}";
    }

    /// <summary>
    /// Remote subtitle File
    /// Load multiple subtitles via URL directly
    /// ex: (https://dood.so/e/xxx?c1_file=https://example.com/sub.vtt&c1_label=English)
    /// </summary>
    /// <param name="fileURL">Subtitle URL (srt or vtt)</param>
    /// <param name="fileLable">Subtitle language or any lable</param>
    /// <returns>Embed Url With Subtitle or ""</returns>
    public string RemoteSubTitleFile(string fileURL, string fileLable)
    {
        if (Info == null)
            return string.Empty;
        return $"{BaseUrl}{Info.Result[0].Protected_Embed}?c1_file={fileURL}&c1_label={fileLable}";
    }

    /// <summary>
    /// Remote subtitle JSON
    /// Load multiple subtitles via URL in JSON format
    /// ex: https://dood.so/e/xxx?subtitle_json=https://example.com/sub.json
    /// </summary>
    /// <param name="jsonURL"></param>
    /// <returns>Embed Url or ""</returns>
    public string RemoteSubtitleJson(string jsonURL)
    {
        if (Info == null)
            return string.Empty;
        return $"{BaseUrl}{Info.Result[0].Protected_Embed}?subtitle_json={jsonURL}";
    }
}