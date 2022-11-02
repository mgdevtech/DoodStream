using DoodStream.Dtos.Folder;

namespace DoodStream.Code;

public class ManageFolderAPI : BaseConfigure
{
    public ManageFolderAPI(string key) : base(key)
    {
    }

    /// <summary>
    /// Create a folder
    /// </summary>
    /// <param name="name">Name of the folder</param>
    /// <param name="parentId">Parent folder ID</param>
    /// <returns>CreateDto</returns>
    public async Task<CreateDto> CreateFolderAsync(string name, string? parentId = null)
    {
        data.Add("name", name);
        if (!string.IsNullOrEmpty(parentId))
            data.Add("parent_id", parentId);
        return await GetAPI<CreateDto>("folder", "create", data);
    }

    /// <summary>
    /// Rename folder
    /// </summary>
    /// <param required name="folderId">folder Id</param>
    /// <param required name="newName">New Name</param>
    /// <returns>RenameDto</returns>
    public async Task<RenameDto> RenameFolderAsync(string folderId, string newName)
    {
        data.Add("fld_id", folderId);
        data.Add("name", newName);
        return await GetAPI<RenameDto>("folder", "rename", data);
    }
}