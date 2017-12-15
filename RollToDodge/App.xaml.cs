using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace RollToDodge
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string AppDirectory = "C:/ProgramData/RollToDodge";
        public const string GameListFile = AppDirectory + "/GameList.txt";
        private List<string> gamesList;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CheckDirectory();
            CheckGameListFile();
            PopulateGamesList();
            CheckGamesDirectories();
            Window main = new RollToDodge.Views.MainWindow();
            main.Show();
        }

        //Adds a game to the list of games if the game does not already exist,
        //and creats the corresponding folder for the given game
        public bool AddGame(string gameName)
        {
            if(!this.gamesList.Contains(gameName))
            {
                File.AppendAllText(App.GameListFile, String.Format("\n{0}", gameName));
                Directory.CreateDirectory(App.AppDirectory + String.Format("/{0}", gameName));
                return true;
            }
            return false;
        }

        //Makes sure the parent app directory exists and adds if it doesn't
        private void CheckDirectory()
        {
            if(!Directory.Exists(AppDirectory))
            {
                Directory.CreateDirectory(AppDirectory);
            }
        }

        //Makes sure the file containing the list of games exists and adds it
        //if it does not
        private void CheckGameListFile()
        {
            if(!File.Exists(GameListFile))
            {
                File.Create(GameListFile);
            }
        }

        //Makes sure the directories corresponding to the existing games exist
        //and creates them if they do not
        private void CheckGamesDirectories()
        {
            List<string> gameDirectories = new List<string>(Directory.GetDirectories(AppDirectory));
            foreach (string game in gamesList)
            {
                if (!gameDirectories.Contains(game))
                {
                    Directory.CreateDirectory(AppDirectory + String.Format("/{0}", game));
                }
            }
        }

        //Populates the list of current games for the applicatoin to reference
        private void PopulateGamesList()
        {
            this.gamesList = new List<string>();
            string s;
            using (StreamReader reader = new StreamReader(GameListFile))
            {
                while ((s = reader.ReadLine()) != null)
                {
                    gamesList.Add(s);
                }
            }
        }
    }
}
