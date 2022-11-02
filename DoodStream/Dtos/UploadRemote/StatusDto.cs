namespace DoodStream.Dtos.UploadRemote;

public class StatusDto : HeaderMessageDto
{
    public ResultData[] Result { get; set; }

    public class ResultData
    {
        public string Bytes_Total { get; set; }
        public string Created { get; set; }
        public string Remote_Url { get; set; }
        public string Status { get; set; }
        public string File_Code { get; set; }
        public string Bytes_Downloaded { get; set; }
        public string Folder_Id { get; set; }
    }
}