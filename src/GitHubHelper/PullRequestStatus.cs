namespace GitHubHelper
{
    public enum PullRequestStatus
    {
        Created = 1,
        TestBuildPassed = 1 << Created,
        Reviewed = 1 << TestBuildPassed,
        RequestClosedWithoutMerge = 1 << Reviewed,
        ReadyToMerge = Created | TestBuildPassed | Reviewed,
        PullRequestMerged = 1 << ReadyToMerge
    }
}
