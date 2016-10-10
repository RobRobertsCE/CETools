namespace TeamCityService
{
    public class EndpointBase
    {
        protected static string BuildUrl(string urlSuffix)
        {
            return string.Format("{0}{1}", Constants.AdvantageRootUrl, urlSuffix);
        }
    }
}
