using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Battleships.Models.GameModels
{
    public static class Settings
    {
        private static int _width;

        public static int Width {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                SecureStorage.SetAsync("WidthSettings", value.ToString());
            }
        }

        private static int _height;

        public static int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                SecureStorage.SetAsync("HeightSettings", value.ToString());
            }
        }

        private static int _battleships;

        public static int Battleships
        {
            get
            {
                return _battleships;
            }
            set
            {
                _battleships = value;
                SecureStorage.SetAsync("BattleshipsSettings", value.ToString());
            }
        }

        private static int _carriers;

        public static int Carriers
        {
            get
            {
                return _carriers;
            }
            set
            {
                _carriers = value;
                SecureStorage.SetAsync("CarriersSettings", value.ToString());
            }
        }

        private static int _destroyers;

        public static int Destroyers
        {
            get
            {
                return _destroyers;
            }
            set
            {
                _destroyers = value;
                SecureStorage.SetAsync("DestroyersSettings", value.ToString());
            }
        }

        private static int _patrolBoats;

        public static int PatrolBoats
        {
            get
            {
                return _patrolBoats;
            }
            set
            {
                _patrolBoats = value;
                SecureStorage.SetAsync("PatrolBoatsSettings", value.ToString());
            }
        }

        public static async void Init()
        {
            string val;

            val = await SecureStorage.GetAsync("WidthSettings");
            if (string.IsNullOrEmpty(val))
            {
                Width = 1;
            }
            else
            {
                Width = int.Parse(val);
            }

            val = await SecureStorage.GetAsync("HeightSettings");
            if (string.IsNullOrEmpty(val))
            {
                Height = 1;
            }
            else
            {
                Height = int.Parse(val);
            }

            val = await SecureStorage.GetAsync("BattleshipsSettings");
            if (string.IsNullOrEmpty(val))
            {
                Battleships = 1;
            }
            else
            {
                Battleships = int.Parse(val);
            }

            val = await SecureStorage.GetAsync("CarriersSettings");
            if (string.IsNullOrEmpty(val))
            {
                Carriers = 1;
            }
            else
            {
                Carriers = int.Parse(val);
            }

            val = await SecureStorage.GetAsync("DestroyersSettings");
            if (string.IsNullOrEmpty(val))
            {
                Destroyers = 1;
            }
            else
            {
                Destroyers = int.Parse(val);
            }

            val = await SecureStorage.GetAsync("PatrolBoatsSettings");
            if (string.IsNullOrEmpty(val))
            {
                PatrolBoats = 1;
            }
            else
            {
                PatrolBoats = int.Parse(val);
            }

        }
    }
}
