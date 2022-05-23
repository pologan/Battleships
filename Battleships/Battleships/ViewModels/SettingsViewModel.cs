using System.Collections.Generic;
using System.Linq;
using Battleships.Models.GameModels.Concrete;
using Battleships.Models.GameModels.Enums;
using Battleships.Models.Ships.Enums;
using Battleships.ViewModels.Base;
using EnumsNET;

namespace Battleships.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private const int MinSize = 8;
        private const int MaxSize = 12;

        public SettingsViewModel()
        {
            Title = "Settings";

            LoadData();
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Battleships { get; set; }

        public int Carriers { get; set; }

        public int Destroyers { get; set; }

        public int PatrolBoats { get; set; }

        public string ErrorLog
        {
            get { return string.Join(",\n", Errors.Select(e => e.AsString(EnumFormat.Description))); }
        }

        private List<SettingsErrorTypes> Errors { get; set; }

        public void OnAppearing()
        {
            LoadData();
        }

        private void LoadData()
        {
            Width = Settings.Width;
            Height = Settings.Height;
            Carriers = Settings.Carriers;
            Destroyers = Settings.Destroyers;
            Battleships = Settings.Battleships;
            PatrolBoats = Settings.PatrolBoats;

            Errors = new List<SettingsErrorTypes>();
        }

        public bool Save()
        {
            if (!Validate()) return false;

            Settings.Width = Width;
            Settings.Height = Height;
            Settings.Battleships = Battleships;
            Settings.PatrolBoats = PatrolBoats;
            Settings.Carriers = Carriers;
            Settings.Destroyers = Destroyers;

            return true;
        }

        private bool Validate()
        {
            Errors.Clear();

            if (Width < MinSize)
                Errors.Add(SettingsErrorTypes.WidthTooSmall);

            if (Width > MaxSize)
                Errors.Add(SettingsErrorTypes.WidthTooBig);

            if (Height < MinSize)
                Errors.Add(SettingsErrorTypes.HeightTooSmall);

            if (Height > MaxSize)
                Errors.Add(SettingsErrorTypes.HeightTooBig);

            if (Errors.Count != 0) return Errors.Count == 0;

            var totalBoatLength = 0;
            var availableBoardSurface = Width * Height / 2;

            totalBoatLength += Battleships * (int)ShipType.Battleship;
            totalBoatLength += Carriers * (int)ShipType.Carrier;
            totalBoatLength += Destroyers * (int)ShipType.Destroyer;
            totalBoatLength += PatrolBoats * (int)ShipType.PatrolBoat;

            if (totalBoatLength > availableBoardSurface) Errors.Add(SettingsErrorTypes.TooManyShips);

            return Errors.Count == 0;
        }
    }
}