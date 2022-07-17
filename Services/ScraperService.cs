using AngleSharp.Html.Parser;
using KTC_Scraper.Contexts;
using KTC_Scraper.Interfaces;
using KTC_Scraper.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KTC_Scraper
{
    public class ScraperService : IScraperService
    {
        private readonly IKtcContext _context;
        private readonly IConnectionString _connection;

        public ScraperService(KtcContext context)
        {
            _context = context;
        }

        public  List<Player> GetCurrentPlayers()
        {
            string url = "https://keeptradecut.com/dynasty-rankings#";
            string response = CallUrl(url).Result;
            List<Player> playerList = ParseHTMLIntoPlayers(response);
             RefreshPlayers(playerList);
            return playerList;
        }
        private static List<Player> ParseHTMLIntoPlayers(string html)
        {
            string playersAsHTML = GetPlayersAsHTML(html);
            List<Player> playerList = RetrievePlayers(playersAsHTML);
            return playerList;
        }

        private static string GetPlayersAsHTML(string html)
        {
            HtmlParser parser = new HtmlParser();
            var doc = parser.ParseDocument(html);
            foreach (var child in doc.Body.Children)
            {
                if (child.InnerHtml.Contains("playersArray"))
                    return child.InnerHtml;
            }
            return "error parsing HTML";
        }

        public static List<Player> RetrievePlayers(string playersAsHTML)
        {
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
                        if (!parsingStack.Contains('{'))
                        {
                            playerObjectStartIndex = stringLocation;
                        }
                        parsingStack.Push(character);
                    }
                    if (character == ']' || character == '}')
                    {
                        parsingStack.Pop();
                        if (parsingStack.Count == 1)
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
                    string playerAsHTML = playersAsHTML.Substring(playerObjectStartIndex - 1, (playerObjectEndIndex - playerObjectStartIndex) + 1);
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

        private void RefreshPlayers(List<Player> players)
        {
            using (_context)
            {
                Player foundPlayer;
                foreach(Player player in players)
                {
                    foundPlayer = _context.Players.SingleOrDefault(x => x.slug == player.slug);
                    if (foundPlayer == null)
                    {
                        _context.Players.Add(player);
                    }
                    else
                    {
                        foundPlayer = player;
                    }
                }
                _context.SaveChanges();
            }
        }
    }
}
