using System;
using System.Collections.Generic;

namespace Blog
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime EmailVerified { get; set; }
        public string Image { get; set; }
        public List<Session> Sessions { get; set; } 
        public List<Account> Accounts { get; set; }
    }

    public class Session
    {
        public int Id { get; set; }
        public string SessionToken { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Expires { get; set; }
    }

    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Type { get; set; }
        public string Provider { get; set; }
        public string ProviderAccountId { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresAt { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
        public string IdToken { get; set; }
        public string SessionState { get; set; }
        public string OauthTokenSecret { get; set; }
        public string OauthToken { get; set; }
    }
}