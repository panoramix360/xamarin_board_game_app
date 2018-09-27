using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.EntitiesDTO
{
    public class BoardGameDetailDTO
    {
        public int gameId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string thumbnail { get; set; }
        public int minPlayers { get; set; }
        public int maxPlayers { get; set; }
        public int playingTime { get; set; }
        public List<string> mechanics { get; set; }
        public bool isExpansion { get; set; }
        public int yearPublished { get; set; }
        public double bggRating { get; set; }
        public double averageRating { get; set; }
        public int rank { get; set; }
        public List<string> designers { get; set; }
        public List<string> publishers { get; set; }
        public List<string> artists { get; set; }
        public List<PlayerPollResult> playerPollResults { get; set; }
        public List<Expansion> expansions { get; set; }
    }

    public class PlayerPollResult
    {
        public int numPlayers { get; set; }
        public int best { get; set; }
        public int recommended { get; set; }
        public int notRecommended { get; set; }
        public bool numPlayersIsAndHigher { get; set; }
    }

    public class Expansion
    {
        public string name { get; set; }
        public int gameId { get; set; }
    }
}
