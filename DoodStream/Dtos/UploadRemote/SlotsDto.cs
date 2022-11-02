namespace DoodStream.Dtos.UploadRemote;

public class SlotsDto : HeaderMessageDto
{
    public string Total_Slots { get; set; }
    public string Used_Slots { get; set; }
}