using Newtonsoft.Json;
using System.Collections.Generic;

namespace TeamCityService
{
    public class BuildChangeListResponse
    {
        public int count { get; set; }
        public string href { get; set; }
        public IList<BuildChange> change { get; set; }
    }

    public class BuildChange
    {
        public int id { get; set; }
        public string version { get; set; }
        public string username { get; set; }
        public string date { get; set; }
        public string href { get; set; }
        public string webUrl { get; set; }
    }

    public class BuildChanges
    {
        public int id { get; set; }
        public string version { get; set; }
        public string username { get; set; }
        public string date { get; set; }
        public string href { get; set; }
        public string webUrl { get; set; }
        public string comment { get; set; }
        public User user { get; set; }
        public Files files { get; set; }
        public VcsRootInstance vcsRootInstance { get; set; }
    }

    public class User
    {
        public string username { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string href { get; set; }
    }

    public class File
    {
        [JsonProperty(PropertyName = "before-revision")]
        public string beforerevision { get; set; }

        [JsonProperty(PropertyName = "after-revision")]
        public string afterRevision { get; set; }

        public string file { get; set; }

        [JsonProperty(PropertyName = "relative-file")]
        public string relativeFile { get; set; }
    }

    public class Files
    {
        public List<File> file { get; set; }
    }
}
