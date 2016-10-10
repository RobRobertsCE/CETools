using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubHelper
{
    public class GitHubPullRequest
    {
        public string Id { get; set; }
        
        public string Number { get; set; }

        public PullRequestStatus Status { get; set; }

        public IList<GitHubCommit> Commits { get; set; }
    }
}
