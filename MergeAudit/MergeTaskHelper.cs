using MergeHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static MergeHelper.Common;

namespace MergeHelper
{
    public class MergeTaskHelper
    {
        #region constants
        private const string JsonDataFile = "MergeHelperData.json";
        #endregion

        #region fields
        private IDictionary<string, MergeTask> _tasks;
        #endregion

        #region ctor
        public MergeTaskHelper()
        {
            ResetTaskList();
        }
        #endregion

        #region public
        public void StartNewTask(string pullRequestId, MergeProcessStatus initialStatus)
        {
            if (_tasks.ContainsKey(pullRequestId))
            {
                throw new ArgumentException("A task for this pull request already exists");
            }
            var newTask = MergeTask.GetNewMergeTask(pullRequestId, initialStatus);
            _tasks.Add(pullRequestId, newTask);
        }

        public MergeTask SelectTask(string pullRequestId)
        {
            if (!_tasks.ContainsKey(pullRequestId))
            {
                throw new ArgumentException(string.Format("No task for pull request {0} exists", pullRequestId));
            }
            return _tasks[pullRequestId];
        }

        public MergeTask UpdateTask(string pullRequestId, string completedBy, MergeStep stepCompleted, string data)
        {
            return UpdateTask(pullRequestId, completedBy, stepCompleted, new List<string>() { data });
        }
        public MergeTask UpdateTask(string pullRequestId, string completedBy, MergeStep stepCompleted, IList<string> data)
        {
            var task = SelectTask(pullRequestId);

            task.AddTaskDetail(completedBy, stepCompleted, data);

            _tasks[pullRequestId] = task;

            return task;
        }

        public MergeTaskDetail GetLastStep(string pullRequestId)
        {
            var task = SelectTask(pullRequestId);

            return task.LastCompletedStep;
        }

        public IList<MergeTaskDetail> GetLastStepList()
        {
            var results = new List<MergeTaskDetail>();

            foreach (var taskItem in _tasks)
            {
                var lastStep = taskItem.Value.LastCompletedStep;
                results.Add(lastStep);
            }

            return results;
        }

        public IList<MergeTask> GetTaskList()
        {
            var results = new List<MergeTask>();

            foreach (var taskItem in _tasks)
            {
                var task = taskItem.Value;
                results.Add(task);
            }

            return results;
        }

        public void SaveTaskList()
        {
            SaveTaskList(JsonDataFile);
        }
        public void SaveTaskList(string fileName)
        {
            var taskBuffer = _tasks.Values.ToList();

            var json = JsonConvert.SerializeObject(taskBuffer);

            File.WriteAllText(fileName, json);
        }

        public void LoadTaskList()
        {
            LoadTaskList(JsonDataFile);
        }
        public void LoadTaskList(string fileName)
        {
            if (File.Exists(JsonDataFile))
            {
                var json = File.ReadAllText(JsonDataFile);

                List<MergeTask> taskArray = JsonConvert.DeserializeObject<List<MergeTask>>(json);

                var taskBuffer = new Dictionary<string, MergeTask>();

                foreach (var item in taskArray)
                {
                    taskBuffer.Add(item.PullRequestId, item);
                }

                _tasks = taskBuffer;
            }
        }

        public void ResetTaskList()
        {
            _tasks = new Dictionary<string, MergeTask>();
        }         
        #endregion
    }
}
