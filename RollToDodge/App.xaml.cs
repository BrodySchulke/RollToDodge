// <copyright file="App.xaml.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using RollToDodge.Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The directory where everything the application stores is saved
        /// </summary>
        public const string AppDirectory = "C:/ProgramData/RollToDodge";

        /// <summary>
        /// The file where the list of games the application has is stored
        /// </summary>
        public const string GameListFile = AppDirectory + "/GameList.txt";

        /// <summary>
        /// List of games stored by the application
        /// </summary>
        private List<string> gamesList;

        /// <summary>
        /// Adds a new game to the list of games and creates the game directory
        /// </summary>
        /// <param name="gameName">Name of the new game</param>
        /// <returns>Result of game addition - false if the game already exists</returns>
        public bool AddGame(string gameName)
        {
            if (!this.gamesList.Contains(gameName))
            {
                File.AppendAllText(GameListFile, string.Format("{0}\r\n", gameName));
                Directory.CreateDirectory(AppDirectory + string.Format("/{0}", gameName));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Initializes the application upon startup
        /// </summary>
        /// <param name="sender">Sender on app startup</param>
        /// <param name="e">Arguments passed on startup</param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.CheckApplicationDirectory();
            this.CheckGameListFile();
            this.PopulateGamesList();
            this.CheckGamesDirectories();
            Window main = new MainWindow();
            main.Show();
        }

        /// <summary>
        /// Creates the application directory if it doesn't exist
        /// </summary>
        private void CheckApplicationDirectory()
        {
            if (!Directory.Exists(AppDirectory))
            {
                Directory.CreateDirectory(AppDirectory);
            }
        }

        /// <summary>
        /// Creates the game list file if it doesn't exist
        /// </summary>
        private void CheckGameListFile()
        {
            if (!File.Exists(GameListFile))
            {
                File.Create(GameListFile).Dispose();
            }
        }

        /// <summary>
        /// Creates the game-specific directories if they don't exist based on the game list file
        /// </summary>
        private void CheckGamesDirectories()
        {
            List<string> gameDirectories = new List<string>(Directory.GetDirectories(AppDirectory));
            foreach (string game in this.gamesList)
            {
                if (!gameDirectories.Contains(game))
                {
                    Directory.CreateDirectory(AppDirectory + string.Format("/{0}", game));
                }
            }
        }

        /// <summary>
        /// Populates the list of games from the game list file
        /// </summary>
        private void PopulateGamesList()
        {
            this.gamesList = new List<string>();
            string s;
            using (StreamReader reader = new StreamReader(GameListFile))
            {
                while ((s = reader.ReadLine()) != null)
                {
                        this.gamesList.Add(s);
                }
            }
        }
    }
}
