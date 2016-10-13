using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TeamCityService
{
    public class TeamCity
    {
        public IList<RunningBuild.Build> GetRunningBuilds()
        {
            List<RunningBuild.Build> results = new List<RunningBuild.Build>();

            HttpClient client = new HttpClient();
            var url = "https://teamcity.pfestore.com/httpAuth/app/rest/builds?locator=running:true,branch:default:any";
            client.BaseAddress = new Uri(url);


            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] cred = UTF8Encoding.UTF8.GetBytes("rroberts:hel-j205");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var responseData = response.Content.ReadAsAsync<RunningBuild>();
                // TODO: Check result status
                if (null != responseData.Result)
                {
                    results = responseData.Result.build;
                    if (null != results && results.Count > 0)
                    {
                        foreach (var runningBuild in results)
                        {
                            Console.WriteLine("{0} {1} {2} {3}", runningBuild.id, runningBuild.number, runningBuild.state, runningBuild.percentageComplete);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }


            return results;
        }

        public IList<Build> GetBuilds()
        {
            List<Build> results = null;

            HttpClient client = new HttpClient();

            var url = Build.GetListUrl();// + "?" + "buildType:Advantage_Build";
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] cred = UTF8Encoding.UTF8.GetBytes("rroberts:hel-j205");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var responseData = response.Content.ReadAsAsync<BuildRequestResponse>();

                if (null != responseData.Result.build)
                {
                    results = responseData.Result.build;

                    foreach (var d in results)
                    {
                        Console.WriteLine("{0} : {1}", d.branchName, d.id);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }


            return results;
        }

        public IList<Branch> GetBranches()
        {
            List<Branch> results = null;

            HttpClient client = new HttpClient();
            
            var url = "https://teamcity.pfestore.com/httpAuth/app/rest/buildTypes/id:Advantage_Build/branches/";
            client.BaseAddress = new Uri(url);
            
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] cred = UTF8Encoding.UTF8.GetBytes("rroberts:hel-j205");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var responseData = response.Content.ReadAsAsync<GetBranchesResponse>();

                results = responseData.Result.branch;                
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return results;
        }

        /// <summary>
        /// returns builds by branch name.
        /// </summary>
        /// <param name="branchName">Format: XXXX/merge (where XXXX = GitHub pull request number), refs/heads/develop, refs/heads/master, merge-master-16.5-into-develop-16.6, etc</param>
        /// <returns></returns>
        public IList<Build> GetBranchBuilds(string branchName)
        {
            List<Build> results = null;

            HttpClient client = new HttpClient();

            var url = Build.GetListUrl() + "?" + "locator=branch:" + branchName;
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] cred = UTF8Encoding.UTF8.GetBytes("rroberts:hel-j205");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var responseData = response.Content.ReadAsAsync<BuildRequestResponse>();

                if (null != responseData.Result.build)
                {
                    results = responseData.Result.build;

                    foreach (var d in results)
                    {
                        Console.WriteLine("{0} : {1}", d.branchName, d.id);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }


            return results;
        }

        public IList<Build> GetPatchBuilds()
        {
            List<Build> results = null;

            HttpClient client = new HttpClient();

            var url = Build.GetListUrl() + "?" + "locator=buildType:Advantage_Patches";

            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] cred = UTF8Encoding.UTF8.GetBytes("rroberts:hel-j205");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var responseData = response.Content.ReadAsAsync<BuildRequestResponse>();

                if (null != responseData.Result.build)
                {
                    results = responseData.Result.build;

                    foreach (var d in results)
                    {
                        Console.WriteLine("{0} : {1}", d.branchName, d.id);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return results.Take(20).ToList();
        }

        public IList<Build> GetAdvantageBuilds()
        {
            List<Build> results = null;

            HttpClient client = new HttpClient();

            var url = Build.GetListUrl() + "?" + "locator=buildType:Advantage_Build";

            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] cred = UTF8Encoding.UTF8.GetBytes("rroberts:hel-j205");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var responseData = response.Content.ReadAsAsync<BuildRequestResponse>();

                if (null != responseData.Result.build)
                {
                    results = responseData.Result.build;

                    foreach (var d in results)
                    {
                        Console.WriteLine("{0} : {1}", d.branchName, d.id);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return results;
        }

        public IList<Build> GetSecurityScanBuilds()
        {
            List<Build> results = null;

            HttpClient client = new HttpClient();

            var url = Build.GetListUrl() + "?" + "locator=buildType:Advantage_SecurityScan";

            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] cred = UTF8Encoding.UTF8.GetBytes("rroberts:hel-j205");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var responseData = response.Content.ReadAsAsync<BuildRequestResponse>();

                if (null != responseData.Result.build)
                {
                    results = responseData.Result.build;

                    foreach (var d in results)
                    {
                        Console.WriteLine("{0} : {1}", d.branchName, d.id);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return results;
        }

        // build details
        public BuildDetails GetBuildDetails(Build build)
        {
            return GetBuildDetails(build.id);
        }

        public BuildDetails GetBuildDetails(int buildId)
        {
            BuildDetails results = null;

            HttpClient client = new HttpClient();

            var url = String.Format("https://teamcity.pfestore.com/httpAuth/app/rest/builds/id:{0}", buildId.ToString());
            client.BaseAddress = new Uri(url);
            Console.WriteLine(url);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] cred = UTF8Encoding.UTF8.GetBytes("rroberts:hel-j205");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var responseData = response.Content.ReadAsAsync<BuildDetails>();

                results = responseData.Result;

                if (null != results)
                {
                    Console.WriteLine(results.state + ": " + results.status);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return results;
        }


        //public BuildChanges GetBuildChanges(int buildId)
        //{
        //    BuildChanges results = null;

        //    HttpClient client = new HttpClient();

        //    //var url = String.Format("https://teamcity.pfestore.com/httpAuth/app/rest/changes/id:{0}", changeId.ToString());
        //    var url = String.Format("https://teamcity.pfestore.com/httpAuth/app/rest/changes/?locator=build:(id:{0})", buildId.ToString());

        //    client.BaseAddress = new Uri(url);
        //    Console.WriteLine(url);
        //    // Add an Accept header for JSON format.
        //    client.DefaultRequestHeaders.Accept.Add(
        //    new MediaTypeWithQualityHeaderValue("application/json"));

        //    byte[] cred = UTF8Encoding.UTF8.GetBytes("rroberts:hel-j205");
        //    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

        //    // List data response.
        //    HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Parse the response body. Blocking!
        //        var responseData = response.Content.ReadAsAsync<BuildChanges>();
        //        results = responseData.Result;                
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }

        //    return results;
        //}

        public IList<BuildChange> GetBuildChangeList(int buildId)
        {
            IList<BuildChange> results = null;

            HttpClient client = new HttpClient();

            //var url = String.Format("https://teamcity.pfestore.com/httpAuth/app/rest/changes/id:{0}", changeId.ToString());
            var url = String.Format("https://teamcity.pfestore.com/httpAuth/app/rest/changes/?locator=build:(id:{0})", buildId.ToString());

            client.BaseAddress = new Uri(url);
            Console.WriteLine(url);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] cred = UTF8Encoding.UTF8.GetBytes("rroberts:hel-j205");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var responseData = response.Content.ReadAsAsync<BuildChangeListResponse>();
                results = responseData.Result.change;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return results;
        }


        // get build changes
        // https://teamcity.pfestore.com/httpAuth/app/rest/changes/id:492
        /*
        {
    "id": 492,
    "version": "5213d6fcfd96315cec46b41721b4ae7c88ee7df1",
    "username": "rroberts",
    "date": "20160624T205455+0000",
    "href": "/httpAuth/app/rest/changes/id:492",
    "webUrl": "https://teamcity.pfestore.com/viewModification.html?modId=492&personal=false",
    "comment": "Correct version number on sql script.\n",
    "user": {
        "username": "rroberts",
        "name": "Rob Roberts",
        "id": 2,
        "href": "/httpAuth/app/rest/users/id:2"
    },
    "files": {
        "file": [
            {
                "before-revision": "a3b718b2776bad7a82041e5b1c981b889334b9ad",
                "after-revision": "5213d6fcfd96315cec46b41721b4ae7c88ee7df1",
                "file": "src/AdvUpgrade/AdvUpgrade/16.4/16.4.26/NotifyEventHistory.16.4.100.sql",
                "relative-file": "src/AdvUpgrade/AdvUpgrade/16.4/16.4.26/NotifyEventHistory.16.4.100.sql"
            },
            {
                "before-revision": "a3b718b2776bad7a82041e5b1c981b889334b9ad",
                "after-revision": "5213d6fcfd96315cec46b41721b4ae7c88ee7df1",
                "file": "src/AdvUpgrade/AdvUpgrade/16.4/16.4.26/NotifyEventHistory.16.4.26.sql",
                "relative-file": "src/AdvUpgrade/AdvUpgrade/16.4/16.4.26/NotifyEventHistory.16.4.26.sql"
            },
            {
                "before-revision": "a3b718b2776bad7a82041e5b1c981b889334b9ad",
                "after-revision": "5213d6fcfd96315cec46b41721b4ae7c88ee7df1",
                "file": "src/AdvUpgrade/AdvUpgrade/AdvUpgrade.vbproj",
                "relative-file": "src/AdvUpgrade/AdvUpgrade/AdvUpgrade.vbproj"
            }
        ]
    },
    "vcsRootInstance": {
        "id": "3",
        "vcs-root-id": "Advantage_HttpsGithubComCenterEdgeAdvantageGitRefsHeadsDevelop",
        "name": "https://github.com/CenterEdge/Advantage.git#refs/heads/develop",
        "href": "/httpAuth/app/rest/vcs-root-instances/id:3"
    }
}
    */
    }
}