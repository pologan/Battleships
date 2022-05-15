using Battleships.ViewModels;
using Battleships.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Battleships
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(BoardPage), typeof(BoardPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }

    }
}
