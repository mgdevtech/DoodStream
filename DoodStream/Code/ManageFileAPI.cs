using DoodStream.Dtos.File;

namespace DoodStream.Code;

public class ManageFileAPI : BaseConfigure
{
    public ManageFileAPI(string key) : base(key)
    {
    }

    /// <summary>
    /// Dounload Files List
    /// </summary>
    /// <param name="page">Page is Pagination (Ex: 1 or 2 or 3)</param>
    /// <param name="per_page">Per Page is Max videos per page (Ex: 10 or 20 or 50)</param>
    /// <param name="fld_id">Folder Id is Videos inside a folder</param>
    /// <returns>ListDlDto</returns>
    public async Task<ListDlDto> GetFileDounloadListAsync(string? page = null, string? per_page = null, string? fld_id = null)
    {
        if (!string.IsNullOrEmpty(page))
            data.Add("page", page);
        if (!string.IsNullOrEmpty(per_page))
            data.Add("per_page", per_page);
        if (!string.IsNullOrEmpty(fld_id))
            data.Add("fld_id", fld_id);
        return await GetAPI<ListDlDto>("file", "list", data);
    }

    /// <summary>
    /// Check status of your file
    /// Can you use more than one file_code (ex: file_code=xxxxxx,xxxxxx,xxxxxxx)
    /// </summary>
    /// <param name="file_code">File Code</param>
    /// <returns>StatusDto</returns>
    public async Task<StatusDto> GetFileStatusAsync(string file_code)
    {
        data.Add("file_code", file_code);
        return await GetAPI<StatusDto>("file", "status", data);
    }

    /// <summary>
    /// Get file info
    /// Can you use more than one file_code (ex: file_code=xxxxxx,xxxxxx,xxxxxxx)
    /// </summary>
    /// <param name="file_code">File Code</param>
    /// <returns>InfoDto</returns>
    public async Task<InfoDto> GetFileInfoAsync(string file_code)
    {
        data.Add("file_code", file_code);
        return await GetAPI<InfoDto>("file", "info", data);
    }

    /// <summary>
    /// Get file splash, single or thumbnail image
    /// Can you use more than one file_code (ex: file_code=xxxxxx,xxxxxx,xxxxxxx)
    /// </summary>
    /// <param name="file_code">File Code</param>
    /// <returns>ImageDto</returns>
    public async Task<ImageDto> GetFileImagesAsync(string file_code)
    {
        data.Add("file_code", file_code);
        return await GetAPI<ImageDto>("file", "image", data);
    }

    /// <summary>
    /// Rename your file
    /// </summary>
    /// <param name="file_code">File Code</param>
    /// <param name="title">New File Title</param>
    /// <returns>RenameDto</returns>
    public async Task<RenameDto> RenameFileAsync(string file_code, string title)
    {
        data.Add("file_code", file_code);
        data.Add("title", title);
        return await GetAPI<RenameDto>("file", "rename", data);
    }

    /// <summary>
    /// Search your files
    /// </summary>
    /// <param name="search_term">Search term</param>
    /// <returns></returns>
    public async Task<SearchDto> SearchVideosAsync(string search_term)
    {
        data.Add("search_term", search_term);
        return await GetAPI<SearchDto>("search", "videos", data);
    }
}