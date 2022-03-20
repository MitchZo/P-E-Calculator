using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using KTC_Scraper.Models;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace KTC_Scraper.Controllers
{
    public class ScraperController : Controller
    {
        public IActionResult Index()
        {
            string url = "https://keeptradecut.com/dynasty-rankings#";
            string response = CallUrl(url).Result;
            List<Player> playerList = ParseHTMLIntoPlayers(response);
            saveToDatabase(playerList);
            return View(playerList);
        }

        [HttpPut]
        private void saveToDatabase(List<Player> playerList)
        {
            
        }

        private static List<Player> ParseHTMLIntoPlayers(string html)
        {
            HtmlDocument playersAsHTML = ParseHTML(html);
            List<Player> playerList = RetrievePlayers(playersAsHTML);
            return playerList;
        }

        private static List<Player> AddPlayersToList(string playersAsJSON)
        {
            List<Player> playerlist = new();
            return playerlist;
        }

        private static List<Player> RetrievePlayers(HtmlDocument playersAsHTML)
        {
            var htmlBody = playersAsHTML.DocumentNode.SelectSingleNode("//body");
            HtmlNodeCollection childNodes = htmlBody.ChildNodes;
            int nodeLength;
            int trailingExtraCharacters;
            int startOfPlayerArray;

            foreach (var node in childNodes)
            {
                if (node.InnerHtml.StartsWith("\n        var leagueType = "))
                {
                    nodeLength = node.InnerHtml.IndexOf("}]}}]");
                    trailingExtraCharacters = (nodeLength - 45);
                    startOfPlayerArray = node.InnerHtml.IndexOf('[');
                    string playersAsString = node.InnerHtml.Substring(startOfPlayerArray,trailingExtraCharacters);

                    return JsonConvert.DeserializeObject<List<Player>>(playersAsString);
                }
            }
            return null;
        }

        private static HtmlDocument ParseHTML(string input)
        {
            HtmlDocument html = new();
            html.LoadHtml(input);

            return html;
        }

        private static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(fullUrl);
            return await response;
        }

    }
}
