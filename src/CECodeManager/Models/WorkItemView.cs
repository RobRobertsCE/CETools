using Atlassian.Jira;
using static CETools.Common;
using JiraHelper;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamCityService;

namespace CECodeManager.Models
{
    public class WorkItemView
    {
        #region properties

        private string _repositoryName = String.Empty;
        public string RepositoryName
        {
            get
            {
                if (String.IsNullOrEmpty(_repositoryName))
                {
                    _repositoryName = ReadRepoNameFromGitHubIssue();
                }
                return _repositoryName;
            }
            set
            {
                _repositoryName = value;
            }
        }

        // The branch and version that the work is done in.
        public Version WorkDoneInVersion { get; set; }
        public Version WorkDoneInBranch { get; set; }

        public bool HasDbUpgrade { get; set; }
        public bool HasBuildScriptChange { get; set; }

        public IList<string> FilesChanged { get; set; }
        public IList<string> AssembliesChanged { get; set; }

        /************************************/
        /************************************/
        /***** Jira-specific properties *****/
        /************************************/
        /************************************/
        private IList<Atlassian.Jira.Issue> _jIRAIssues;
        public IList<Atlassian.Jira.Issue> JiraIssues
        {
            get
            {
                return _jIRAIssues;
            }
            set
            {
                _jIRAIssues = value;
                JiraIssueNumbers = new List<int>();
                if (JiraIssues.Count > 0)
                {
                    foreach (var issue in JiraIssues)
                    {
                        string issueNumberBuffer = issue.Key.Value;
                        foreach (var prefix in JiraIssuePrefixes)
                        {
                            issueNumberBuffer = issueNumberBuffer.Replace(String.Format("{0}-", prefix), "");
                        }
                        var issueNumber = Int32.Parse(issueNumberBuffer);
                        JiraIssueNumbers.Add(issueNumber);
                    }
                }
            }
        }

        public IList<int> JiraIssueNumbers { get; private set; }

        /// <summary>
        /// Returns the team associated with the first JIRA issue
        /// </summary>
        public string CETeam
        {
            get
            {
                if (null == JiraIssues || JiraIssues.Count == 0)
                    return "-";
                else
                {
                    if (null == JiraIssues[0].CustomFields || JiraIssues[0].CustomFields.Count == 0)
                        return "-";
                    else
                    {
                        var teamName = "-";
                        foreach (var customField in JiraIssues[0].CustomFields)
                        {
                            if (customField.Name == "Team")
                            {
                                if (null != customField.Values && customField.Values.Length > 0)
                                    teamName = customField.Values[0];
                            }
                        }

                        return teamName;
                    }
                }
            }
        }

        /// <summary>
        /// Returns the fix version associated with the first JIRA issue
        /// </summary>
        public string FixVersions
        {
            get
            {
                if (null == JiraIssues || JiraIssues.Count == 0)
                    return "-";
                else
                {
                    if (null == JiraIssues[0].FixVersions || JiraIssues[0].FixVersions.Count == 0)
                        return "-";
                    else
                    {
                        return String.Join(", ", JiraIssues[0].FixVersions.Select(v => v.ToString()).ToList());
                    }
                }
            }
        }

        /// <summary>
        /// Returns the status associated with the first JIRA issue
        /// </summary>
        public IssueStatus JiraStatus
        {
            get
            {
                if (null == JiraIssues || JiraIssues.Count == 0)
                    return null;
                else
                {
                    return JiraIssues[0].Status;
                }
            }
        }

        /// <summary>
        /// Returns the priority associated with the first JIRA issue
        /// </summary>
        public IssuePriority JiraPriority
        {
            get
            {
                if (null == JiraIssues || JiraIssues.Count == 0)
                    return null;
                else
                {
                    return JiraIssues[0].Priority;
                }
            }
        }

        /// <summary>
        /// Returns the issue type associated with the first JIRA issue
        /// </summary>
        public IssueType JiraIssueType
        {
            get
            {
                if (null == JiraIssues || JiraIssues.Count == 0)
                    return null;
                else
                {
                    return JiraIssues[0].Type;
                }
            }
        }

        /// <summary>
        /// Returns the JIRA epic associated with the first JIRA issue
        /// </summary>
        public string JiraEpic
        {
            get
            {
                if (null == JiraIssues || JiraIssues.Count == 0)
                    return null;
                else
                {
                    var epicName = "";
                    if (null != JiraIssues[0].Components && JiraIssues[0].Components.Count > 0)
                    {
                        epicName = JiraIssues[0].Components[0].Name;
                    }
                    return epicName;
                }
            }
        }

        /// <summary>
        /// Returns the created datetime associated with the first JIRA issue
        /// </summary>
        public DateTime? JiraIssueCreated
        {
            get
            {
                if (null == JiraIssues || JiraIssues.Count == 0)
                    return null;
                else
                {
                    return JiraIssues[0].Created;
                }
            }
        }

        /// <summary>
        /// Returns the updated datetime associated with the first JIRA issue
        /// </summary>
        public DateTime? JiraIssueUpdated
        {
            get
            {
                if (null == JiraIssues || JiraIssues.Count == 0)
                    return null;
                else
                {
                    return JiraIssues[0].Updated;
                }
            }
        }

        /**************************************/
        /**************************************/
        /***** GitHub-specific properties *****/
        /**************************************/
        /**************************************/
        private Octokit.Issue _gitHubIssue = null;
        public Octokit.Issue GitHubIssue
        {
            get
            {
                return _gitHubIssue;
            }
            set
            {
                _gitHubIssue = value;
            }
        }

        public IList<GitHubCommit> Commits { get; set; }

        //// parse commit:
        //// https://api.github.com/repos/CenterEdge/Advantage/git/commits/b952a1f6d474d4f18d0a6a347627ef966d3fe07d
        //var urlSections = commitTask.Url.Split('/');
        //var commitId = urlSections[urlSections.Length - 1];


        /****************************************/
        /****************************************/
        /***** TeamCity-specific properties *****/
        /****************************************/
        /****************************************/
        private IList<Build> _builds = new List<Build>();
        public IList<Build> Builds
        {
            get
            {
                return _builds;
            }
            set
            {
                _builds = value;
            }
        }

        private IList<RunningBuild.Build> _runningBuilds = new List<RunningBuild.Build>();
        public IList<RunningBuild.Build> RunningBuilds
        {
            get
            {
                return _runningBuilds;
            }
            set
            {
                _runningBuilds = value;
            }
        }
        #endregion

        #region ctor
        public WorkItemView()
        {
            FilesChanged = new List<string>();
            AssembliesChanged = new List<string>();
            JiraIssues = new List<Atlassian.Jira.Issue>();
            JiraIssueNumbers = new List<int>();
            Commits = new List<GitHubCommit>();
        }
        #endregion

        //private void LoadAssembliesChanged()
        //{
        //    var advantagePatchBuilder = new ChangedAssembyHelper(this.FilesChanged, GitHubIssue.Repository.Name, "rroberts");
        //    AssembliesChanged = advantagePatchBuilder.AssemblyFiles;
        //}

        private string ReadRepoNameFromGitHubIssue()
        {
            // GitHubIssue.PullRequest.Url.AbsolutePath = "/repos/CenterEdge/Advantage/issues/5169"
            string repoNameBuffer = String.Empty;
            if (null != GitHubIssue && null != GitHubIssue.PullRequest && !String.IsNullOrEmpty(GitHubIssue.PullRequest.Url.AbsolutePath))
            {
                repoNameBuffer = GitHubIssue.PullRequest.Url.AbsolutePath.Replace("/repos/CenterEdge/","");
                var endOfRepoNameIdx = repoNameBuffer.IndexOf('/');
                repoNameBuffer = repoNameBuffer.Substring(0, endOfRepoNameIdx);
            }
            return repoNameBuffer;
        }
    }
}
