using System;
using System.Collections.Generic;
using System.Text;

namespace App.ViewModels
{
    public class PlayingTimeViewModel : BaseViewModel
    {
        public IList<string> PlayingTimeOptions { get; set; }

        public PlayingTimeViewModel()
        {
            PlayingTimeOptions = new List<string>();
            PlayingTimeOptions.Add("Até 30 minutos");
            PlayingTimeOptions.Add("Entre 30 e 1 hora");
            PlayingTimeOptions.Add("Entre 1 hora e 2 horas");
            PlayingTimeOptions.Add("Mais de 2 horas");
        }
    }
}
