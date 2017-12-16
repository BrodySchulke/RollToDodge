//-----------------------------------------------------------------------
// <copyright file="GameModel.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge.Models
{
    using System.Collections.ObjectModel;
    using RollToDodge.Classes;

    /// <summary>
    /// Interaction logic for GameModel.cs
    /// Controls the data to be leveraged by the GameViewModel
    /// </summary>
    public class GameModel
    {
        /// <summary>
        /// List of all of the characters in the game that real-world players control
        /// </summary>
        private ObservableCollection<Character> characterList;

        /// <summary>
        /// Initializes a new instance of the GameModel class
        /// </summary>
        /// <param name="gameName">Name of the game that is being played</param>
        public GameModel(string gameName)
        {
            // deserialize files
            this.characterList = new ObservableCollection<Character>();

            // string s;          
        }
    }
}
