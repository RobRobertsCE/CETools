using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CETools.Identities
{
    public class AccountProfile
    {
        public AccountType Account { get; set; }

        public string WinUser { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public string URL { get; set; }

        public string Owner { get; set; }
    }
}
