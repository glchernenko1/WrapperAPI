using System;
using System.Web.UI.WebControls;
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

        public string Login(string username, string password)
        {
            var request = new RestRequest("/oauth/token", Method.POST);
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            return Client.Execute(request).Content;;
        }

        public string Registrate(string username, string password, string email) 
        {
            var request = new RestRequest("/api/users",Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("email", email);
            return Client.Execute(request).Content;;
        }
        


        public string RefreshToken(string refreshToken)
        {
            var request = new RestRequest("/oauth/token",Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("refresh_token", refreshToken);
            return Client.Execute(request).Content;;
        }
        
        // public string UpdateUser() ?
        
        // public ApproveEmail() ? откуда берется хэш
        
        // Approve email Again ???
    }
}