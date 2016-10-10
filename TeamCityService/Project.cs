using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCityService
{ /*  https://teamcity.pfestore.com/httpAuth/app/rest/projects @"/httpAuth/app/rest/projects"; 
        <projects count="9" href="/httpAuth/app/rest/projects">
        <project id="_Root" name="<Root project>" description="Contains all other projects" href="/httpAuth/app/rest/projects/id:_Root" webUrl="https://teamcity.pfestore.com/project.html?projectId=_Root"/>
        <project id="Advantage" name="Advantage" parentProjectId="_Root" href="/httpAuth/app/rest/projects/id:Advantage" webUrl="https://teamcity.pfestore.com/project.html?projectId=Advantage"/>
        <project id="AdvantageAccessControl" name="AdvantageAccessControl" parentProjectId="_Root" href="/httpAuth/app/rest/projects/id:AdvantageAccessControl" webUrl="https://teamcity.pfestore.com/project.html?projectId=AdvantageAccessControl"/>
        <project id="CECloudRevNu" name="CECloud.RevNu" parentProjectId="_Root" href="/httpAuth/app/rest/projects/id:CECloudRevNu" webUrl="https://teamcity.pfestore.com/project.html?projectId=CECloudRevNu"/>
        <project id="CECloudRevNu_Deployment" name="Deployment" parentProjectId="CECloudRevNu" href="/httpAuth/app/rest/projects/id:CECloudRevNu_Deployment" webUrl="https://teamcity.pfestore.com/project.html?projectId=CECloudRevNu_Deployment"/>
        <project id="CECloudRevNu_General" name="General" parentProjectId="CECloudRevNu" href="/httpAuth/app/rest/projects/id:CECloudRevNu_General" webUrl="https://teamcity.pfestore.com/project.html?projectId=CECloudRevNu_General"/>
        <project id="CECloudWebStores" name="CECloud.WebStores" parentProjectId="_Root" href="/httpAuth/app/rest/projects/id:CECloudWebStores" webUrl="https://teamcity.pfestore.com/project.html?projectId=CECloudWebStores"/>
        <project id="CECloudWebStores_Deployment" name="Deployment" parentProjectId="CECloudWebStores" href="/httpAuth/app/rest/projects/id:CECloudWebStores_Deployment" webUrl="https://teamcity.pfestore.com/project.html?projectId=CECloudWebStores_Deployment"/>
        <project id="CECloudWebStores_General" name="General" parentProjectId="CECloudWebStores" href="/httpAuth/app/rest/projects/id:CECloudWebStores_General" webUrl="https://teamcity.pfestore.com/project.html?projectId=CECloudWebStores_General"/>
        </projects>
        */
    class Project : EndpointBase
    {
        public string id { get; set; }
        public string name { get; set; }
        public string parentProjectId { get; set; }
        public string href { get; set; }
        public string webUrl { get; set; }

        public static Project GetProject(string id)
        {
            return new Project();
        }

        public static IList<Project> GetProjects()
        {
            return new List<Project>();
        }

        static string GetItemUrl(string id)
        {
            var urlSuffix = string.Format(Constants.ProjectUrlSuffix, id);
            return BuildUrl(urlSuffix);
        }

        static string GetListUrl()
        {
            return BuildUrl(Constants.ProjectsUrlSuffix);
        }
    }    
}
