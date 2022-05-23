using Xamarin.Essentials;

namespace Battleships.Models.GameModels.Concrete
{
    public static class Settings
    {
        private static int _width;

        private static int _height;

        private static int _battleships;

        private static int _carriers;

        private static int _destroyers;

        private static int _patrolBoats;

        public static int Width
        {
            get => _width;
            set
            {
                _width = value;
                SecureStorage.SetAsync("WidthSettings", value.ToString());
            }
        }

        public static int Height
        {
            get => _height;
            set
            {
                _height = value;
                SecureStorage.SetAsync("HeightSettings", value.ToString());
            }
        }

        public static int Battleships
        {
            get => _battleships;
            set
            {
                _battleships = value;
                SecureStorage.SetAsync("BattleshipsSettings", value.ToString());
            }
        }

        public static int Carriers
        {
            get => _carriers;
            set
            {
                _carriers = value;
                SecureStorage.SetAsync("CarriersSettings", value.ToString());
            }
        }

        public static int Destroyers
        {
            get => _destroyers;
            set
            {
                _destroyers = value;
                SecureStorage.SetAsync("DestroyersSettings", value.ToString());
            }
        }

        public static int PatrolBoats
        {
            get => _patrolBoats;
            set
            {
                _patrolBoats = value;
                SecureStorage.SetAsync("PatrolBoatsSettings", value.ToString());
            }
        }

        public static async void Init()
        {
            var val = await SecureStorage.GetAsync("WidthSettings");
            Width = string.IsNullOrEmpty(val) ? 1 : int.Parse(val);

            val = await SecureStorage.GetAsync("HeightSettings");
            Height = string.IsNullOrEmpty(val) ? 1 : int.Parse(val);

            val = await SecureStorage.GetAsync("BattleshipsSettings");
            Battleships = string.IsNullOrEmpty(val) ? 1 : int.Parse(val);

            val = await SecureStorage.GetAsync("CarriersSettings");
            Carriers = string.IsNullOrEmpty(val) ? 1 : int.Parse(val);

            val = await SecureStorage.GetAsync("DestroyersSettings");
            Destroyers = string.IsNullOrEmpty(val) ? 1 : int.Parse(val);

            val = await SecureStorage.GetAsync("PatrolBoatsSettings");
            PatrolBoats = string.IsNullOrEmpty(val) ? 1 : int.Parse(val);
        }
    }
}