namespace DoodStream.Dtos.File;
/// <summary>
/// List Download Files
/// </summary>
public class ListDlDto : HeaderMessageDto
{
    public ResultData Result { get; set; }

    public class ResultData
    {
        public int Total_Pages { get; set; }
        public File[] Files { get; set; }
        public string Results_Total { get; set; }
        public int Results { get; set; }
    }

    public class File
    {
        public string Download_Url { get; set; }
        public string Single_Img { get; set; }
        public string File_Code { get; set; }
        public int Canplay { get; set; }
        public string Length { get; set; }
        public string Views { get; set; }
        public string Uploaded { get; set; }
        public string _Public { get; set; }
        public string Fld_Id { get; set; }
        public string Title { get; set; }
    }

}