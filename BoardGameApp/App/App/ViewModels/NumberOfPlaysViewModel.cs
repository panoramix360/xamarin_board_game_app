using System;
using System.Collections.Generic;
using System.Text;

namespace App.ViewModels
{
    public class NumberOfPlaysViewModel : BaseViewModel
    {
        public IList<string> NumberOfPlaysOptions { get; set; }

        public NumberOfPlaysViewModel()
        {
            NumberOfPlaysOptions = new List<string>();
            NumberOfPlaysOptions.Add("Jogos menos jogados");
            NumberOfPlaysOptions.Add("Jogos mais jogados");
        }
    }
}
