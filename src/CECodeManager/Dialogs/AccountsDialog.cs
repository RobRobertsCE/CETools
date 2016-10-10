using CETools.Identities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CECodeManager.Dialogs
{
    public partial class AccountsDialog : Form
    {
        private bool _loading = true;
        private bool _editing = false;
        private TokenizedIdentity _selectedIdentity;

        public AccountsDialog()
        {
            InitializeComponent();
        }

        private void AccountsDialog_Load(object sender, EventArgs e)
        {
            try
            {
                lblWinUser.Text = Environment.UserName;
                List<IdentityAccount> modes = Enum.GetValues(typeof(IdentityAccount)).Cast<IdentityAccount>().ToList();
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

        private void cboAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_loading) return;

                if (null == cboAccounts.SelectedItem) return;

                var selectedAccount = (IdentityAccount)cboAccounts.SelectedItem;

                _selectedIdentity = IdentityAccountHelper.GetTAccountInfo(selectedAccount);
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

        private void DisplaySelectedAccountIdentity(TokenizedIdentity identity)
        {
            txtLogin.Text = identity.Login;
            txtPassword.Text = identity.Password;
            txtToken.Text = identity.Token;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "Close")
                this.Close();
            else
            {
                ClearAccountDetailsDisplay();
                ResetFormState();
            }
        }

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedAccount = (IdentityAccount)cboAccounts.SelectedItem;
                cboAccounts.Enabled = false;
                btnAddEdit.Enabled = false;
                btnApply.Enabled = true;
                btnOk.Enabled = true;
                btnApply.Enabled = true;
                pnlAccountDetails.Enabled = true;
                btnClose.Text = "Cancel";

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

        private void AddNewIdentity(IdentityAccount account)
        {
            try
            {
                cboAccounts.Enabled = false;
                btnAddEdit.Enabled = false;
                btnApply.Enabled = true;

                _selectedIdentity = new TokenizedIdentity()
                {
                    WinUser = Environment.UserName,
                    Account = account,
                    Login = "<login>",
                    Password = "<password>",
                    Token = "<token>"
                };

                DisplaySelectedAccountIdentity(_selectedIdentity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private void SaveChanges()
        {
            try
            {
                _selectedIdentity.Login = txtLogin.Text;
                _selectedIdentity.Password = txtPassword.Text;
                _selectedIdentity.Token = txtToken.Text;
                IdentityAccountHelper.UpdateAccountInfo(_selectedIdentity);
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveIdentity();
        }

        private void RemoveIdentity()
        {
            try
            {
                IdentityAccountHelper.DeleteAccountInfo(_selectedIdentity);
                ClearAccountDetailsDisplay();
                ResetFormState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
