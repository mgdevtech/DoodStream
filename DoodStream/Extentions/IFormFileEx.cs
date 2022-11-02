using Microsoft.AspNetCore.Http;

namespace DoodStream.Extentions;

public static class IFormFileEx
{
    public static byte[] ConvertToByte(this IFormFile file)
    {
        var f = file.OpenReadStream();
        var Ibr = new BinaryReader(f);
        var bytes = Ibr.ReadBytes((Int32)f.Length);
        return bytes;
    }
}