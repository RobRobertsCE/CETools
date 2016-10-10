using System;
using System.Collections.Generic;
using System.Linq;
using static MergeHelper.Common;

namespace MergeHelper.Models
{
    public class MergeTask
    {
        #region properties
        public Guid Id { get; set; }

        public string PullRequestId { get; set; }

        public bool IsComplete { get; set; }

        public MergeStep CurrentMergeStep
        {
            get
            {
                return MergeTaskDetails.LastOrDefault(t => t.IsComplete == true).MergeStep;
            }
        }

        public MergeProcessStatus MergeProcessStatus { get; set; }

        public MergeBranchState MergeBranchState { get; set; }

        public MergeTaskDetail LastCompletedStep
        {
            get
            {
                return MergeTaskDetails.OrderBy(t=>t.Index).LastOrDefault(t => t.IsComplete == true);
            }
        }

        public IList<MergeTaskDetail> MergeTaskDetails { get; private set; }
        #endregion

        #region ctor
        public MergeTask()
        {
            MergeProcessStatus = MergeProcessStatus.RequiresPullRequest;
            MergeTaskDetails = new List<MergeTaskDetail>();
            MergeTaskDetails.Add(new MergeTaskDetail(MergeStep.MergeTaskCreated, "0"));
            InitializeTask();
        }

        public MergeTask(string pullRequestId, MergeProcessStatus initialStatus) : this()
        {
            PullRequestId = pullRequestId;
            MergeProcessStatus = initialStatus;
            var initialDetail = new MergeTaskDetail(MergeStep.PullRequestSubmitted, pullRequestId);
            initialDetail.TaskDetailCompleted("Auto");
            MergeTaskDetails.Add(initialDetail);
        }
        #endregion

        #region public static
        public static MergeTask GetNewMergeTask(string pullRequestId, MergeProcessStatus initialStatus)
        {
            return new MergeTask(pullRequestId, initialStatus);
        }
        #endregion

        #region public
        public void AddTaskDetail(string completedBy, MergeStep stepCompleted, IList<string> data)
        {
            var newTaskDetail = new MergeTaskDetail(stepCompleted, PullRequestId, "New task created")
            {
                CompletedBy = completedBy,
                CompletedTimestamp=DateTime.Now,
                IsComplete = true,
                Index = MergeTaskDetails.Count + 1
            };
            ((List<string>)newTaskDetail.Data).AddRange(data);
            MergeTaskDetails.Add(newTaskDetail);
        }
        #endregion

        #region protected
        private void InitializeTask()
        {

        }
        #endregion

        #region private
        #endregion
    }
}
