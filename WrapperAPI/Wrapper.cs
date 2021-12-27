﻿using System;

using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;


namespace WrapperAPI
{
    public class Wrapper
    {
        private RestClient Client;

        public Wrapper()
        {
            Client = new RestClient("https://test.loy.am")
            {
                Authenticator = new HttpBasicAuthenticator("loyam_test", "0IcbmorPNeuEcywxvaGQzznSd3pIl8BF12hT8eeExuZ2G9XYJH7YHeQh")
            };
        }
        
        private class LoginAns
        {
            public string token_type { get; set; }
            public string expires_in { get; set; }
            public string access_token { get; set; }
            public string refresh_token { get; set; }

        }

        private class RegistrateAns
        {
            public string message { get; set; }
            public  Errors errors { get; set; }

        }
        
        private class Errors
        {
            public string[] username { get; set; }
            public string[] email { get; set; }
            
            public string[] password { get; set; }
        }

        
        
        public Tuple<string,string, bool> Login(string username, string password)
        {
            var request = new RestRequest("/oauth/token", Method.POST);
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            var ans = JsonConvert.DeserializeObject<LoginAns>(Client.Execute(request).Content);
            return Tuple.Create(ans?.access_token, ans?.refresh_token , ans?.access_token!=null);
        }

        public Tuple<bool, string[], string[], string[]> Registrate(string username, string password, string email) 
        {
            var request = new RestRequest("/api/users",Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("email", email);
            var tmp = Client.Execute(request).Content;
            Console.WriteLine(tmp);
            var ans = JsonConvert.DeserializeObject<RegistrateAns>(tmp);
            var isOk = ans != null && ans.message == null;
            string[] errorUsername = null;
            string[] errorEmail = null;
            string[] errorPasword = null;
            if (isOk) return Tuple.Create(isOk, errorEmail, errorUsername, errorPasword);
            
            if (ans != null) errorUsername = ans.errors.username;
            if (ans != null) errorEmail = ans.errors.email;
            if (ans != null) errorPasword = ans.errors.password;

            return Tuple.Create(isOk, errorEmail, errorUsername, errorPasword);
            

        }
        
        private class RefreshTokenAns
        {
            public string access_token { get; set; }
            public string refresh_token { get; set; }
        }

        public  Tuple<string, string, bool> RefreshToken(string refreshToken)
        {
            var request = new RestRequest("/oauth/token",Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("refresh_token", refreshToken);
            var ans = JsonConvert.DeserializeObject<RefreshTokenAns>(Client.Execute(request).Content);
            return Tuple.Create(ans?.access_token, ans?.refresh_token,  ans?.access_token!=null);
        }
        
        // public string UpdateUser() ?
        
        // public ApproveEmail() ? откуда берется хэш
        
        // Approve email Again ???
    }
}