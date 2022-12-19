using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Plugin.ExternalMaps;
using Xamarin.Essentials;
using CrimeAlertApp.ViewModels;
using Xamarin.Forms.Maps;
using PoliceUk;
using PoliceUk.Entities.StreetLevel;

namespace CrimeAlertApp
{
    public partial class MainPage : ContentPage
    {
        MapPageViewModel mapPageViewModel;

        //Xamarin.Forms.Maps.Map map = new Xamarin.Forms.Maps.Map
        //{
        //    IsShowingUser = true
        //};

        public MainPage()
        {
            //var map = new Xamarin.Forms.Maps.Map(MapSpan.FromCenterAndRadius(new Position(51.48130282836856, -3.178214661504232), Distance.FromMiles(0.3)));

            InitializeComponent();
            GetUserPosition();

            //Content = map;

            BindingContext = mapPageViewModel = new MapPageViewModel();
        }

        public async void GetUserPosition()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                //Position position = new Position(51.48130282836856, -3.178214661504232);
                //MapSpan mapSpan2 = new MapSpan(position, 0.01, 0.01);
                //Xamarin.Forms.Maps.Map map = new Xamarin.Forms.Maps.Map(mapSpan2);

                if (location != null)
                {
                    Position Posi = new Position(location.Latitude, location.Longitude);
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(Posi, Distance.FromKilometers(.444));
                    map.MoveToRegion(mapSpan);
                }
            }
            catch (Exception Ex)
            {
                //Do nothing
            }
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var policeClient = new PoliceUkClient();
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);

            Geoposition chawton = new Geoposition(location.Latitude, location.Longitude);
            StreetLevelCrimeResults results = policeClient.StreetLevelCrimes(chawton);

            if (location != null)
            {
                foreach (Crime crime in results.Crimes)
                {
                    if (crime.Category == "public-order")
                    {
                        Pin publicorderPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(publicorderPins);
                    }
                    if (crime.Category == "anti-social-behaviour")
                    {
                        Pin antisocialbehaviourPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(antisocialbehaviourPins);
                    }
                    if (crime.Category == "bicycle-theft")
                    {
                        Pin bicycletheftPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(bicycletheftPins);
                    }
                    if (crime.Category == "burglary")
                    {
                        Pin burglaryPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(burglaryPins);
                    }
                    if (crime.Category == "criminal-damage-arson")
                    {
                        Pin criminaldamagearsonPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(criminaldamagearsonPins);
                    }
                    if (crime.Category == "drugs")
                    {
                        Pin drugsPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(drugsPins);
                    }
                    if (crime.Category == "other-theft")
                    {
                        Pin othertheftPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(othertheftPins);
                    }
                    if (crime.Category == "possession-of-weapons")
                    {
                        Pin possessionofweaponsPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(possessionofweaponsPins);
                    }
                    if (crime.Category == "public-order")
                    {
                        Pin publicorderPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(publicorderPins);
                    }
                    if (crime.Category == "robbery")
                    {
                        Pin robberyPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(robberyPins);
                    }
                    if (crime.Category == "shoplifting")
                    {
                        Pin shopliftingPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(shopliftingPins);
                    }
                    if (crime.Category == "theft-from-the-person")
                    {
                        Pin theftfromthepersonPins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(theftfromthepersonPins);
                    }
                    if (crime.Category == "vehicle-crime")
                    {
                        Pin vehiclecrimePins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(vehiclecrimePins);
                    }
                    if (crime.Category == "violent-crime")
                    {
                        Pin violentcrimePins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(violentcrimePins);
                    }
                    if (crime.Category == "other-crime")
                    {
                        Pin othercrimePins = new Pin()
                        {
                            Label = crime.Category,
                            Address = "Location: " + crime.Location.Street.Name,
                            Type = PinType.Place,
                            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                        };
                        map.Pins.Add(othercrimePins);
                    }

                    //if (location != null)
                    //{
                    //    foreach (Crime crime in results.Crimes)
                    //    {
                    //        Pin allcrimesPin = new Pin()
                    //        {
                    //            Label = crime.Category,
                    //            Address = "Location: " + crime.Location.Street.Name,
                    //            Type = PinType.Place,
                    //            //Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("CarPins.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "CarPins.png", WidthRequest = 30, HeightRequest = 30 }),
                    //            Position = new Position(Convert.ToDouble(crime.Location.Latitude), Convert.ToDouble(crime.Location.Longitude)),

                    //        };
                    //        map.Pins.Add(allcrimesPin);
                    //    }
                    //}
                }
            }
        }
    }
}