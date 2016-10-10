namespace CECodeManager.Dialogs
{
    partial class AccountsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAccounts = new System.Windows.Forms.ComboBox();
            this.lblWinUser = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlAccountDetails = new System.Windows.Forms.Panel();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblToken = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlAccountDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnAddEdit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboAccounts);
            this.panel1.Controls.Add(this.lblWinUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 58);
            this.panel1.TabIndex = 0;
            // 
            // btnAddEdit
            // 
            this.btnAddEdit.Location = new System.Drawing.Point(185, 25);
            this.btnAddEdit.Name = "btnAddEdit";
            this.btnAddEdit.Size = new System.Drawing.Size(66, 21);
            this.btnAddEdit.TabIndex = 3;
            this.btnAddEdit.Text = "Add";
            this.btnAddEdit.UseVisualStyleBackColor = true;
            this.btnAddEdit.Click += new System.EventHandler(this.btnAddEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account info for:";
            // 
            // cboAccounts
            // 
            this.cboAccounts.FormattingEnabled = true;
            this.cboAccounts.Location = new System.Drawing.Point(15, 25);
            this.cboAccounts.Name = "cboAccounts";
            this.cboAccounts.Size = new System.Drawing.Size(164, 21);
            this.cboAccounts.TabIndex = 1;
            this.cboAccounts.SelectedIndexChanged += new System.EventHandler(this.cboAccounts_SelectedIndexChanged);
            // 
            // lblWinUser
            // 
            this.lblWinUser.AutoSize = true;
            this.lblWinUser.Location = new System.Drawing.Point(103, 9);
            this.lblWinUser.Name = "lblWinUser";
            this.lblWinUser.Size = new System.Drawing.Size(76, 13);
            this.lblWinUser.TabIndex = 0;
            this.lblWinUser.Text = "Windows User";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnApply);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 42);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(315, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(233, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(76, 28);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Enabled = false;
            this.btnOk.Location = new System.Drawing.Point(15, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlAccountDetails
            // 
            this.pnlAccountDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlAccountDetails.Controls.Add(this.txtToken);
            this.pnlAccountDetails.Controls.Add(this.txtPassword);
            this.pnlAccountDetails.Controls.Add(this.txtLogin);
            this.pnlAccountDetails.Controls.Add(this.lblToken);
            this.pnlAccountDetails.Controls.Add(this.label2);
            this.pnlAccountDetails.Controls.Add(this.lblLogin);
            this.pnlAccountDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAccountDetails.Enabled = false;
            this.pnlAccountDetails.Location = new System.Drawing.Point(0, 58);
            this.pnlAccountDetails.Name = "pnlAccountDetails";
            this.pnlAccountDetails.Size = new System.Drawing.Size(403, 141);
            this.pnlAccountDetails.TabIndex = 2;
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(15, 101);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(374, 20);
            this.txtToken.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(15, 62);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(164, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(15, 23);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(164, 20);
            this.txtLogin.TabIndex = 3;
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(12, 85);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(38, 13);
            this.lblToken.TabIndex = 2;
            this.lblToken.Text = "Token";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(12, 7);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login";
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(257, 25);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(66, 21);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Delete";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // AccountsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 241);
            this.Controls.Add(this.pnlAccountDetails);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AccountsDialog";
            this.Text = "Account Information";
            this.Load += new System.EventHandler(this.AccountsDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlAccountDetails.ResumeLayout(false);
            this.pnlAccountDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAccounts;
        private System.Windows.Forms.Label lblWinUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel pnlAccountDetails;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnAddEdit;
        private System.Windows.Forms.Button btnRemove;
    }
}