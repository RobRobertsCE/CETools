using CETools.Encryption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CETools.Identities
{
    public static class AccountProfileHelper
    {
        #region fields
        private const string IdentityDataFileName = "CETools.Data.bin";
        private const string AESSecret = "br549";
        #endregion

        #region fields
        private static IList<AccountProfile> _identities;
        #endregion

        #region ctor
        static AccountProfileHelper()
        {
            LoadIdentityAccounts();
        }
        #endregion

        #region public
        public static AccountProfile GetJIRAAccountInfo()
        {
            return GetAccountInfo(Environment.UserName, AccountType.JIRA);
        }
        public static AccountProfile GetGitHubAccountInfo()
        {
            return GetAccountInfo(Environment.UserName, AccountType.GitHub);
        }
        public static AccountProfile GetTeamCityAccountInfo()
        {
            return GetAccountInfo(Environment.UserName, AccountType.TeamCity);
        }
        public static AccountProfile GetTAccountInfo(AccountType account)
        {
            return GetAccountInfo(Environment.UserName, account);
        }

        public static IList<AccountProfile> GetUserAccountInfos()
        {
            return GetAccountInfos(Environment.UserName);
        }

        public static bool UpdateAccountInfo(AccountProfile identity)
        {
            if (identity.WinUser != Environment.UserName)
            {
                throw new InvalidOperationException("Permission denied");
            }

            RemoveIdentity(identity);

            return AddAccountInfo(identity);
        }

        public static bool AddAccountInfo(AccountType account, string login, string password, string token)
        {
            var identity = new AccountProfile()
            {
                WinUser = Environment.UserName,
                Account = account,
                Login = login,
                Password = password,
                Token = token
            };
            return AddAccountInfo(identity);
        }

        public static bool AddAccountInfo(AccountProfile identity)
        {
            if (String.IsNullOrEmpty(identity.WinUser))
                identity.WinUser = Environment.UserName;

            if (identity.WinUser != Environment.UserName)
            {
                throw new InvalidOperationException("Permission denied");
            }

            var success = AddIdentity(identity);

            if (success) SaveIdentityAccounts();

            return success;
        }

        public static bool DeleteAccountInfo(AccountProfile identity)
        {
            if (identity.WinUser != Environment.UserName)
            {
                throw new InvalidOperationException("Permission denied");
            }

            var success = RemoveIdentity(identity);

            if (success) SaveIdentityAccounts();

            return success;
        }
        #endregion

        #region private
        #region load / save
        private static void LoadIdentityAccounts()
        {
            _identities = new List<AccountProfile>();

            var identityDataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, IdentityDataFileName);

            if (!File.Exists(identityDataFile))
            {
                File.Create(identityDataFile);
            }
            else
            {
                var encryptedJson = File.ReadAllText(identityDataFile);
                if (!String.IsNullOrEmpty(encryptedJson))
                {
                    var unencryptedJson = AES.DecryptStringAES(encryptedJson, AESSecret);
                    _identities = JsonConvert.DeserializeObject<List<AccountProfile>>(unencryptedJson);
                }
            }
        }

        private static void SaveIdentityAccounts()
        {
            var encryptedJson = String.Empty;
            if (_identities.Count > 0)
            {
                var json = JsonConvert.SerializeObject(_identities);
                encryptedJson = AES.EncryptStringAES(json, AESSecret);
            }
            var identityDataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, IdentityDataFileName);
            File.WriteAllText(identityDataFile, encryptedJson);
        }
        #endregion

        #region select / add / remove        
        private static AccountProfile GetAccountInfo(string winUser, AccountType account)
        {
            return _identities.FirstOrDefault(i => i.WinUser == winUser & i.Account == account);
        }

        private static IList<AccountProfile> GetAccountInfos(string winUser)
        {
            return _identities.Where(i => i.WinUser == winUser).ToList();
        }

        private static bool AddIdentity(AccountProfile identity)
        {
            var identityToUpdate = _identities.FirstOrDefault(i => i.WinUser == identity.WinUser & i.Account == identity.Account);

            if (null != identityToUpdate)
            {
                throw new InvalidOperationException("Identity already exists");
            }

            _identities.Add(identity);

            return true;
        }

        private static bool RemoveIdentity(AccountProfile identity)
        {
            var identityToRemove = _identities.FirstOrDefault(i => i.WinUser == identity.WinUser & i.Account == identity.Account);

            if (null != identityToRemove)
            {
                _identities.Remove(identityToRemove);
            }

            return true;
        }
        #endregion
        #endregion
    }
}
