namespace DoodStream.Dtos.Upload;

public class CopyDto : HeaderMessageDto
{
    public ResultData Result { get; set; }
    public class ResultData
    {
        public string Embed_Url { get; set; }
        public string Download_Url { get; set; }
        public string Protected_Download { get; set; }
        public string Protected_Embed { get; set; }
        public string Filecode { get; set; }
    }
}