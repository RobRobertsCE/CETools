using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubHelper
{
    public class GitHubRepository
    {
        public string Name { get; set; }

        public IList<GitHubBranch> Branches { get; set; }


    }
}
