using ITHelp_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ITHelp_Api
{
    public class ServiceConnector
    {
        private readonly string _baseUrl = "http://ithelpdata.azurewebsites.net/api/";

        private string checkUrl(string url)
        {
            if (url.StartsWith("/"))
            {
                return url = url.Remove(0);
            }

            return url;
        }

        //Get all assets from the Repository Service
        public List<Ticket> GetTickets(string productUrl = "tickets")
        {

            checkUrl(productUrl);
            var uri = _baseUrl + productUrl;

            using (var httpClient = new HttpClient())
            {
                List<Ticket> tickets = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        tickets = JsonConvert.DeserializeObject<List<Ticket>>(
                            httpClient.GetStringAsync(uri).Result);
                        Console.Out.WriteLine("Success getting Tickets");
                        i = 3;
                    }
                    catch (Exception)
                    {
                        Console.Out.WriteLine("Problem Getting Tickets. Attempt: " + (i + 1).ToString());
                    }
                }

                httpClient.Dispose();

                return tickets;
            }
        }

        //Get all assets from the Repository Service
        public List<Asset> GetAssets(string assettUrl = "assets")
        {
            checkUrl(assettUrl);

            var uri = _baseUrl + assettUrl;

            using (var httpClient = new HttpClient())
            {
                List<Asset> assets = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        assets = JsonConvert.DeserializeObject<List<Asset>>(
                            httpClient.GetStringAsync(uri).Result);
                        Console.Out.WriteLine("Success getting Assets");
                        i = 3;
                    }
                    catch (Exception)
                    {
                        Console.Out.WriteLine("Problem Getting Assets. Attempt: " + (i + 1).ToString());
                    }
                }

                httpClient.Dispose();

                return assets;
            }
        }

        //Get all assets from the Repository Service
        public List<User> GetUsers(string UsersUrl = "users")
        {

            checkUrl(UsersUrl);
            var uri = _baseUrl + UsersUrl;

            using (var httpClient = new HttpClient())
            {
                List<User> users = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        users = JsonConvert.DeserializeObject<List<User>>(
                            httpClient.GetStringAsync(uri).Result);
                        Console.Out.WriteLine("Success getting Tickets");
                        i = 3;
                    }
                    catch (Exception)
                    {
                        Console.Out.WriteLine("Problem Getting Tickets. Attempt: " + (i + 1).ToString());
                    }
                }

                httpClient.Dispose();

                return users;
            }
        }

        //Get all assets from the Repository Service
        public async Task<HttpResponseMessage> PostUserAsync(User user, string usersUrl = "users")
        {
            checkUrl(usersUrl);

            var uri = _baseUrl + usersUrl;

            HttpResponseMessage x;

            using (var client = new HttpClient())
            {

                x = await client.PostAsJsonAsync(uri, user).ConfigureAwait(false);

            }

            return x;
        }
    }
}