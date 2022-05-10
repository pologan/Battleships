using Battleships.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Battleships.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}