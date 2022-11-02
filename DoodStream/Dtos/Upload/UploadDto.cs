namespace DoodStream.Dtos.Upload;

public class UploadDto : HeaderMessageDto
{
    public ResultData[] Result { get; set; }
    public class ResultData
    {
        public string Download_Url { get; set; }
        public string Single_Img { get; set; }
        public int Status { get; set; }
        public string Filecode { get; set; }
        public string Splash_Img { get; set; }
        public int Canplay { get; set; }
        public string Size { get; set; }
        public string Length { get; set; }
        public string Uploaded { get; set; }
        public string Protected_Embed { get; set; }
        public string Protected_Dl { get; set; }
        public string Title { get; set; }
    }
}