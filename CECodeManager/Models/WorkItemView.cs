using Atlassian.Jira;
using JiraHelper;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CECodeManager.Models
{
    public class WorkItemView
    {
        public Octokit.Issue GitHubIssue { get; set; }

        public string JiraId { get; set; }
        public string TeamCityId { get; set; }
        public string Description { get; set; }

        public string Branch { get; set; }
        public string RepositoryName { get; set; }
        public Version Version { get; set; }
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
        /// Returns the team associated with the first JIRA issue
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

        public IssueStatus JiraStatus
        {
            get
            {
                if (null == JiraIssues || JiraIssues.Count == 0)
                    return "-";
                else
                {
                    return JiraIssues[0].Status;
                }
            }
        }



        public bool HasDbUpgrade { get; set; }
        public bool HasBuildScriptChange { get; set; }

        public IList<string> FilesChanged { get; set; }
        public IList<string> AssembliesChanged { get; set; }

        public IList<GitHubCommit> Commits { get; set; }

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
                        var issueKey = issue.Key.Value;
                        var issueNumberBuffer = issueKey.Replace("ADVANTAGE-", "").Replace("WEB-", "");
                        var issueNumber = Int32.Parse(issueNumberBuffer);
                        JiraIssueNumbers.Add(issueNumber);
                    }
                }
            }
        }
        public IList<int> JiraIssueNumbers { get; private set; }

        public IList<string> JiraIssueKeys
        {
            get
            {
                var keys = new List<string>();
                if (JiraIssues.Count > 0)
                {
                    foreach (var issue in JiraIssues)
                    {
                        keys.Add(issue.Key.Value);
                    }
                }
                return keys;
            }
        }
        public string JiraIssueKeyList
        {
            get
            {
                return String.Join(", ", JiraIssueKeys);
            }
        }

        public WorkItemView()
        {
            FilesChanged = new List<string>();
            AssembliesChanged = new List<string>();
            JiraIssues = new List<Atlassian.Jira.Issue>();
            JiraIssueNumbers = new List<int>();
            Version = new Version(0, 0);
            Commits = new List<GitHubCommit>();
        }

        public void LoadAssembliesChanged()
        {
            var advantagePatchBuilder = new ChangedAssembyHelper(this.FilesChanged, GitHubIssue.Repository.Name, "rroberts");
            AssembliesChanged = advantagePatchBuilder.AssemblyFiles;
        }
    }
}
