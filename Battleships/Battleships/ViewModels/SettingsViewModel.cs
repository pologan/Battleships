using Battleships.Models.GameModels;
using Battleships.Models.Ships;
using EnumsNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Battleships.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int Battleships { get; set; }

        public int Carriers { get; set; }

        public int Destroyers { get; set; }

        public int PatrolBoats { get; set; }

        public string ErrorLog
        {
            get
            {
                return string.Join(",\n", Errors.Select(e => e.AsString(EnumFormat.Description)));
            }
        }

        private List<SettingsErrorTypes> Errors { get; set; }

        public SettingsViewModel()
        {
            Title = "Settings";

            LoadData();
        }

        public void OnApppearing()
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
            if (Validate())
            {
                Settings.Width = Width;
                Settings.Height = Height;
                Settings.Battleships = Battleships;
                Settings.PatrolBoats = PatrolBoats;
                Settings.Carriers = Carriers;
                Settings.Destroyers = Destroyers;

                return true;
            }

            return false;
        }

        private bool Validate()
        {
            Errors.Clear();

            if (Width < 8)
                Errors.Add(SettingsErrorTypes.WidthTooSmall);

            if (Width > 12)
                Errors.Add(SettingsErrorTypes.WidthTooBig);

            if (Height < 8)
                Errors.Add(SettingsErrorTypes.HeigthTooSmall);

            if (Height > 12)
                Errors.Add(SettingsErrorTypes.HeigthTooBig);

            if (Errors.Count == 0)
            {
                int totalBoatLength = 0;
                int availableBoardSurface = (Width * Height) / 2;

                totalBoatLength += Battleships * (int)ShipType.Battleship;
                totalBoatLength += Carriers * (int)ShipType.Carrier;
                totalBoatLength += Destroyers * (int)ShipType.Destroyer;
                totalBoatLength += PatrolBoats * (int)ShipType.PatrolBoat;

                if(totalBoatLength > availableBoardSurface)
                {
                    Errors.Add(SettingsErrorTypes.TooManyShips);
                }
            }

            return Errors.Count == 0;
        }
    }
}
