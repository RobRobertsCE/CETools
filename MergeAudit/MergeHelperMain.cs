using MergeHelper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MergeHelper.Common;

namespace MergeHelper
{
    public partial class MergeHelperMain : Form
    {
        private MergeTaskHelper _helper = new MergeTaskHelper();

        public MergeHelperMain()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void UpdateDisplay()
        {
            var taskDetailList = _helper.GetTaskList();

            UpdateDisplay(taskDetailList);
        }
        private void UpdateDisplay(IList<MergeTask> taskList)
        {
            try
            {
                lvMergeTasks.SuspendLayout();
                lvMergeTasks.Items.Clear();

                foreach (var task in taskList)
                {
                    lvMergeTasks.Items.Add(new ListViewItem(new string[] { task.PullRequestId, task.LastCompletedStep.MergeStep.ToString() }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                lvMergeTasks.ResumeLayout(true);
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                MergeProcessStatus initialStatus = 
                    MergeProcessStatus.RequiresPullRequest | 
                    MergeProcessStatus.RequiresPullRequestMerge | 
                    MergeProcessStatus.RequiresDevelopMerge;

                _helper.StartNewTask(txtPullRequestId.Text, initialStatus);

                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                _helper.ResetTaskList();
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                _helper.LoadTaskList();
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _helper.SaveTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            try
            {
                MergeStep completedStep = MergeStep.PullRequestAccepted;

                _helper.UpdateTask(txtPullRequestId.Text, "Rob", completedStep, completedStep.ToString());

                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
