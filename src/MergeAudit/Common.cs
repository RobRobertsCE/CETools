using System;

namespace MergeHelper
{
    public static class Common
    {
        public enum MergeBranchState
        {            
            HasPullRequestComments,
            TestBuildFailed,
            TestBuildPassed,
            HasMergeConflicts,
            RequiresPatch,
            PatchFilesPublished,
            Complete
        }

        [Flags()]
        public enum MergeProcessStatus
        {
            RequiresPullRequest = 1 << 0,
            RequiresPullRequestMerge = 1 << 1,
            RequiresMasterMerge = 1 << 2,
            RequiresMasterPatch = 1 << 3,
            RequiresReleaseMerge = 1 << 4,
            RequiresReleasePatch = 1 << 5,
            RequiresBetaMerge = 1 << 6,
            RequiresBetaPatch = 1 << 7,
            RequiresDevelopMerge = 1 << 8,
            Complete = 1 << 32
        }

        [Flags()]
        public enum MergeStep : Int64
        {
            MergeTaskCreated = 0,
            PullRequestSubmitted = 1 << 0,
            PullRequestTestBuildComplete = 1 << 1,
            PullRequestAccepted = 1 << 2,
            PullRequestClosed = 1 << 3,
            MasterBranchCheckedOut = 1 <<4,
            MasterBranchSyncedFromOrigin = 1 << 5,
            MasterMergeBranchCreated = 1 << 6,
            MasterMergeBranchSyncedByPull = 1 << 7,
            WorkMergedIntoMasterMergeBranch = 1 << 8,
            MasterMergeBranchPublished = 1 << 9,
            MasterMergeBranchTestBuildComplete = 1 << 10,
            MasterMergeBranchMergedIntoMasterBranch = 1 << 11,
            MasterBranchPatchesBuilt = 1 << 12,
            MasterBranchPatchesPublished = 1 << 13,
            MasterBranchPatchNotesUpdated = 1 << 14,
            ReleaseBranchCheckedOut = 1 << 15,
            ReleaseBranchSyncedFromOrigin = 1 << 16,
            ReleaseMergeBranchCreated = 1 << 17,
            ReleaseMergeBranchSyncedByPull = 1 << 18,
            WorkMergedIntoReleaseMergeBranch = 1 << 19,
            ReleaseMergeBranchPublished = 1 << 20,
            ReleaseMergeBranchTestBuildComplete = 1 << 21,
            ReleaseMergeBranchMergedIntoReleaseBranch = 1 << 22,
            ReleaseBranchPatchesBuilt = 1 << 23,
            ReleaseBranchPatchesPublished = 1 << 24,
            ReleaseBranchPatchNotesUpdated = 1 << 25,
            BetaBranchCheckedOut = 1 << 26,
            BetaBranchSyncedFromOrigin = 1 << 27,
            BetaMergeBranchCreated = 1 << 28,
            BetaMergeBranchSyncedByPull = 1 << 29,
            WorkMergedIntoBetaMergeBranch = 1 << 30,
            BetaMergeBranchPublished = 1 << 31,
            BetaMergeBranchTestBuildComplete = 1 << 32,
            BetaMergeBranchMergedIntoBetaBranch = 1 << 33,
            BetaBranchPatchesBuilt = 1 << 34,
            BetaBranchPatchesPublished = 1 << 35,
            BetaBranchPatchNotesUpdated = 1 << 36,
            DevelopBranchCheckedOut = 1 << 37,
            DevelopBranchSyncedFromOrigin = 1 << 38,
            DevelopMergeBranchCreated = 1 << 39,
            DevelopMergeBranchSyncedByPull = 1 << 40,
            WorkMergedIntoDevelopMergeBranch = 1 << 41,
            DevelopMergeBranchPublished = 1 << 42,
            DevelopMergeBranchTestBuildComplete = 1 << 43,
            DevelopMergeBranchMergedIntoDevelopBranch = 1 << 44,
            DevelopBranchPatchesBuilt = 1 << 45,
            DevelopBranchPatchesPublished = 1 << 46,
            DevelopBranchPatchNotesUpdated = 1 << 47,
            JIRAStatusUpdated = 1 << 48,
            JIRACommentsAdded = 1 << 49,
            JIRAAssigned = 1 << 50,
            Complete = Int64.MaxValue 
        }
    }
}
