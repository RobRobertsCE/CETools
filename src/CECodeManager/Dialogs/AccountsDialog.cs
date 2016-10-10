using CETools.Identities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CECodeManager.Dialogs
{
    public partial class AccountsDialog : Form
    {
        #region fields
        private bool _loading = true;
        private bool _editing = false;
        private AccountProfile _selectedIdentity;
        #endregion

        #region ctor / load
        public AccountsDialog()
        {
            InitializeComponent();
        }

        private void AccountsDialog_Load(object sender, EventArgs e)
        {
            try
            {
                lblWinUser.Text = Environment.UserName;
                List<AccountType> modes = Enum.GetValues(typeof(AccountType)).Cast<AccountType>().ToList();
                cboAccounts.DataSource = modes;
                cboAccounts.SelectedIndex = -1;

                ResetFormState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                _loading = false;
                cboAccounts.SelectedIndex = 0;
            }
        }
        #endregion

        #region display identity
        private void cboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_loading) return;

                if (null == cboAccounts.SelectedItem) return;

                var selectedAccount = (AccountType)cboAccounts.SelectedItem;

                _selectedIdentity = AccountProfileHelper.GetTAccountInfo(selectedAccount);
                if (null != _selectedIdentity)
                {
                    btnAddEdit.Text = "Edit";
                    btnRemove.Enabled = true;
                    DisplaySelectedAccountIdentity(_selectedIdentity);
                }
                else
                {
                    ClearAccountDetailsDisplay();
                    btnRemove.Enabled = false;
                    btnAddEdit.Text = "Add";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void ClearAccountDetailsDisplay()
        {
            txtLogin.Clear();
            txtPassword.Clear();
            txtToken.Clear();
            txtUrl.Clear();
            txtOwner.Clear();
        }

        private void ResetFormState()
        {
            _editing = false;
            cboAccounts.Enabled = true;
            btnAddEdit.Enabled = true;
            btnApply.Enabled = false;
            pnlAccountDetails.Enabled = false;
            btnClose.Text = "Close";
            btnOk.Enabled = false;
            btnApply.Enabled = false;
        }

        private void DisplaySelectedAccountIdentity(AccountProfile identity)
        {
            txtLogin.Text = identity.Login;
            txtPassword.Text = identity.Password;
            txtToken.Text = identity.Token;
            txtOwner.Text = identity.Owner;
            txtUrl.Text = identity.URL;
        }
        #endregion

        #region add/edit identity
        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedAccount = (AccountType)cboAccounts.SelectedItem;
                cboAccounts.Enabled = false;
                btnAddEdit.Enabled = false;
                btnApply.Enabled = true;
                btnOk.Enabled = true;
                btnApply.Enabled = true;
                pnlAccountDetails.Enabled = true;
                btnClose.Text = "Cancel";

                switch(selectedAccount)
                {
                    case AccountType.JIRA:
                        {
                            txtLogin.Enabled = true;
                            txtPassword.Enabled = true;
                            txtToken.Enabled = false;
                            txtOwner.Enabled = true;
                            txtUrl.Enabled = true;
                            break;
                        }
                    case AccountType.GitHub:
                        {
                            txtLogin.Enabled = true;
                            txtPassword.Enabled = true;
                            txtToken.Enabled = true;
                            txtOwner.Enabled = true;
                            txtUrl.Enabled = false;
                            break;
                        }
                    case AccountType.TeamCity:
                        {
                            txtLogin.Enabled = true;
                            txtPassword.Enabled = true;
                            txtToken.Enabled = false;
                            txtOwner.Enabled = false;
                            txtUrl.Enabled = false;
                            break;
                        }
                }

                if (btnAddEdit.Text == "Edit")
                {
                    DisplaySelectedAccountIdentity(_selectedIdentity);
                }
                else if (btnAddEdit.Text == "Add")
                {
                    AddNewIdentity(selectedAccount);
                }
                _editing = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void AddNewIdentity(AccountType account)
        {
            try
            {
                cboAccounts.Enabled = false;
                btnAddEdit.Enabled = false;
                btnApply.Enabled = true;

                _selectedIdentity = new AccountProfile()
                {
                    WinUser = Environment.UserName,
                    Account = account,
                    Login = "<required>"
                };

                DisplaySelectedAccountIdentity(_selectedIdentity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region apply / save changes
        private void SaveChanges()
        {
            try
            {
                if (string.IsNullOrEmpty(txtLogin.Text))
                    MessageBox.Show("Login name is required");
                else
                {
                    _selectedIdentity.Login = txtLogin.Text;
                    _selectedIdentity.Password = txtPassword.Text;
                    _selectedIdentity.Token = txtToken.Text;
                    _selectedIdentity.URL = txtUrl.Text;
                    _selectedIdentity.Owner = txtOwner.Text;
                    AccountProfileHelper.UpdateAccountInfo(_selectedIdentity);
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            try
            {
                SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (_editing) SaveChanges();
                ResetFormState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        } 
        #endregion

        #region remove identity
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveIdentity();
        }

        private void RemoveIdentity()
        {
            try
            {
                AccountProfileHelper.DeleteAccountInfo(_selectedIdentity);
                ClearAccountDetailsDisplay();
                ResetFormState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region cancel / close
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "Close")
                this.Close();
            else
            {
                ClearAccountDetailsDisplay();
                ResetFormState();
                // reselect the current selection to reload the original data.
                var currentSelection = cboAccounts.SelectedIndex;
                cboAccounts.SelectedIndex = -1;
                cboAccounts.SelectedIndex = currentSelection;
            }
        }
        #endregion
    }
}
