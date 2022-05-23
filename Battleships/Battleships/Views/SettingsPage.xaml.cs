using System;
using Battleships.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Battleships.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private readonly SettingsViewModel _vm;

        public SettingsPage()
        {
            InitializeComponent();

            _vm = new SettingsViewModel();
            BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _vm.OnAppearing();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            if (_vm.Save())
                DisplayAlert("Saved", "Settings saved", "Ok");
            else
                DisplayAlert("Errors occurred", _vm.ErrorLog, "Ok");
        }
    }
}