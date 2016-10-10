using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCityService
{
    public class BuildDetails
    {
        public string id { get; set; }
        public string buildTypeId { get; set; }
        public string number { get; set; }
        public string status { get; set; }
        public string state { get; set; }
        public string branchName { get; set; }
        public bool defaultBranch { get; set; }
        public string href { get; set; }
        public string webUrl { get; set; }
        public string statusText { get; set; }
        public BuildType buildType { get; set; }
        public string queuedDate { get; set; }
        public string startDate { get; set; }
        public string finishDate { get; set; }
        public Triggered triggered { get; set; }
        public LastChanges lastChanges { get; set; }
        public Changes changes { get; set; }
        public Revisions revisions { get; set; }
        public Agent agent { get; set; }
        public TestOccurrences testOccurrences { get; set; }
        public Artifacts artifacts { get; set; }
        public RelatedIssues relatedIssues { get; set; }
        public Properties properties { get; set; }
        public Statistics statistics { get; set; }
    }

    public class BuildType
    {
        public string id { get; set; }
        public string name { get; set; }
        public string projectName { get; set; }
        public string projectId { get; set; }
        public string href { get; set; }
        public string webUrl { get; set; }
    }

    public class Triggered
    {
        public string type { get; set; }
        public string details { get; set; }
        public string date { get; set; }
    }

    public class Change
    {
        public int id { get; set; }
        public string version { get; set; }
        public string username { get; set; }
        public string date { get; set; }
        public string href { get; set; }
        public string webUrl { get; set; }
    }

    public class LastChanges
    {
        public int count { get; set; }
        public List<Change> change { get; set; }
    }

    public class Changes
    {
        public string href { get; set; }
    }

    public class VcsRootInstance
    {
        public string id { get; set; }
        [JsonProperty(PropertyName = "root-id")]
        public string rootid { get; set; }
        public string name { get; set; }
        public string href { get; set; }
    }

    public class Revision
    {
        public string version { get; set; }
        [JsonProperty(PropertyName = "root-instance")]
        public VcsRootInstance rootinstance { get; set; }
    }

    public class Revisions
    {
        public int count { get; set; }
        public List<Revision> revision { get; set; }
    }

    public class Agent
    {
        public int id { get; set; }
        public string name { get; set; }
        public int typeId { get; set; }
        public string href { get; set; }
    }

    public class TestOccurrences
    {
        public int count { get; set; }
        public string href { get; set; }
        public int passed { get; set; }
        public bool @default { get; set; }
    }

    public class Artifacts
    {
        public string href { get; set; }
    }

    public class RelatedIssues
    {
        public string href { get; set; }
    }

    public class Property
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Properties
    {
        public int count { get; set; }
        public List<Property> property { get; set; }
    }

    public class Statistics
    {
        public string href { get; set; }
    }
}
