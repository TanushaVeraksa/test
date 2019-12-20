using System;
using System.Text;


namespace GitHubAutomation.Models
{
    public class Location
    {
        public string ArrivalPlace { get; set; }


        public Location(string arrivalPlace)
        {
            ArrivalPlace = arrivalPlace;
        }

    }
}
