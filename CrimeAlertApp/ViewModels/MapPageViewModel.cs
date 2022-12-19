using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrimeAlertApp.ViewModels
{
    public class MapPageViewModel
    {
        public MapPageViewModel()
        {
        }

        public class CrimeLocations
        {
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }

        internal async Task<List<CrimeLocations>> LoadCrimes()
        {
            //Call the api to get the crime locations nearby

            //Hardcoded data
            List<CrimeLocations> crimelocations = new List<CrimeLocations>
            {
                new CrimeLocations { Latitude = "51.583011", Longitude = "-2.985682" },
                new CrimeLocations { Latitude = "51.584557", Longitude = "-2.988472" },
                new CrimeLocations { Latitude = "51.585391", Longitude = "-2.979388" },
                new CrimeLocations { Latitude = "51.587951", Longitude = "-2.985542" },
            };
            return crimelocations;
        }
    }
}
