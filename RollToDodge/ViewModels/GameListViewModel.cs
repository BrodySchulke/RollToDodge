//-----------------------------------------------------------------------
// <copyright file="GameListViewModel.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge.ViewModels
{
    using System.Collections.ObjectModel;
    using RollToDodge.Models;

    /// <summary>
    /// Interaction logic for GameListViewModel.cs
    /// Controls the data displayed by the GameListView
    /// </summary>
    public class GameListViewModel
    {
        /// <summary>
        /// Model used by the GameListViewModel
        /// </summary>
        private GameListModel model;

        /// <summary>
        /// Initializes a new instance of the GameListViewModel class
        /// </summary>
        /// <param name="model">Model to be used by the GameListViewModel</param>
        public GameListViewModel(GameListModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Gets the list of games stored by the application
        /// </summary>
        public ObservableCollection<string> GamesList
        {
            get
            {
                return this.model.GameList;
            }
        }
    }
}
