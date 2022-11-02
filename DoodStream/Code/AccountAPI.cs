using DoodStream.Dtos.Account;

namespace DoodStream.Code;

public class AccountAPI : BaseConfigure
{
    public AccountAPI(string key) : base(key)
    {
    }

    /// <summary>
    /// Get Account Info
    /// </summary>
    /// <returns>InfoDto</returns>
    public async Task<InfoDto> GetAccountInfo()
    {
        return await GetAPI<InfoDto>("account", "info", data);
    }

    /// <summary>
    /// Get Account Stats
    /// </summary>
    /// <param name="last">Last x days report</param>
    /// <param name="from_date">From date - YYYY-MM-DD</param>
    /// <param name="to_date">To date - YYYY-MM-DD</param>
    /// <returns>ReportsDto</returns>
    public async Task<ReportsDto> GetAccountStats(int? last = null, DateOnly? from_date = null, DateOnly? to_date = null)
    {
        if (last.HasValue)
            data.Add("last", last.Value.ToString());
        if (from_date.HasValue)
            data.Add("from_date", from_date.Value.ToString("YYYY-MM-DD"));
        if (to_date.HasValue)
            data.Add("to_date", to_date.Value.ToString("YYYY-MM-DD"));

        return await GetAPI<ReportsDto>("account", "stats", data);
    }

    /// <summary>
    /// Get DMCA List
    /// </summary>
    /// <param name="per_page">Results per page (default 500)</param>
    /// <param name="page">Pagination</param>
    /// <returns>DMCADto</returns>
    public async Task<DMCADto> GetDMCAList(int? per_page = null, int? page = null)
    {
        if (per_page.HasValue)
            data.Add("per_page", per_page.Value.ToString());
        if (page.HasValue)
            data.Add("page", page.Value.ToString());

        return await GetAPI<DMCADto>("dmca", "list", data);
    }
}