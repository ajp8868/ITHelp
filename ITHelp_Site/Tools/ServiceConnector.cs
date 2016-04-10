using ITHelp_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ITHelp_Site
{
    public class ServiceConnector
    {
        //----------Globals------------//
        
        private readonly string _baseUrl = "http://ithelpapi.azurewebsites.net/api/";
        //private readonly string _baseUrl = "http://localhost:50305/api/";
        
        //---------------GETs----------------//

        //Get all tickets from the Repository Service
        public List<Ticket> GetTicketsAsync(string ticketsUrl = "tickets")
        {
            var uri = checkUrl(ticketsUrl);

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

        //gets all tickets filtered by the filter object
        public List<Ticket> GetTicketsWithParamsAsync(TicketFilter filter)
        {
            var uri = checkUrl("tickets/filter");
            
            using (var httpClient = new HttpClient())
            {
                List<Ticket> tickets = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        tickets = JsonConvert.DeserializeObject<List<Ticket>>(
                            httpClient.PostAsJsonAsync(uri, filter).Result.Content.ReadAsStringAsync().Result);
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

        //Gets a ticket by ID
        public Ticket GetTicketByIdAsync(int id)
        {
            var uri = checkUrl("tickets/" + id.ToString());

            using (var httpClient = new HttpClient())
            {
                Ticket tickets = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        tickets = JsonConvert.DeserializeObject<Ticket>(
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

        //Get all tickets by user from the database
        public List<Ticket> GetTicketsByUser(string username)
        {

            var uri = checkUrl("tickets/user/" + username);

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
        public List<Asset> GetAssetsAsync(string assettUrl = "assets")
        {
            var uri = checkUrl(assettUrl);

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

        //Gets an asset by ID from the database
        public Asset GetAssetById(int id)
        {
            var uri = checkUrl("assets/" + id.ToString());

            using (var httpClient = new HttpClient())
            {
                Asset asset = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        asset = JsonConvert.DeserializeObject<Asset>(
                            httpClient.GetStringAsync(uri).Result);
                        Console.Out.WriteLine("Success getting Asset");
                        i = 3;
                    }
                    catch (Exception)
                    {
                        Console.Out.WriteLine("Problem Getting Asset. Attempt: " + (i + 1).ToString());
                    }
                }

                httpClient.Dispose();

                return asset;
            }
        }

        //Get all users from the Repository Service
        public List<User> GetUsersAsync(string UsersUrl = "users")
        {

            var uri = checkUrl(UsersUrl);

            using (var httpClient = new HttpClient())
            {
                List<User> users = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        users = JsonConvert.DeserializeObject<List<User>>(
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

                return users;
            }
        }

        //Gets a user by username from the api service
        public User GetUserAsync(string username, string UsersUrl = "user")
        {
            var uri = checkUrl(UsersUrl + "/" + username);

            using (var httpClient = new HttpClient())
            {
                User user = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        user = JsonConvert.DeserializeObject<User>(
                            httpClient.GetStringAsync(uri).Result);
                        Console.Out.WriteLine("Success getting User");
                        i = 3;
                    }
                    catch (Exception)
                    {
                        Console.Out.WriteLine("Problem Getting user. Attempt: " + (i + 1).ToString());
                    }
                }

                httpClient.Dispose();

                return user;
            }
        }

        //Gets a user by ID from the database
        public User GetUserByIdAsync(int id, string UsersUrl = "user")
        {
            var uri = checkUrl(UsersUrl + "/id/" + id.ToString());

            using (var httpClient = new HttpClient())
            {
                User user = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        user = JsonConvert.DeserializeObject<User>(
                            httpClient.GetStringAsync(uri).Result);
                        Console.Out.WriteLine("Success getting User");
                        i = 3;
                    }
                    catch (Exception)
                    {
                        Console.Out.WriteLine("Problem Getting user. Attempt: " + (i + 1).ToString());
                    }
                }

                httpClient.Dispose();

                return user;
            }
        }

        //Gets ticket statuses from the api service
        public List<Ticket_Statuses> GetTickStatuses(string statusUrl = "tickets/statuses")
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

        //Gets ticket types from the api service
        public List<Ticket_Types> GetTickTypes(string typesUrl = "tickets/types")
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

        //Get ticket urgencies from the api service
        public List<Ticket_Urgencies> GetTickUrgencies(string urgenciesUrl = "tickets/urgencies")
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

        //Get knowledge by ID from the database
        public Knowledge GetKnowledgeByIdAsync(int id)
        {
            var uri = checkUrl("knowledge/" + id.ToString());

            using (var httpClient = new HttpClient())
            {
                Knowledge knowledge = null;

                for (var i = 0; i <= 2; i++)
                {
                    try
                    {
                        knowledge = JsonConvert.DeserializeObject<Knowledge>(
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

        //Get all knowledge filtered using a search string if supplied
        public List<Knowledge> GetKnowledgeAsync(string search)
        {
            var uri = checkUrl("knowledge");

            if (search != null)
            {
                uri += "?search=" + search.Replace(" ", "%20");
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


        //-------------PUTs----------------//

        //updates a ticket in the database, using the api service
        public async Task<HttpResponseMessage> PutTicketAsync(Ticket ticket, string ticketUrl = "tickets")
        {
            var uri = checkUrl(ticketUrl);

            using (var client = new HttpClient())
            {
                var x = await client.PutAsJsonAsync(uri, ticket).ConfigureAwait(false);

                return x;
            }
        }

        //updates a user in the database, using the api service
        public async Task<HttpResponseMessage> PutUserAsync(User user, string usersUrl = "users")
        {
            var uri = checkUrl(usersUrl);

            using (var client = new HttpClient())
            {
                var x = await client.PutAsJsonAsync(uri, user).ConfigureAwait(false);

                return x;
            }
        }

        //updates a knowledge entity in the database, using the api service
        public async Task<HttpResponseMessage> PutKnowledgeAsync(Knowledge knowledge, string knowledgeUrl = "knowledge")
        {
            var uri = checkUrl(knowledgeUrl);

            using (var client = new HttpClient())
            {
                var x = await client.PutAsJsonAsync(uri, knowledge).ConfigureAwait(false);

                return x;
            }
        }

        //updates an asset entity in the database, using the api service
        public async Task<HttpResponseMessage> PutAssetAsync(Asset asset, string assetUrl = "assets")
        {
            var uri = checkUrl(assetUrl);

            using (var client = new HttpClient())
            {
                var x = await client.PutAsJsonAsync(uri, asset).ConfigureAwait(false);

                return x;
            }
        }


        //-----------------POSTs-----------------//

        //adds a ticket to the database, using the api service
        public async Task<HttpResponseMessage> PostTicketAsync(Ticket ticket, string ticketUrl = "tickets")
        {
            var uri = checkUrl(ticketUrl);

            using (var client = new HttpClient())
            {

                var x = await client.PostAsJsonAsync(uri, ticket).ConfigureAwait(false);

                return x;
            }
        }

        //adds a user to the database, using the api service
        public async Task<HttpResponseMessage> PostUserAsync(User user, string usersUrl = "users")
        {
            var uri = checkUrl(usersUrl);

            using (var client = new HttpClient())
            {

                var x = await client.PostAsJsonAsync(uri, user).ConfigureAwait(false);

                return x;
            }
        }



        //adds a knowledge entity to the database, using the api service
        public async Task<HttpResponseMessage> PostKnowledgeAsync(Knowledge knowledge, string knowledgeUrl = "knowledge")
        {
            var uri = checkUrl(knowledgeUrl);

            using (var client = new HttpClient())
            {

                var x = await client.PostAsJsonAsync(uri, knowledge).ConfigureAwait(false);

                return x;
            }
        }

        //inserts an asset entity into the database, using the api service
        public async Task<HttpResponseMessage> PostAssetAsync(Asset asset, string assetUrl = "assets")
        {
            var uri = checkUrl(assetUrl);

            using (var client = new HttpClient())
            {
                var x = await client.PostAsJsonAsync(uri, asset).ConfigureAwait(false);

                return x;
            }
        }


        //-----------Helper Methods----------------//

        private string checkUrl(string url)
        {
             return _baseUrl + url.TrimStart('/');
        }
    }
}