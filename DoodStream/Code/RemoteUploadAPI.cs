using DoodStream.Dtos.UploadRemote;

namespace DoodStream.Code;

public class RemoteUploadAPI : BaseConfigure
{
    public RemoteUploadAPI(string key) : base(key)
    {
    }

    /// <summary>
    /// Upload files using direct links
    /// </summary>
    /// <param name="url">URL to upload (ex:http,s://xyz.xyz/file.mp4)</param>
    /// <param name="fld_id">To upload inside a folder</param>
    /// <param name="new_title">To set new title</param>
    /// <returns></returns>
    public async Task<AddLinkDto> AddLinkAsync(string url, string? fld_id = null, string? new_title = null)
    {
        data.Add("url", url);
        if (!string.IsNullOrEmpty(fld_id))
            data.Add("fld_id", fld_id);
        if (!string.IsNullOrEmpty(new_title))
            data.Add("new_title", new_title);
        return await GetAPI<AddLinkDto>("upload", "url", data);
    }

    /// <summary>
    /// Remote Upload List & Status
    /// </summary>
    /// <returns>ListDto</returns>
    public async Task<ListDto> GetUploadLinkList()
    {
        return await GetAPI<ListDto>("urlupload", "list");
    }

    /// <summary>
    /// Remote Upload Status
    /// </summary>
    /// <param name="file_code">File Code</param>
    /// <returns>StatusDto</returns>
    public async Task<StatusDto> GetUploadLinkStatus(string file_code)
    {
        data.Add("file_code", file_code);
        return await GetAPI<StatusDto>("urlupload", "status", data);
    }

    /// <summary>
    /// Get total & used remote upload slots
    /// </summary>
    /// <returns>SlotsDto</returns>
    public async Task<SlotsDto> GetRemoteSlotsInfo()
    {
        return await GetAPI<SlotsDto>("urlupload", "slots");
    }

    /// <summary>
    /// Perform various actions on remote upload
    /// </summary>
    /// <param name="restart_errors">Restart all errors Default 1 (1 or 0)</param>
    /// <param name="clear_errors">Clear all errors (1 or 0)</param>
    /// <param name="clear_all">Clear all (1 or 0)</param>
    /// <param name="delete_code">Delete a transfer, pass file_code (1 or 0)</param>
    /// <returns>ActionsDto</returns>
    public async Task<ActionsDto> GetActions(string restart_errors = "1", string? clear_errors = null, string? clear_all = null, string? delete_code = null)
    {
        data.Add("restart_errors", restart_errors);
        if (!string.IsNullOrEmpty(clear_errors))
            data.Add("clear_errors", clear_errors);
        if (!string.IsNullOrEmpty(clear_all))
            data.Add("clear_all", clear_all);
        if (!string.IsNullOrEmpty(delete_code))
            data.Add("delete_code", delete_code);
        return await GetAPI<ActionsDto>("urlupload", "actions", data);
    }
}