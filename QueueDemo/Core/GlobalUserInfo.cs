using Microsoft.AspNetCore.SignalR;
using QueueDemo.Model;

namespace QueueDemo.Core
{
    public static class GlobalUserInfo
    {
        public static IHubCallerClients Clients;

        private static List<UserInfo> userInfos = new()
        {
            new UserInfo {UserId = 1, Index =  "U0000A1", UserName = "Us Z", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 2, Index =  "U0000A2", UserName = "John Smith", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 3, Index =  "U0000A3", UserName = "Emily Johnson", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 4, Index =  "U0000A4", UserName = "Michael Williams", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 5, Index =  "U0000A5", UserName = "Jessica Brown", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 6, Index =  "U0000A6", UserName = "James Jones", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 7, Index =  "U0000A7", UserName = "Olivia Miller", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 8, Index =  "U0000A8", UserName = "William Davis", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 9, Index =  "U0000A9", UserName = "Ava Garcia", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 10, Index =  "U0000A10", UserName = "Liam Rodriguez", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 11, Index =  "U0000A11", UserName = "Sophia Martinez", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 12, Index =  "U0000A12", UserName = "Benjamin Wilson", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 13, Index =  "U0000A13", UserName = "Mia Anderson", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 14, Index =  "U0000A14", UserName = "Lucas Taylor", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 15, Index =  "U0000A15", UserName = "Charlotte Thomas", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 16, Index =  "U0000A16", UserName = "Jacob Hernandez", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 17, Index =  "U0000A17", UserName = "Harper Moore", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 18, Index =  "U0000A18", UserName = "Daniel Clark", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 19, Index =  "U0000A19", UserName = "Luna Lewis", Pwd = GenerateRandomPassword() },
            new UserInfo {UserId = 20, Index =  "U0000A20", UserName = "Alexander Young", Pwd = GenerateRandomPassword() }
        };

        private static string GenerateRandomPassword()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string password = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }

        public static List<UserInfo> UserInfos
        {
            get { return userInfos; }
            set { userInfos = value; }
        }
    }
}
