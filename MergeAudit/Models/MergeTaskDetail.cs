using System;
using System.Collections.Generic;
using static MergeHelper.Common;

namespace MergeHelper.Models
{
    public class MergeTaskDetail
    {
        #region properties
        public Guid Id { get; set; }

        public string PullRequestId { get; set; }

        public int Index { get; set; }

        public DateTime Created { get; set; }

        public DateTime? CompletedTimestamp { get; set; }

        public string CompletedBy { get; set; }

        public MergeStep MergeStep { get; set; }

        public bool IsComplete { get; set; }

        public IList<string> Data { get; set; }
        #endregion

        #region ctor
        public MergeTaskDetail()
        {
            Id = Guid.NewGuid();
            Data = new List<string>();
            Created = DateTime.Now;
            IsComplete = false;

            InitializeTaskDetail();
        }

        public MergeTaskDetail(MergeStep mergeStep, string pullRequestId) : this()
        {
            MergeStep = mergeStep;
            PullRequestId = pullRequestId;
        }

        public MergeTaskDetail(MergeStep mergeStep, string pullRequestId, string comment) : this()
        {
            MergeStep = mergeStep;
            PullRequestId = pullRequestId;
            Data.Add(comment);
        }

        #endregion

        #region public
        public void TaskDetailCompleted(string completedBy)
        {
            this.CompletedBy = completedBy;
            CompletedTimestamp = DateTime.Now;
            IsComplete = true;
        }

        public void TaskDetailCompleted(string completedBy, IList<string> data)
        {
            TaskDetailCompleted(completedBy);
            ((List<string>)Data).AddRange(data);
        }

        public void TaskDetailCompleted(string completedBy, string data)
        {
            TaskDetailCompleted(completedBy, new List<string>() { data });
        }
        #endregion

        #region protected
        private void InitializeTaskDetail()
        {

        }
        #endregion

        #region private
        #endregion
    }
}
