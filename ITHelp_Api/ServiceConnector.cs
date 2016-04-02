using ITHelp_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ITHelp_Api
{
    public class ServiceConnector
    {
        private readonly string _baseUrl = "http://ithelpdata.azurewebsites.net/";

        //Get all assets from the Repository Service
        public List<Ticket> GetTicketsAsync(string productUrl = "api/Tickets")
        {
            if (productUrl.StartsWith("/"))
            {
                productUrl = productUrl.Remove(0);
            }

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
        public List<Asset> GetAssetsAsync(string assettUrl = "api/Assets")
        {
            if (assettUrl.StartsWith("/"))
            {
                assettUrl = assettUrl.Remove(0);
            }

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
    }
}