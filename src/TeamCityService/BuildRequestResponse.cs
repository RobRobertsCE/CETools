using System.Collections.Generic;

namespace TeamCityService
{
    public class BuildRequestResponse
    {
        public int count { get; set; }
        public string href { get; set; }
        public string nextHref { get; set; }
        public List<Build> build { get; set; }
    }
}
