using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TeamCityService
{
    public class Build : EndpointBase
    {
        // https://teamcity.pfestore.com/httpAuth/app/rest/builds/buildType:Advantage_Build
        /*
        {
    "id": 1920,
    "buildTypeId": "Advantage_Build",
    "number": "1403",
    "status": "SUCCESS",
    "state": "finished",
    "branchName": "refs/heads/develop",
    "defaultBranch": true,
    "href": "/httpAuth/app/rest/builds/id:1920",
    "webUrl": "https://teamcity.pfestore.com/viewLog.html?buildId=1920&buildTypeId=Advantage_Build",
    "statusText": "Tests passed: 1462",
    "buildType": {
        "id": "Advantage_Build",
        "name": "Build",
        "projectName": "Advantage",
        "projectId": "Advantage",
        "href": "/httpAuth/app/rest/buildTypes/id:Advantage_Build",
        "webUrl": "https://teamcity.pfestore.com/viewType.html?buildTypeId=Advantage_Build"
    },
    "queuedDate": "20160817T145307+0000",
    "startDate": "20160817T145312+0000",
    "finishDate": "20160817T150032+0000",
    "triggered": {
        "type": "vcs",
        "details": "jetbrains.git",
        "date": "20160817T145307+0000"
    },
    "lastChanges": {
        "count": 1,
        "change": [
            {
                "id": 2033,
                "version": "bd038a1c6567735f8f904aa7bf460c66cbd434d2",
                "username": "rroberts",
                "date": "20160817T143736+0000",
                "href": "/httpAuth/app/rest/changes/id:2033",
                "webUrl": "https://teamcity.pfestore.com/viewModification.html?modId=2033&personal=false"
            }
        ]
    },
    "changes": {
        "href": "/httpAuth/app/rest/changes?locator=build:(id:1920)"
    },
    "revisions": {
        "count": 1,
        "revision": [
            {
                "version": "bd038a1c6567735f8f904aa7bf460c66cbd434d2",
                "vcs-root-instance": {
                    "id": "3",
                    "vcs-root-id": "Advantage_HttpsGithubComCenterEdgeAdvantageGitRefsHeadsDevelop",
                    "name": "https://github.com/CenterEdge/Advantage.git#refs/heads/develop",
                    "href": "/httpAuth/app/rest/vcs-root-instances/id:3"
                }
            }
        ]
    },
    "agent": {
        "id": 13,
        "name": "EC2-i-73c2118b",
        "typeId": 5,
        "href": "/httpAuth/app/rest/agents/id:13"
    },
    "testOccurrences": {
        "count": 1462,
        "href": "/httpAuth/app/rest/testOccurrences?locator=build:(id:1920)",
        "passed": 1462,
        "default": false
    },
    "artifacts": {
        "href": "/httpAuth/app/rest/builds/id:1920/artifacts/children/"
    },
    "relatedIssues": {
        "href": "/httpAuth/app/rest/builds/id:1920/relatedIssues"
    },
    "properties": {
        "count": 4,
        "property": [
            {
                "name": "system.BuildMode",
                "value": "Rebuild"
            },
            {
                "name": "system.CONFIGURATION",
                "value": "Release"
            },
            {
                "name": "system.SetupDependsOn",
                "value": ""
            },
            {
                "name": "system.SuppressICEValidation",
                "value": "true"
            }
        ]
    },
    "statistics": {
        "href": "/httpAuth/app/rest/builds/id:1920/statistics"
    }
}
        */
        #region properties
        public int id { get; set; }
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
        #endregion

        #region public static
        public static string GetItemUrl(string id)
        {
            var urlSuffix = string.Format(Constants.BuildUrlSuffix, id);
            return BuildUrl(urlSuffix);
        }

        public static string GetListUrl()
        {
            return BuildUrl(Constants.BuildsUrlSuffix);
        }

        public static string GetPatchesUrl()
        {
            return BuildUrl(Constants.PatchesBuildTypeUrlSuffix);
        }

        public static string GetBuildUrl(string buildNumber)
        {
            return BuildUrl(String.Format(Constants.BuildUrlSuffix, buildNumber));
        }
        #endregion

        #region classes
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

        public class Revision
        {
            public string version { get; set; }
            [JsonProperty(PropertyName = "vcs-root-instance")]
            public VcsRootInstance vcs_root_instance { get; set; }
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

        public class VcsRootInstance
        {
            public string id { get; set; }
            [JsonProperty(PropertyName = "vcs-root-id")]
            public string vcs_root_id { get; set; }
            public string name { get; set; }
            public string href { get; set; }
        }
        #endregion
    }
}
