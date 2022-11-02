namespace DoodStream.Dtos.File;

public class StatusDto : HeaderMessageDto
{
    public ResultData[] Result { get; set; }

    public class ResultData
    {
        public string Status { get; set; }
        public string Filecode { get; set; }
    }
}