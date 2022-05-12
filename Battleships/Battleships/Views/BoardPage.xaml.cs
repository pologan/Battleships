using Battleships.Extensions;
using Battleships.Models.BoardModels;
using Battleships.Models.GameModels;
using Battleships.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Battleships.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoardPage : ContentPage
    {
        private readonly BoardViewModel _vm;
        public BoardPage()
        {
            InitializeComponent();

            _vm = new BoardViewModel();
            BindingContext = _vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _vm.OnAppearing();

            _vm.InitBoard(_vm.Game.Player1.Board, gridA);
            _vm.InitBoard(_vm.Game.Player2.Board, gridB);
        }

        

        private void Randomize_Clicked(object sender, EventArgs e)
        {
            _vm.OnAppearing();

            gridA.Clear();
            gridB.Clear();

            _vm.InitBoard(_vm.Game.Player1.Board, gridA);
            _vm.InitBoard(_vm.Game.Player2.Board, gridB);
        }
    }
}