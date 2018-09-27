using DomainModel.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class FilterSelection
    {
        public int NumberOfPlayers { get; set; }
        public PlayingTimeEnum PlayingTime { get; set; }
        public NumberOfPlaysEnum NumberOfPlays { get; set; }
    }
}
