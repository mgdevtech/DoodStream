namespace DoodStream.Dtos.Account;

public class DMCADto : HeaderMessageDto
{
    public ResultData[] Result { get; set; }

    public class ResultData
    {
        public string Reported_On { get; set; }
        public string Protected_Download { get; set; }
        public string Protected_Embed { get; set; }
        public string File_Code { get; set; }
        public string Fld_Id { get; set; }
        public string Disabled_On { get; set; }
    }
}