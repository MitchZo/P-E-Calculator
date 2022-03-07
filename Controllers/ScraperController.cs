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

namespace KTC_Scraper.Controllers
{
    public class ScraperController : Controller
    {
        public IActionResult Index()
        {
            string url = "https://keeptradecut.com/dynasty-rankings#";
            string response = CallUrl(url).Result;
            List<Player> playerList = ParseHTMLIntoPlayers(response);
            return View(playerList);
        }

        private static List<Player> ParseHTMLIntoPlayers(string html)
        {
            List<Player> playerList = new List<Player>();

            HtmlDocument playersAsHTML = ParseHTML(html);
            playerList = RetrievePlayers(playersAsHTML);
            return playerList;
        }

        private static List<Player> AddPlayersToList(string playersAsJSON)
        {
            Player player = new Player();
            List<Player> playerlist = new List<Player>();
            return playerlist;
        }

        private static List<Player> RetrievePlayers(HtmlDocument playersAsHTML)
        {
            var htmlBody = playersAsHTML.DocumentNode.SelectSingleNode("//body");
            HtmlNodeCollection childNodes = htmlBody.ChildNodes;
            int nodeLength = 0;

            foreach (var node in childNodes)
            {
                if (node.InnerHtml.StartsWith("\n        var leagueType = "))
                {
                    nodeLength = node.InnerHtml.IndexOf("}]}}]");
                    string playersAsString = node.InnerHtml.Substring(node.InnerHtml.IndexOf('['),(nodeLength-45));

                    return JsonConvert.DeserializeObject<List<Player>>(playersAsString);
                }
            }
            return null;
        }

        private static HtmlDocument ParseHTML(string input)
        {
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(input);

            return html;
        }

        private static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(fullUrl);
            return await response;
        }

    }
}
