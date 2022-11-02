// See https://aka.ms/new-console-template for more information
using DoodStream.Code;

//AccountAPI info = new AccountAPI("7284y4hyippga99ga745");

//Console.WriteLine("------------- Acount Info -------------");
//var data = info.GetAccountInfo().Result;
//Console.WriteLine($"Email: {data.Result.Email}");
//Console.WriteLine($"Balance: {data.Result.Balance}");
//Console.WriteLine($"Storage Left: {data.Result.Storage_Left}");
//Console.WriteLine($"Storage Used: {data.Result.Storage_Used}");


//Console.WriteLine("------------- Acount Report -------------");
//var statsData = info.GetAccountStats(1000).Result;
//if (statsData.Result != null)
//{
//    var totalProfit = statsData.Result.Sum(x => decimal.Parse(x.Profit_Total));
//    Console.WriteLine($"ToTal Profit: {decimal.Round(totalProfit, 5)}");
//}
//else
//    Console.WriteLine("No Data in Report");


//Console.WriteLine("------------- DMCA Report -------------");
//var dmcaData = info.GetDMCAList().Result;
//Console.WriteLine($"DMCA: {dmcaData.Result.Length}");


var upload = new UploadAPI("7284y4hyippga99ga745");

//Console.WriteLine("------------- Upload Server Url -------------");
//var serverUrlData = upload.GetServerUrlUpload().Result;
//Console.WriteLine($"Upload Server: {serverUrlData.Result}");


Console.WriteLine("------------- Upload File From Path -------------");
var fileDataResponse = upload.UploadFile("D:\\Vid\\OBS\\Vid\\Free web hosting.mp4").Result;
if (fileDataResponse != null)
{
    var fileData = fileDataResponse.Result[0];
    Console.WriteLine($"Title: {fileData.Title}");
    Console.WriteLine($"File Code: {fileData.Filecode}");
    Console.WriteLine($"Embed Url: {fileData.Protected_Embed}");
    Console.WriteLine($"Download Url: {fileData.Protected_Dl}");
}
else
{
    Console.WriteLine("No Data From File, may be error");
}