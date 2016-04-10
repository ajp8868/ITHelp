using ITHelp_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

/*
 * This connects the api to the data service. It includes all the put, post and get methods required to get the data needed for the site.
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Api
{
    public class ServiceConnector
    {
        //base url of the data service. Line commented out was for testing purposes.
        private readonly string _baseUrl = "http://ithelpdata.azurewebsites.net/api/";
        //private readonly string _baseUrl = "http://localhost:57532/api/";


        //-----------------GETs-----------------//

        //Get all tickets from the data service or by Id if specified
        public List<Ticket> GetTickets(int id = -1)
        {
            string uri = checkUrl("tickets");

            if (id != -1)
            {
                uri += "/" + id.ToString();
            }
            
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

        //Get all assets from the data service or by Id if specified
        public List<Asset> GetAssets(int id = -1)
        {
            string uri = checkUrl("assets");

            if (id != -1)
            {
                uri += "/" + id.ToString();
            }

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

        //Get all users from the data service or by Id if specified
        public List<User> GetUsers(int id = -1)
        {
            var uri = checkUrl("users");

            if (id != -1)
            {
                uri += "/" + id.ToString();
            }

            using (var httpClient = new HttpClient())
            {
                List<User> users = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        users = JsonConvert.DeserializeObject<List<User>>(
                            httpClient.GetStringAsync(uri).Result);
                        Console.Out.WriteLine("Success getting Users");
                        i = 3;
                    }
                    catch (Exception)
                    {
                        Console.Out.WriteLine("Problem Getting Users. Attempt: " + (i + 1).ToString());
                    }
                }

                httpClient.Dispose();

                return users;
            }
        }

        //Get all ticket statuses from the data Service
        public List<Ticket_Statuses> GetTickStatuses(string statusUrl = "ticket_statuses")
        {

            var uri = checkUrl(statusUrl);

            using (var httpClient = new HttpClient())
            {
                List<Ticket_Statuses> statuses = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        statuses = JsonConvert.DeserializeObject<List<Ticket_Statuses>>(
                            httpClient.GetStringAsync(uri).Result);
                        Console.Out.WriteLine("Success getting statuses");
                        i = 3;
                    }
                    catch (Exception)
                    {
                        Console.Out.WriteLine("Problem Getting statuses. Attempt: " + (i + 1).ToString());
                    }
                }

                httpClient.Dispose();

                return statuses;
            }
        }

        //Get all ticket types from the Repository Service
        public List<Ticket_Types> GetTickTypes(string typesUrl = "ticket_types")
        {

            var uri = checkUrl(typesUrl);

            using (var httpClient = new HttpClient())
            {
                List<Ticket_Types> types = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        types = JsonConvert.DeserializeObject<List<Ticket_Types>>(
                            httpClient.GetStringAsync(uri).Result);
                        Console.Out.WriteLine("Success getting types");
                        i = 3;
                    }
                    catch (Exception)
                    {
                        Console.Out.WriteLine("Problem Getting types. Attempt: " + (i + 1).ToString());
                    }
                }

                httpClient.Dispose();

                return types;
            }
        }

        //Get all ticket urgencies from the data service
        public List<Ticket_Urgencies> GetTickUrgencies(string urgenciesUrl = "ticket_urgencies")
        {

            var uri = checkUrl(urgenciesUrl);

            using (var httpClient = new HttpClient())
            {
                List<Ticket_Urgencies> urgencies = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        urgencies = JsonConvert.DeserializeObject<List<Ticket_Urgencies>>(
                            httpClient.GetStringAsync(uri).Result);
                        Console.Out.WriteLine("Success getting urgencies");
                        i = 3;
                    }
                    catch (Exception)
                    {
                        Console.Out.WriteLine("Problem Getting urgencies. Attempt: " + (i + 1).ToString());
                    }
                }

                httpClient.Dispose();

                return urgencies;
            }
        }

        //Get all knowledge from the Data Service
        public List<Knowledge> GetKnowledge(int id = -1)
        {
            var uri = checkUrl("knowledge");

            if (id != -1)
            {
                uri += "/" + id.ToString();
            }
            
            using (var httpClient = new HttpClient())
            {
                List<Knowledge> knowledge = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        knowledge = JsonConvert.DeserializeObject<List<Knowledge>>(
                            httpClient.GetStringAsync(uri).Result);
                        Console.Out.WriteLine("Success getting knowledge");
                        i = 3;
                    }
                    catch (Exception)
                    {
                        Console.Out.WriteLine("Problem Getting knowledge. Attempt: " + (i + 1).ToString());
                    }
                }

                httpClient.Dispose();

                return knowledge;
            }
        }

       

        //--------------------PUTs---------------------//

        //puts a ticket into the data service. It must already exist for this to work.
        public async Task<HttpResponseMessage> PutTicketAsync(Ticket ticket, string ticketUrl = "tickets")
        {
            var uri = checkUrl(ticketUrl) + "/" + ticket.Id;

            using (var client = new HttpClient())
            {

                var x = await client.PutAsJsonAsync(uri, ticket).ConfigureAwait(false);

                return x;
            }
        }

        //Put an Asset object into the database
        public async Task<HttpResponseMessage> PutAssetAsync(Asset asset, string assetUrl = "assets")
        {
            var uri = checkUrl(assetUrl + "/" + asset.Id.ToString());

            using (var client = new HttpClient())
            {

                var x = await client.PutAsJsonAsync(uri, asset).ConfigureAwait(false);

                return x;
            }
        }

        //Put a knowledge object into the database
        public async Task<HttpResponseMessage> PutKnowledgeAsync(Knowledge knowledge, string knowledgeUrl = "knowledge")
        {
            var uri = checkUrl(knowledgeUrl + "/" + knowledge.Id.ToString());

            using (var client = new HttpClient())
            {

                var x = await client.PutAsJsonAsync(uri, knowledge).ConfigureAwait(false);

                return x;
            }
        }

        //Put a user object into the database
        public async Task<HttpResponseMessage> PutUserAsync(User user, string userUrl = "users")
        {
            var uri = checkUrl(userUrl + "/" + user.Id.ToString());

            using (var client = new HttpClient())
            {

                var x = await client.PutAsJsonAsync(uri, user).ConfigureAwait(false);

                return x;
            }
        }


        //----------------------POSTs-----------------------//

        //posts a new ticket object to the data service
        public async Task<HttpResponseMessage> PostTicketAsync(Ticket ticket, string ticketUrl = "tickets")
        {
            var uri = checkUrl(ticketUrl);

            using (var client = new HttpClient())
            {

                var x = await client.PostAsJsonAsync(uri, ticket).ConfigureAwait(false);

                return x;
            }
        }

        //post a new ticket history object to the data service
        public async Task<HttpResponseMessage> PostTicketHistoryAsync(Ticket_History tHistory, string ticketUrl = "ticket_history")
        {
            var uri = checkUrl(ticketUrl); ;

            using (var client = new HttpClient())
            {

                var x = await client.PostAsJsonAsync(uri, tHistory).ConfigureAwait(false);

                return x;
            }
        }

        //posts a user object to the database. This creates a new user
        public async Task<HttpResponseMessage> PostUserAsync(User user, string usersUrl = "users")
        {
            var uri = checkUrl(usersUrl);

            HttpResponseMessage x;

            using (var client = new HttpClient())
            {

                x = await client.PostAsJsonAsync(uri, user).ConfigureAwait(false);

            }

            return x;
        }

        //posts a Knowledge object to the database. This creates a new knowledge entity
        public async Task<HttpResponseMessage> PostKnowledgeAsync(Knowledge knowledge, string knowledgeUrl = "knowledge")
        {
            var uri = checkUrl(knowledgeUrl);

            HttpResponseMessage x;

            using (var client = new HttpClient())
            {

                x = await client.PostAsJsonAsync(uri, knowledge).ConfigureAwait(false);

            }

            return x;
        }

        //Post an Asset object into the database
        public async Task<HttpResponseMessage> PostAssetAsync(Asset asset, string assetUrl = "assets")
        {
            var uri = checkUrl(assetUrl);

            using (var client = new HttpClient())
            {

                var x = await client.PostAsJsonAsync(uri, asset).ConfigureAwait(false);

                return x;
            }
        }


        //------------------Helper Methods---------------------//

        //checks to make sure the url doesn't start with an extra slash
        private string checkUrl(string url)
        {
            return _baseUrl + url.TrimStart('/');
        }
    }
}