﻿using ITHelp_Models;
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
        private readonly string _baseUrl = "http://ithelpapi.azurewebsites.net/api/";
        //private readonly string _baseUrl = "http://localhost:50305/api/";
        //Get all assets from the Repository Service
        public List<Ticket> GetTicketsAsync(string productUrl = "tickets")
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
        public Ticket GetTicketByIdAsync(int id)
        {
            var productUrl = "tickets/" + id;

            checkUrl(productUrl);

            var uri = _baseUrl + productUrl;

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

        //Get all assets from the Repository Service
        public List<Ticket> GetTicketsByUser(string username)
        {
            var productUrl = "tickets?username=" + username;

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
        public List<Asset> GetAssetsAsync(string assettUrl = "assets")
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
        public List<User> GetUsersAsync(string UsersUrl = "assets")
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

        //Get all assets from the Repository Service
        public async Task<HttpResponseMessage> PostUserAsync(User user, string usersUrl = "users")
        {
            checkUrl(usersUrl);

            var uri = _baseUrl + usersUrl;

            using (var client = new HttpClient())
            {

                var x = await client.PostAsJsonAsync(uri, user).ConfigureAwait(false);

                return x;
            }
        }

        private string checkUrl(string url)
        {
            if (url.StartsWith("/"))
            {
                return url = url.Remove(0);
            }

            return url;
        }
    }
}