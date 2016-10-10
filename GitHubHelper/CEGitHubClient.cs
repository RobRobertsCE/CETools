using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubHelper
{
    public class CEGitHubClient
    {

        // http://octokitnet.readthedocs.io/en/latest/search/

        #region constants
        private const string MyToken = "994752ad2cafc601e52a5def40faad2913f4339a";
        #endregion

        #region fields
        private readonly GitHubClient _github;
        private readonly string _owner;
        private readonly string _user;
        private readonly string _token;
        #endregion

        #region ctor
        public CEGitHubClient(string owner, string user, string token)
        {
            _owner = owner;
            _user = user;
            _token = MyToken;
            _github = new GitHubClient(new ProductHeaderValue("CEGitHubClient"));
            _github.Credentials = new Credentials(_token);
        }
        #endregion

        #region repo search
        public async Task<SearchRepositoryResult> GetRepos()
        {
            return await RepoSearch();
        }
        private async Task<SearchRepositoryResult> RepoSearch()
        {
            var searchRepositoriesRequest = new SearchRepositoriesRequest()
            {
                User = "CenterEdge"
            };

            SearchRepositoryResult searchRepositoryResult = await _github.Search.SearchRepo(searchRepositoriesRequest);

            return searchRepositoryResult;
        }

        public async Task<SearchRepositoryResult> GetRepo(string repoName)
        {
            return await RepoSearch(repoName);
        }
        private async Task<SearchRepositoryResult> RepoSearch(string repoName)
        {
            var searchRepositoriesRequest = new SearchRepositoriesRequest(repoName)
            {
                User = "CenterEdge"
            };

            SearchRepositoryResult searchRepositoryResult = await _github.Search.SearchRepo(searchRepositoriesRequest);

            return searchRepositoryResult;
        }
        #endregion

        #region pull request search
        public async Task<SearchIssuesResult> GetIssues(ItemState? state, int daysBack, IList<string> repoNames)
        {
            return await IssueSearch(state, new DateRange(DateTime.Now.AddDays(-1 * daysBack), SearchQualifierOperator.GreaterThanOrEqualTo), repoNames); ;
        }
        private async Task<SearchIssuesResult> IssueSearch(ItemState? state, DateRange searchDates, IList<string> repoNames)
        {
            var issueSearch = new SearchIssuesRequest()
            {
                Type = IssueTypeQualifier.PullRequest,
                State = state,
                Updated = searchDates
            };

            foreach (var repoName in repoNames)
            {
                issueSearch.Repos.Add(String.Format(@"{0}/{1}", _owner, repoName));
            }

            SearchIssuesResult searchIssueResult = await _github.Search.SearchIssues(issueSearch);

            return searchIssueResult;
        }
        #endregion

        #region pull request details search      
        public async Task<PullRequest> GetPullRequestDetails(int number)
        {
            // SearchIssuesResult searchIssueResult = await _github.Search.SearchIssues(issueSearch);
            PullRequest searchIssueResult = await _github.PullRequest.Get(_owner, "ADVANTAGE", number);

            return searchIssueResult;
        }
        #endregion

        #region commits
        async Task<PullRequest> GetPullRequestDetails(Octokit.Issue request, int issueId)
        {
            var repositoryName = request.PullRequest.HtmlUrl.Segments[2].TrimEnd('/');
            var pullRequestDetails = await _github.Repository.PullRequest.Get(_owner, repositoryName, issueId);

            //pullRequest.Branch = pullRequestDetails.Base.Ref;
            //pullRequest.RepoBranch = BranchVersionHelper.Map.GetRepoBranch(pullRequest.Branch);
            //if (null != pullRequest.RepoBranch)
            //    pullRequest.Version = pullRequest.RepoBranch.Version;
            //pullRequest.Mergeable = pullRequestDetails.Mergeable;
            //pullRequest.Merged = pullRequestDetails.Merged;
            //pullRequest.ChangedFileCount = pullRequestDetails.ChangedFiles;
            //pullRequest.State = pullRequestDetails.State;
            //pullRequest.CommitCount = pullRequestDetails.Commits;
            //pullRequest.JiraIssues = GetJiraIssues(request, pullRequest.RepoName);

            //pullRequest = await GetCommits(request, pullRequest, pullRequestDetails.Head.Sha);

            return pullRequestDetails;
        }

        public async Task<Octokit.GitHubCommit> GetCommits(string repoName, string sha)
        {
            var commitTask = await _github.Repository.Commit.Get(_owner, repoName, sha);

            //if (null != commitTask)
            //{
            //pullRequest.Commits.Add(commitTask);

            //pullRequest.HasDbUpgrade = commitTask.Files.Any(f => f.Filename.Contains("AdvUpgrade"));
            //pullRequest.HasBuildScriptChange = commitTask.Files.Any(f => f.Filename.Contains("build.ps1"));

            //pullRequest.Files = commitTask.Files.Select(f => f.Filename).ToList();

            //var advantagePatchBuilder = new PullRequestAssembyHelper(pullRequest, "rroberts");
            //pullRequest.AssembliesChanged = advantagePatchBuilder.AssemblyFiles;
            //}

            return commitTask;
        }
        #endregion
    }
}
