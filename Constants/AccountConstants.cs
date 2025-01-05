using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPI.Constants
{
    public static class AccountConstants
    {
        public const int MinLengthUsername = 3;
        public const string MinUsernameErrorMessage = "Username must be at least 3 characters";
        public const int MaxLengthUsername = 100;
        public const string MaxUsernameErrorMessage = "Username can't be more than 100 characters";
        public const int STATUS_CODE_500 = 500;
    }
}