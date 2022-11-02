using DoodStream.Dtos.Upload;

namespace DoodStream.Code;

public class UploadAPI : BaseConfigure
{
    public UploadAPI(string key) : base(key)
    {
    }

    /// <summary>
    /// Get Server Url Upload
    /// </summary>
    /// <returns>ServerDto</returns>
    public async Task<ServerDto> GetServerUrlUpload()
    {
        return await GetAPI<ServerDto>("upload", "server", data);
    }

    /// <summary>
    /// Upload File From Client Device
    /// </summary>
    /// <param name="file">File to upload</param>
    /// <param name="folderId">Folder Id</param>
    /// <returns>UploadDto</returns>
    //public async Task<UploadDto> UploadFile(IFormFile file, string? folderId = null)
    //{
    //    var uploadUrl = await GetServerUrlUpload();
    //    return await PostAPI<UploadDto>(file, uploadUrl.Result, folderId);
    //}

    /// <summary>
    /// Upload File From Server Path
    /// </summary>
    /// <param name="file">File Path</param>
    /// <param name="folderId">Folder Id</param>
    /// <returns>UploadDto</returns>
    //public async Task<UploadDto> UploadFile(string file, string? folderId = null)
    //{
    //    var uploadUrl = GetServerUrlUpload().Result.Result;
    //    return await PostAPI<UploadDto>(file, uploadUrl, folderId);
    //}

    /// <summary>
    /// Copy / Clone your's or other's file
    /// </summary>
    /// <param name="file_code">File Code</param>
    /// <param name="fld_id">Folder Id</param>
    /// <returns>CopyDto</returns>
    public async Task<CopyDto> CopyFile(string file_code, string? fld_id = null)
    {
        data.Add("file_code", file_code);
        if (!string.IsNullOrEmpty(fld_id))
            data.Add("fld_id", fld_id);
        return await GetAPI<CopyDto>("file", "clone", data);
    }
}
