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
    public partial class PokemonView : ContentPage
    {
        PokemonViewModel vm;

        public PokemonView()
        {
            InitializeComponent();

            vm = new PokemonViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await vm.LoadPokedex();

            await Task.Delay(8000);

            var pikachu = vm.PokemonList.Where(x => x.name.english == "Pikachu").FirstOrDefault();
            collectionView.ScrollTo(pikachu, position: ScrollToPosition.Center, animate: true);
        }


    }
}