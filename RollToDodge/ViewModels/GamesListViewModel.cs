using System.Collections.ObjectModel;
using RollToDodge.Models;

namespace RollToDodge.ViewModels
{ 
    public class GamesListViewModel
    {
        private GamesListModel model;
        public GamesListViewModel(GamesListModel model)
        {
            this.model = model;
        }

        //Represent the list of games stored by the application
        public ObservableCollection<string> GamesList
        {
            get
            {
                return this.model.GameList;
            }
        }

    }
}
