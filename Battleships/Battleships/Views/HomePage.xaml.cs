﻿using Battleships.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Battleships.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly HomeViewModel _vm;

        public HomePage()
        {
            InitializeComponent();

            _vm = new HomeViewModel();
            BindingContext = _vm;
        }
    }
}