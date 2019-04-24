using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using PokedexCollectionView.Models;
using PokedexCollectionView.Services;
using Xamarin.Forms;

namespace PokedexCollectionView.ViewModels
{
    public class PokemonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Pokemon> Pokedex;

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Pokemon> pokemons;

        public ObservableCollection<Pokemon> PokemonList
        {
            get { return pokemons; }
            set { pokemons = value; OnPropertyChanged(); }
        }

        public async Task LoadPokedex()
        {
            IsLoading = true;

            Pokedex = await PokemonApiService.GetPokemon();
            PokemonList = new ObservableCollection<Pokemon>(Pokedex);

            IsLoading = false;
        }
    }
}
