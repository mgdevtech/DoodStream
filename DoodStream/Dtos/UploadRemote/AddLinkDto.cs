namespace DoodStream.Dtos.UploadRemote;

public class AddLinkDto : HeaderMessageDto
{
    public string New_Title { get; set; }
    public string Total_Slots { get; set; }
    public string Used_Slots { get; set; }
    public ResultData Result { get; set; }

    public class ResultData
    {
        public string Filecode { get; set; }
    }
}
