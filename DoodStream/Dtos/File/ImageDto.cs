namespace DoodStream.Dtos.File;

public class ImageDto : HeaderMessageDto
{
    public ResultData[] Result { get; set; }

    public class ResultData
    {
        public int Status { get; set; }
        public string Filecode { get; set; }
        public string Title { get; set; }
        public string Single_Img { get; set; }
        public string Thumb_Img { get; set; }
        public string Splash_Img { get; set; }
    }
}