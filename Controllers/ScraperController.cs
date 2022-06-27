using AngleSharp;
using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using KTC_Scraper.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
            string playersAsHTML = GetPlayersAsHTML(html);
            List<Player> playerList = RetrievePlayers(playersAsHTML);
            //return playerList;
            return new List<Player>();
        }

        public static string GetPlayersAsHTML(string html)
        {
            HtmlParser parser = new HtmlParser();
            var doc = parser.ParseDocument(html);
            foreach(var child in doc.Body.Children)
            {
                if(child.InnerHtml.Contains("playersArray"))
                    return child.InnerHtml;
            }
            return "error parsing HTML";
        }

        private static List<Player> AddPlayersToList(string playersAsJSON)
        {
            List<Player> playerlist = new();
            return playerlist;
        }

        public static List<Player> RetrievePlayers(string playersAsHTML)
        {

            //evaluate character by character
            //start with bracket count at 0 and playercount at 0
            //each character increases the playerObjectEndIndex by 1
            //when you hit a {, bracket count increases
            //if playercount is 0 and bracket count would increase to 1, save playerObjectEndIndex
            //when you hit a }, bracket count decreases
            //if player count is > 0, and bracket count is 0, save character position
            //remove player from playersAsHtml and set playercount back to 0

            List<Player> playerList = new List<Player>();
            bool arrayOpen = true;
            int stringLocation = 0;
            int playerObjectStartIndex = 0;
            int playerObjectEndIndex = 0;
            Stack<char> parsingStack = new Stack<char>();

            foreach (char character in playersAsHTML)
            {
                while (arrayOpen)
                {
                    stringLocation++;
                    if (character == '[' || character == '{')
                    {
                        if(!parsingStack.Contains('{'))
                        {
                            playerObjectStartIndex = stringLocation;
                        }
                        parsingStack.Push(character);
                    }
                    if (character == ']' || character == '}')
                    {
                        parsingStack.Pop();
                        if(parsingStack.Count == 1)
                        {
                            playerObjectEndIndex = stringLocation;
                        }
                        if (parsingStack.Count == 0)
                        {
                            arrayOpen = false;
                        }
                    }
                    break;
                }
                if (playerObjectEndIndex != 0)
                {
                    Player player = new Player();
                    string playerAsHTML = playersAsHTML.Substring(playerObjectStartIndex - 1, (playerObjectEndIndex - playerObjectStartIndex)+1);
                    player = JsonConvert.DeserializeObject<Player>(playerAsHTML);
                    playerList.Add(player);
                    playerObjectEndIndex = 0;
                    playerObjectStartIndex = 0;
                }
            }
                return playerList;
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
