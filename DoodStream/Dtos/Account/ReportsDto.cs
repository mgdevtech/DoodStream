namespace DoodStream.Dtos.Account;

public class ReportsDto : HeaderMessageDto
{
    public ResultData[] Result { get; set; }
    public class ResultData
    {
        public string Profit_Views { get; set; }
        public string Downloads { get; set; }
        public string Views { get; set; }
        public string Day { get; set; }
        public string Profit_Total { get; set; }
    }
}