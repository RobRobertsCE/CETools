using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCityService
{
    public static class Constants
    {
        public static string AdvantageRootUrl = @"https://teamcity.pfestore.com";
        public static string ProjectsUrlSuffix = @"/httpAuth/app/rest/projects";
        public static string ProjectUrlSuffix = @"/httpAuth/app/rest/projects/{0}";
        public static string ServerUrlSuffix = @"/httpAuth/app/rest/server";
        public static string BuildsUrlSuffix = @"/httpAuth/app/rest/builds";
        public static string BuildUrlSuffix = @"/httpAuth/app/rest/builds/id:{0}";
        public static string BuildLogUrlSuffix = @"/viewLog.html?buildId={0}&buildTypeId={1}";
        public static string BuildStatusIconUrlSuffix = @"/httpAuth/app/rest/builds/{0}/statusIcon ";
        // http://<TC>/guestAuth/app/rest/buildTypes/id:<BUILD_TYPE>/branches

        public static string BuildTypeUrlSuffix = @"/httpAuth/app/rest/buildTypes/id:{0}/branches ";
        public static string PatchesBuildTypeUrlSuffix = @"/httpAuth/app/rest/buildTypes/id:Advantage_Patches/branches ";

        public static string AdvantageProjectId = "Advantage";
        public static string AdvantageBuildTypeId = "Advantage_Build";
        public static string PatchesBuildTypeId = "Advantage_Patches";

        /* https://teamcity.pfestore.com/httpAuth/app/rest/projects/Advantage/

        <project id="Advantage" name="Advantage" parentProjectId="_Root" href="/httpAuth/app/rest/projects/id:Advantage" webUrl="https://teamcity.pfestore.com/project.html?projectId=Advantage">
<parentProject id="_Root" name="<Root project>" description="Contains all other projects" href="/httpAuth/app/rest/projects/id:_Root" webUrl="https://teamcity.pfestore.com/project.html?projectId=_Root"/>
<buildTypes count="2">
<buildType id="Advantage_Build" name="Build" projectName="Advantage" projectId="Advantage" href="/httpAuth/app/rest/buildTypes/id:Advantage_Build" webUrl="https://teamcity.pfestore.com/viewType.html?buildTypeId=Advantage_Build"/>
<buildType id="Advantage_SecurityScan" name="SecurityScan" projectName="Advantage" projectId="Advantage" href="/httpAuth/app/rest/buildTypes/id:Advantage_SecurityScan" webUrl="https://teamcity.pfestore.com/viewType.html?buildTypeId=Advantage_SecurityScan"/>
</buildTypes>
<templates count="0"/>
<parameters count="0" href="/app/rest/projects/id:Advantage/parameters"/>
<vcsRoots count="1" href="/httpAuth/app/rest/vcs-roots?locator=project:(id:Advantage)"/>
<projects count="0"/>
</project>
        */


        /* https://teamcity.pfestore.com/httpAuth/app/rest/builds/4817/statusIcon */

        /* https://teamcity.pfestore.com/viewLog.html?buildId=1925&buildTypeId= */

        /* https://teamcity.pfestore.com/httpAuth/app/rest/builds
<builds count="100" href="/httpAuth/app/rest/builds" nextHref="/httpAuth/app/rest/builds?locator=start:100,count:100">
<build id="1925" buildTypeId="CECloudRevNu_General_Build" number="132" status="SUCCESS" state="finished" branchName="refs/heads/develop" defaultBranch="true" href="/httpAuth/app/rest/builds/id:1925" webUrl="https://teamcity.pfestore.com/viewLog.html?buildId=1925&buildTypeId=CECloudRevNu_General_Build"/>
<build id="1924" buildTypeId="CECloudRevNu_General_Build" number="131" status="SUCCESS" state="finished" branchName="refs/heads/develop" defaultBranch="true" href="/httpAuth/app/rest/builds/id:1924" webUrl="https://teamcity.pfestore.com/viewLog.html?buildId=1924&buildTypeId=CECloudRevNu_General_Build"/>
...
</builds>
        */


        /* single build   
        
        https://teamcity.pfestore.com/httpAuth/app/rest/builds/id:1925

        <build id="1925" buildTypeId="CECloudRevNu_General_Build" number="132" status="SUCCESS" state="finished" branchName="refs/heads/develop" defaultBranch="true" href="/httpAuth/app/rest/builds/id:1925" webUrl="https://teamcity.pfestore.com/viewLog.html?buildId=1925&buildTypeId=CECloudRevNu_General_Build">
<statusText>Success</statusText>
<buildType id="CECloudRevNu_General_Build" name="Build" projectName="CECloud.RevNu :: General" projectId="CECloudRevNu_General" href="/httpAuth/app/rest/buildTypes/id:CECloudRevNu_General_Build" webUrl="https://teamcity.pfestore.com/viewType.html?buildTypeId=CECloudRevNu_General_Build"/>
<queuedDate>20160817T151159+0000</queuedDate>
<startDate>20160817T151205+0000</startDate>
<finishDate>20160817T151354+0000</finishDate>
<triggered type="vcs" details="jetbrains.git" date="20160817T151159+0000"/>
<lastChanges count="1">
<change id="2038" version="448990aa85b985d5b539a19ec9eb1b9874ad3cc2" username="ssolin" date="20160817T150944+0000" href="/httpAuth/app/rest/changes/id:2038" webUrl="https://teamcity.pfestore.com/viewModification.html?modId=2038&personal=false"/>
</lastChanges>
<changes href="/httpAuth/app/rest/changes?locator=build:(id:1925)"/>
<revisions count="1">
<revision version="448990aa85b985d5b539a19ec9eb1b9874ad3cc2">
<vcs-root-instance id="19" vcs-root-id="CECloudRevNu_GitGithubComCenterEdgeCECloudRevNuGitRefsHeadsDevelop" name="git@github.com:CenterEdge/CECloud.RevNu.git#refs/heads/develop" href="/httpAuth/app/rest/vcs-root-instances/id:19"/>
</revision>
</revisions>
<agent id="14" name="EC2-i-e1439019" typeId="7" href="/httpAuth/app/rest/agents/id:14"/>
<artifacts href="/httpAuth/app/rest/builds/id:1925/artifacts/children/"/>
<relatedIssues href="/httpAuth/app/rest/builds/id:1925/relatedIssues"/>
<properties count="1">
<property name="system.CONFIGURATION" value="QA"/>
</properties>
<statistics href="/httpAuth/app/rest/builds/id:1925/statistics"/>
</build>
*/

        /* https://teamcity.pfestore.com/httpAuth/app/rest/application.wadl */

        /* https://teamcity.pfestore.com/httpAuth/app/rest/builds/1920/statusIcon */

        /*  https://teamcity.pfestore.com/httpAuth/app/rest/projects @"/httpAuth/app/rest/projects"; 
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

        /*  https://teamcity.pfestore.com/httpAuth/app/rest/server
        <server version = "9.1.7 (build 37573)" versionMajor="9" versionMinor="1" startTime="20160607T021730+0000" currentTime="20160817T144436+0000" buildNumber="37573" buildDate="20160504T000000+0000" internalId="e80c1a83-8e92-4a18-881d-819089f57c5c" webUrl="https://teamcity.pfestore.com">
          <projects href = "/httpAuth/app/rest/projects" />
          < vcsRoots href="/httpAuth/app/rest/vcs-roots"/>
          <builds href = "/httpAuth/app/rest/builds" />
          < users href="/httpAuth/app/rest/users"/>
          <userGroups href = "/httpAuth/app/rest/userGroups" />
          < agents href="/httpAuth/app/rest/agents"/>
          <buildQueue href = "/httpAuth/app/rest/buildQueue" />
          < agentPools href="/httpAuth/app/rest/agentPools"/>
        </server>
        */
    }
}
