using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Battleships.Models.GameModels
{
    public static class Settings
    {
        public static int Width { 
            get
            {
                string val = SecureStorage.GetAsync("WidthSettings").Result;
                if (string.IsNullOrEmpty(val))
                {
                    Width = 10;
                    return 10;
                }
                return int.Parse(val);
            }
            set
            {
                SecureStorage.SetAsync("WidthSettings", value.ToString());
            }
        }
        
        public static int Height
        {
            get
            {
                string val = SecureStorage.GetAsync("HeightSettings").Result;
                if (string.IsNullOrEmpty(val))
                {
                    Height = 10;
                    return 1;
                }
                return int.Parse(val);
            }
            set
            {
                SecureStorage.SetAsync("HeightSettings", value.ToString());
            }
        }

        public static int Battleships
        {
            get
            {
                string val = SecureStorage.GetAsync("BattleshipsSettings").Result;
                if (string.IsNullOrEmpty(val))
                {
                    Battleships = 1;
                    return 1;
                }
                return int.Parse(val);
            }
            set
            {
                SecureStorage.SetAsync("BattleshipsSettings", value.ToString());
            }
        }

        public static int Carriers
        {
            get
            {
                string val = SecureStorage.GetAsync("CarriersSettings").Result;
                if (string.IsNullOrEmpty(val))
                {
                    Carriers = 1;
                    return 1;
                }
                return int.Parse(val);
            }
            set
            {
                SecureStorage.SetAsync("CarriersSettings", value.ToString());
            }
        }

        public static int Destroyers
        {
            get
            {
                string val = SecureStorage.GetAsync("DestroyersSettings").Result;
                if (string.IsNullOrEmpty(val))
                {
                    Destroyers = 2;
                    return 2;
                }
                return int.Parse(val);
            }
            set
            {
                SecureStorage.SetAsync("DestroyersSettings", value.ToString());
            }
        }

        public static int PatrolBoats
        {
            get
            {
                string val = SecureStorage.GetAsync("PatrolBoatsSettings").Result;
                if (string.IsNullOrEmpty(val))
                {
                    PatrolBoats = 1;
                    return 1;
                }
                return int.Parse(val);
            }
            set
            {
                SecureStorage.SetAsync("PatrolBoatsSettings", value.ToString());
            }
        }


    }
}
