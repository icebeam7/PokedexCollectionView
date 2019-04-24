using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PokedexCollectionView.ViewModels;
using PokedexCollectionView.Models;

namespace PokedexCollectionView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonViewSelectGrid : ContentPage
    {
        PokemonViewModel vm;

        public PokemonViewSelectGrid()
        {
            InitializeComponent();

            vm = new PokemonViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await vm.LoadPokedex();

            //var pikachu = vm.PokemonList.Where(x => x.name.english == "Pikachu").FirstOrDefault();
            //collectionView.ScrollTo(pikachu);
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pokemon = e.CurrentSelection.First() as Pokemon;

            var page = new PokemonPopUpPage(pokemon);
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(page);
        }
    }
}