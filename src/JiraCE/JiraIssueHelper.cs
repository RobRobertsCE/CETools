using Atlassian.Jira;
using static CETools.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JiraHelper
{
    public class JiraIssueHelper : IDisposable
    {
        #region fields
        private readonly string _jiraUrl;
        private readonly string _jiraUserName;
        private readonly string _jiraUserPassword;
        private Jira _jira;
        #endregion

        #region properties
        protected internal Jira JiraService
        {
            get
            {
                if (null == _jira)
                    _jira = Jira.CreateRestClient(_jiraUrl, _jiraUserName, _jiraUserPassword);

                return _jira;
            }
        }
        #endregion

        #region ctor
        public JiraIssueHelper()
        {
            _jiraUrl = Properties.Settings.Default.JiraUrl;
            _jiraUserName = Properties.Settings.Default.JiraUserName;
            _jiraUserPassword = Properties.Settings.Default.JiraUserPassword;
        }
        public JiraIssueHelper(string url, string user, string password)
        {
            _jiraUrl = url;
            _jiraUserName = user;
            _jiraUserPassword = password;
        }
        #endregion

        #region public methods       
        /// <summary>
        /// Returns a Jira Issue for the given key.
        /// </summary>
        /// <param name="jiraKey">ex. ADVANTAGE-1234</param>
        public Issue GetJiraIssueByKey(string jiraIssuekey)
        {
            try
            {
                if (String.Empty.Equals(jiraIssuekey)) throw new ArgumentNullException("jiraIssuekey");
                
                return JiraService.GetIssue(jiraIssuekey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public string GetEpicName(string jiraIssuekey)
        {
            var issue = GetJiraIssueByKey(jiraIssuekey);
            if (issue.Type == "Epic")
                return issue.Description;
            else
                throw new InvalidOperationException("Issue Key Not For an Epic");
        }

        public void GetJiraProjects()
        {
            var projects = JiraService.GetProjects();

            foreach (var project in projects)
            {
                Console.WriteLine("Id:{0}; Key:{1}; Name:{2}; Lead:{3}", project.Id, project.Key, project.Name, project.Lead);
            }
        }


        public Project GetJiraProject(string key)
        {
            var project = JiraService.GetProjects().FirstOrDefault(projects => projects.Key == key);

            return project;
        }        

        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }
        #endregion

        #region public helper methods
        public static IList<string> GetJiraIssueNumbers(string body)
        {
            var issueNumbers = new List<string>();

            foreach (var repoName in JiraIssuePrefixes)
            {
                var tokenLength = repoName.Length;

                body = body.ToUpper();

                if (body.Contains(repoName))
                {
                    for (int i = 0; i < body.Length - tokenLength; i++)
                    {
                        if (body.Substring(i, tokenLength) == repoName)
                        {
                            var issueNumberBuffer = String.Empty;
                            var nextIdx = 0;
                            // add 1 for the '-' character. (Sometimes it is a different character, so we don't hard-code it.)
                            var textSection = body.Substring(i + tokenLength + 1);
                            while (GetNumberValue(textSection, ref issueNumberBuffer, ref nextIdx))
                            {
                                if (!issueNumbers.Contains(issueNumberBuffer) && !String.IsNullOrEmpty(issueNumberBuffer))
                                {
                                    //issueNumbers.Add(issueNumberBuffer);
                                    issueNumbers.Add(String.Format("{0}-{1}", repoName, issueNumberBuffer));
                                }

                                if ("," == body.Substring(nextIdx + i + tokenLength - 1, 1))
                                {
                                    textSection = body.Substring(nextIdx + i + tokenLength);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return issueNumbers.Where(i => !String.IsNullOrEmpty(i)).ToList();
        }
        #endregion

        #region private
        private static bool GetNumberValue(string buffer, ref string numberValue, ref int nextIdx)
        {
            int digitLength = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                var digitBuffer = buffer.Substring(i, 1);
                if (digitBuffer != " ")
                {
                    if (!digitBuffer.All(Char.IsDigit))
                    {
                        numberValue = buffer.Substring(i - digitLength, digitLength).Trim();
                        nextIdx = i + 1;
                        return true;
                    }
                }
                digitLength++;
            }
            return false;
        }

        #endregion

        #region IDisposable
        public void Dispose()
        {
            _jira = null;
        }
        #endregion
    }
}
