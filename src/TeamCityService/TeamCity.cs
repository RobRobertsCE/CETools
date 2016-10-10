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
            /* THESE WORK
            //client.BaseAddress = new Uri(Build.GetListUrl());
            var url = Build.GetListUrl();
            var url = Build.GetListUrl() + "?count=20";
            var url = Build.GetListUrl() + "?" + "buildType:Advantage_Build,count=12";
            */
            /* THESE WORK IN POSTMAN            
            // https://teamcity.pfestore.com/httpAuth/app/rest/builds/buildType:Advantage_Build
            */
            /* THESE DO NOT WORK
            //var url = Build.GetListUrl() + "/" + "buildType:Advantage_Build";
            //var url = "https://teamcity.pfestore.com/httpAuth/app/rest/builds/buildType:Advantage_Build";
            //var url = "https://teamcity.pfestore.com/httpAuth/app/rest/builds/running:false?count=10,start=0";
            */

            var url = Build.GetListUrl() + "?" + "buildType:Advantage_Build";
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
                var responseData = response.Content.ReadAsAsync<BuildRequestResult>();

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

            /* WORKS IN POSTMAN
            https://teamcity.pfestore.com/httpAuth/app/rest/buildTypes/id:Advantage_Build/branches/
            */
            //var url = Build.GetListUrl() + "/" + "buildTypes/id:Advantage_Build/branches/";
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
                var responseData = response.Content.ReadAsAsync<RootObject>();

                results = responseData.Result.branch;

                //if (null != results)
                //{
                //    foreach (var d in results)
                //    {
                //        //if (true == d.@default)
                //        //{
                //        //    Console.WriteLine(d.name + " (default)");
                //        //}
                //        //else
                //        //{
                //        //    Console.WriteLine(d.name);
                //        //}

                //    }
                //}
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return results;
        }

        //public BuildDetails GetBuildDetails(Build build)
        //{
        //    BuildDetails results = null;

        //    HttpClient client = new HttpClient();

        //    /* WORKS IN POSTMAN
        //    https://teamcity.pfestore.com/httpAuth/app/rest/builds/buildType:Advantage_Build?id=3910
        //    */
        //    //var url = Build.GetListUrl() + "/" + "buildTypes/id:Advantage_Build/branches/";
        //    var url = "https://teamcity.pfestore.com/httpAuth/app/rest/buildTypes/id:Advantage_Build/branches/";
        //    client.BaseAddress = new Uri(url);


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
        //        var responseData = response.Content.ReadAsAsync<BuildDetails>();

        //        results = responseData.Result;

        //        if (null != results)
        //        {
        //            Console.WriteLine(results.state + ": " + results.status);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //    }

        //    return results;
        //}

        public class Branch
        {
            public string name { get; set; }
            public bool @default { get; set; }

            public override string ToString()
            {
                if (true == @default)
                {
                    return name + " (default)";
                }
                else
                {
                    return name;
                }
            }
        }

        public class RootObject
        {
            public List<Branch> branch { get; set; }
        }

        public Build GetAdvantageBuild()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Build.GetListUrl() + "/" + "buildType:Advantage_Build");

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
                var responseData = response.Content.ReadAsAsync<Build>();
                var dataObject = responseData.Result;
                return dataObject;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public IList<Build> GetBranchBuilds(string pullRequestNumber)
        {

            List<Build> results = null;

            HttpClient client = new HttpClient();
            /* THESE WORK
            //client.BaseAddress = new Uri(Build.GetListUrl());
            var url = Build.GetListUrl();
            var url = Build.GetListUrl() + "?count=20";
            var url = Build.GetListUrl() + "?" + "buildType:Advantage_Build,count=12";
            */
            /* THESE WORK IN POSTMAN            
            // https://teamcity.pfestore.com/httpAuth/app/rest/builds/buildType:Advantage_Build
            */
            /* THESE DO NOT WORK
            //var url = Build.GetListUrl() + "/" + "buildType:Advantage_Build";
            //var url = "https://teamcity.pfestore.com/httpAuth/app/rest/builds/buildType:Advantage_Build";
            //var url = "https://teamcity.pfestore.com/httpAuth/app/rest/builds/running:false?count=10,start=0";
            */

            var url = Build.GetListUrl() + "?" + "locator=branch:" + pullRequestNumber;
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
                var responseData = response.Content.ReadAsAsync<BuildRequestResult>();

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

        public IList<Build> GetPatchBuilds(string pullRequestNumber)
        {

            List<Build> results = null;

            HttpClient client = new HttpClient();
            /* THESE WORK
            //client.BaseAddress = new Uri(Build.GetListUrl());
            var url = Build.GetListUrl();
            var url = Build.GetListUrl() + "?count=20";
            var url = Build.GetListUrl() + "?" + "buildType:Advantage_Build,count=12";
            */
            /* THESE WORK IN POSTMAN            
            // https://teamcity.pfestore.com/httpAuth/app/rest/builds/buildType:Advantage_Build
            */
            /* THESE DO NOT WORK
            //var url = Build.GetListUrl() + "/" + "buildType:Advantage_Build";
            //var url = "https://teamcity.pfestore.com/httpAuth/app/rest/builds/buildType:Advantage_Build";
            //var url = "https://teamcity.pfestore.com/httpAuth/app/rest/builds/running:false?count=10,start=0";
            */

            //var url = Build.GetListUrl() + "?" + "locator=branch:" + pullRequestNumber;

            //var url = Build.GetListUrl() + "?" + "locator=buildType:Advantage_Patches";
            // COMPLETED -> var url = Build.GetListUrl() + "?" + "locator=buildType:Advantage_Patches";
            // RUNNING -> var url = Build.GetListUrl() + "?" + "locator=buildType:Advantage_Patches,running:true";



            var url = Build.GetListUrl() + "?" + "locator=buildType:Advantage_Patches";
            //var url = Build.GetPatchesUrl();

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
                var responseData = response.Content.ReadAsAsync<BuildRequestResult>();

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
        public BuildDetails GetPatchBuildDetails(Build build)
        {
            return GetBuildDetails(build.id.ToString());
        }
        public BuildDetails GetPatchBuildDetails(string buildId)
        {
            return GetBuildDetails(buildId);
        }
        public BuildDetails GetBuildDetails(string buildId)
        {
            BuildDetails results = null;

            HttpClient client = new HttpClient();

            /* WORKS IN POSTMAN
            https://teamcity.pfestore.com/httpAuth/app/rest/builds/buildType:Advantage_Build?id=3910
            */

            var url = String.Format("https://teamcity.pfestore.com/httpAuth/app/rest/builds/id:{0}?buildTypeId=Advantage_Patches", buildId);
            // nope -> var url = String.Format("https://teamcity.pfestore.com/httpAuth/app/rest/builds/buildTypeId:Advantage_Patches?id={0}", buildId);
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
    }
}

//{
//    "count": 1,
//    "href": "/httpAuth/app/rest/builds?locator=id:3917",
//    "build": [
//        {
//            "id": 3917,
//            "buildTypeId": "Advantage_Build",
//            "number": "2517",
//            "status": "SUCCESS",
//            "state": "finished",
//            "branchName": "5028/merge",
//            "href": "/httpAuth/app/rest/builds/id:3917",
//            "webUrl": "https://teamcity.pfestore.com/viewLog.html?buildId=3917&buildTypeId=Advantage_Build"
//        }
//    ]
//}