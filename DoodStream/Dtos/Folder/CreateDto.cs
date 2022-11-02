namespace DoodStream.Dtos.Folder;

public class CreateDto : HeaderMessageDto
{
    public ResultData Result { get; set; }

    public class ResultData
    {
        public string Fld_Id { get; set; }
    }
}