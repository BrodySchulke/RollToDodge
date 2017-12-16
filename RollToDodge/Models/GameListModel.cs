//-----------------------------------------------------------------------
// <copyright file="GameListModel.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge.Models
{
    using System.Collections.ObjectModel;
    using System.IO;

    /// <summary>
    /// Interaction logic for GameListModel.cs
    /// Represents the data used by GameListViewModel
    /// </summary>
    public class GameListModel
    {
        /// <summary>
        /// List of games that the application has stored
        /// </summary>
        private ObservableCollection<string> gameList;

        /// <summary>
        /// Initializes a new instance of the GameListModel class
        /// </summary>
        public GameListModel()
        {
            this.gameList = new ObservableCollection<string>();
            string s;
            using (StreamReader sr = new StreamReader(App.GameListFile))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    this.gameList.Add(s);
                }
            }
        }

        /// <summary>
        /// Gets the list of games stored by the application
        /// </summary>
        public ObservableCollection<string> GameList
        {
            get
            {
                return this.gameList;
            }
        }

        /// <summary>
        /// Adds a new game to the list of games stored by the application
        /// </summary>
        /// <param name="game">Name of the new game></param>
        public void AddGame(string game)
        {
            this.gameList.Add(game);
            using (StreamWriter w = File.AppendText(App.GameListFile))
            {
                w.WriteLine(game);
            }
        }
    }
}
