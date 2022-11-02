namespace DoodStream.Dtos.Account;

public class InfoDto : HeaderMessageDto
{
    public ResultData Result { get; set; }

    public class ResultData
    {
        public string Email { get; set; }
        public string Balance { get; set; }
        public string Storage_Used { get; set; }
        public string Storage_Left { get; set; }
        public string Premim_Expire { get; set; }
    }

}