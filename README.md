# ![logo-s](https://user-images.githubusercontent.com/99098261/199379369-158b9439-0b5b-4521-ae7c-5103a8815892.png)
# DoodStream C# .Net Core Lib

## Content Table
[Manage Account](#account-info)\
[Manage Upload](#manage-upload)\
[Manage Remote Upload](#manage-remote-upload)\
[Manage Folders](#manage-folders)\
[Manage Files](#manage-files)\
[Manage Extra](#manage-extra)


## Account Info
- Get Account Info
- Get Account Stats
- Get DMCA List
```C#
var info = new AccountAPI("key");

// Get Account Info 
info.GetAccountInfo();

// Get Account Stats
info.GetAccountStats();
/// <summary>
/// Get Account Stats
/// </summary>
/// <param name="last">Last x days report</param>
/// <param name="from_date">From date - YYYY-MM-DD</param>
/// <param name="to_date">To date - YYYY-MM-DD</param>
/// <returns>ReportsDto</returns>
info.GetAccountStats(30, 2022-10-01, 2022-11-02); (optinal)

// Get DMCA List
info.GetDMCAList();
/// <summary>
/// Get DMCA List
/// </summary>
/// <param name="per_page">Results per page (default 500)</param>
/// <param name="page">Pagination</param>
/// <returns>DMCADto</returns>
info.GetDMCAList(25, 1); (optinal)
```


## Manage Upload
- Get Server Upload URL
- Copy/Clone File
- To Do Solving by doodstream server errors
- [ ] Upload File To Doodstream From IFormFile
- [ ] Upload File To Doodstream From Path

```C#
var upload = new UploadAPI("key");

//Get Server Upload URL
upload.GetServerUrlUpload();

//Copy / Clone your's or other's file
upload.CopyFile("xxxxx");

/// <summary>
/// Copy / Clone your's or other's file
/// </summary>
/// <param name="file_code">File Code</param>
/// <param name="fld_id">Folder Id</param>
/// <returns>CopyDto</returns>
upload.CopyFile("xxxxx", "xxxxx");
```

## Manage Remote Upload
- Add Link
- Get Upload Link List
- Get Upload Link Status
- Get Remote Slots Info
- Get Actions

```c#
var remote = new RemoteUploadAPI("key");
/// <summary>
/// Upload files using direct links
/// </summary>
/// <param name="url">URL to upload (ex:http,s://xyz.xyz/file.mp4)</param>
/// <param name="fld_id">To upload inside a folder</param>
/// <param name="new_title">To set new title</param>
/// <returns></returns>

remote.AddLinkAsync("http,s://xyz.xyz/file.mp4");
remote.AddLinkAsync("http,s://xyz.xyz/file.mp4","xxx","New Video Title"); (optinal)

/// <summary>
/// Remote Upload List & Status
/// </summary>
/// <returns>ListDto</returns>

remote.GetUploadLinkList();

/// <summary>
/// Remote Upload Status
/// </summary>
/// <param name="file_code">File Code</param>
/// <returns>StatusDto</returns>

remote.GetUploadLinkStatus("xxxxx");

/// <summary>
/// Get total & used remote upload slots
/// </summary>
/// <returns>SlotsDto</returns>

remote.GetRemoteSlotsInfo();

/// <summary>
/// Perform various actions on remote upload
/// </summary>
/// <param name="restart_errors">Restart all errors Default 1 (1 or 0)</param>
/// <param name="clear_errors">Clear all errors (1 or 0)</param>
/// <param name="clear_all">Clear all (1 or 0)</param>
/// <param name="delete_code">Delete a transfer, pass file_code (1 or 0)</param>
/// <returns>ActionsDto</returns>

remote.GetActions();
remote.GetActions("0","1","1","1"); (optinal)
```

## Manage Folders
- Greate Folder
- Rename Folder

```c#
var folder = new ManageFolderAPI("key");

/// <summary>
/// Create a folder
/// </summary>
/// <param name="name">Name of the folder</param>
/// <param name="parentId">Parent folder ID</param>
/// <returns>CreateDto</returns>

folder.CreateFolderAsync("My Videos");
folder.CreateFolderAsync("My Videos","xxxx"); (optinal)

/// <summary>
/// Rename folder
/// </summary>
/// <param required name="folderId">folder Id</param>
/// <param required name="newName">New Name</param>
/// <returns>RenameDto</returns>

folder.RenameFolderAsync("xxxx","New Folder Title");
```

## Manage Files
- Dounload Files List
- Check status of your file
- Get file info
- Get file splash, single or thumbnail image
- Rename your file
- Search your files

```c#
var file = new ManageFileAPI("key");

/// <summary>
/// Dounload Files List
/// </summary>
/// <param name="page">Page is Pagination (Ex: 1 or 2 or 3)</param>
/// <param name="per_page">Per Page is Max videos per page (Ex: 10 or 20 or 50)</param>
/// <param name="fld_id">Folder Id is Videos inside a folder</param>
/// <returns>ListDlDto</returns>

file.GetFileDounloadListAsync();
file.GetFileDounloadListAsync("1","100","xxxx");

/// <summary>
/// Check status of your file
/// Can you use more than one file_code (ex: file_code=xxxxxx,xxxxxx,xxxxxxx)
/// </summary>
/// <param name="file_code">File Code</param>
/// <returns>StatusDto</returns>

file.GetFileStatusAsync("xxxx");

/// <summary>
/// Get file info
/// Can you use more than one file_code (ex: file_code=xxxxxx,xxxxxx,xxxxxxx)
/// </summary>
/// <param name="file_code">File Code</param>
/// <returns>InfoDto</returns>

file.GetFileInfoAsync("xxxx");

/// <summary>
/// Get file splash, single or thumbnail image
/// Can you use more than one file_code (ex: file_code=xxxxxx,xxxxxx,xxxxxxx)
/// </summary>
/// <param name="file_code">File Code</param>
/// <returns>ImageDto</returns>

file.GetFileImagesAsync("xxxx");

/// <summary>
/// Rename your file
/// </summary>
/// <param name="file_code">File Code</param>
/// <param name="title">New File Title</param>
/// <returns>RenameDto</returns>

file.RenameFileAsync("xxxx","New File Title");

/// <summary>
/// Search your files
/// </summary>
/// <param name="search_term">Search term</param>
/// <returns></returns>

file.SearchVideosAsync("video 1");
```

## Manage Extra
- Load splash image via URL directly
- Remote subtitle File
- Remote subtitle JSON

```C#
// xxxx = file code you want generate extra
var extra = new ManageExtraAPI("xxxx","key");

/// <summary>
/// Load splash image via URL directly
/// ex: (https://dood.so/e/xxx?c_poster=https://example.com/image.jpg)
/// </summary>
/// <param name="imageUrl">Image URL to add as splash Image</param>
/// <returns>Embed URL OR ""</returns>

extra.RemoteSplashImage("https://example.com/image.jpg");

/// <summary>
/// Remote subtitle File
/// Load multiple subtitles via URL directly
/// ex: (https://dood.so/e/xxx?c1_file=https://example.com/sub.vtt&c1_label=English)
/// </summary>
/// <param name="fileURL">Subtitle URL (srt or vtt)</param>
/// <param name="fileLable">Subtitle language or any lable</param>
/// <returns>Embed Url With Subtitle or ""</returns>

extra.RemoteSubTitleFile("https://example.com/sub.vtt","English");

/// <summary>
/// Remote subtitle JSON
/// Load multiple subtitles via URL in JSON format
/// ex: https://dood.so/e/xxx?subtitle_json=https://example.com/sub.json
/// </summary>
/// <param name="jsonURL"></param>
/// <returns>Embed Url or ""</returns>

extra.RemoteSubtitleJson("https://example.com/sub.json");
```

### Json Format
```json
[
 {"src":"https://example.com/name_en.vtt", "label":"English", default: true},
 {"src":"https://example.com/name_fr.vtt", "label":"French"}
]
```