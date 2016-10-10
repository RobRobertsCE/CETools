using CETools.Encryption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CETools.Identities
{
    public static class IdentityAccountHelper
    {
        #region fields
        private const string IdentityDataFileName = "CETools.Data.bin";
        private const string AESSecret = "br549";
        #endregion

        #region fields
        private static IList<TokenizedIdentity> _identities;
        #endregion

        #region ctor
        static IdentityAccountHelper()
        {
            LoadIdentityAccounts();
        }
        #endregion

        #region public
        public static TokenizedIdentity GetJIRAAccountInfo()
        {
            return GetAccountInfo(Environment.UserName, IdentityAccount.JIRA);
        }
        public static TokenizedIdentity GetGitHubAccountInfo()
        {
            return GetAccountInfo(Environment.UserName, IdentityAccount.GitHub);
        }
        public static TokenizedIdentity GetTeamCityAccountInfo()
        {
            return GetAccountInfo(Environment.UserName, IdentityAccount.TeamCity);
        }
        public static TokenizedIdentity GetTAccountInfo(IdentityAccount account)
        {
            return GetAccountInfo(Environment.UserName, account);
        }

        public static IList<TokenizedIdentity> GetUserAccountInfos()
        {
            return GetAccountInfos(Environment.UserName);
        }

        public static bool UpdateAccountInfo(TokenizedIdentity identity)
        {
            if (identity.WinUser != Environment.UserName)
            {
                throw new InvalidOperationException("Permission denied");
            }

            RemoveIdentity(identity);

            return AddAccountInfo(identity);
        }

        public static bool AddAccountInfo(IdentityAccount account, string login, string password, string token)
        {
            var identity = new TokenizedIdentity()
            {
                WinUser = Environment.UserName,
                Account = account,
                Login = login,
                Password = password,
                Token = token
            };
            return AddAccountInfo(identity);
        }

        public static bool AddAccountInfo(TokenizedIdentity identity)
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

        public static bool DeleteAccountInfo(TokenizedIdentity identity)
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
            _identities = new List<TokenizedIdentity>();

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
                    _identities = JsonConvert.DeserializeObject<List<TokenizedIdentity>>(unencryptedJson);
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
        private static TokenizedIdentity GetAccountInfo(string winUser, IdentityAccount account)
        {
            return _identities.FirstOrDefault(i => i.WinUser == winUser & i.Account == account);
        }

        private static IList<TokenizedIdentity> GetAccountInfos(string winUser)
        {
            return _identities.Where(i => i.WinUser == winUser).ToList();
        }

        private static bool AddIdentity(TokenizedIdentity identity)
        {
            var identityToUpdate = _identities.FirstOrDefault(i => i.WinUser == identity.WinUser & i.Account == identity.Account);

            if (null != identityToUpdate)
            {
                throw new InvalidOperationException("Identity already exists");
            }

            _identities.Add(identity);

            return true;
        }

        private static bool RemoveIdentity(TokenizedIdentity identity)
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
