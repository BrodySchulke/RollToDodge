using System;
using System.Collections.ObjectModel;
using System.IO;

namespace RollToDodge.Models
{
    public class GamesListModel
    {

        private ObservableCollection<string> gameList;
        public GamesListModel()
        {
            gameList = new ObservableCollection<string>();
            string s;
            using (StreamReader sr = new StreamReader(App.GameListFile))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    gameList.Add(s);
                }
            }
        }

        //Adds a new game to the game list and adds the game to the file
        //containing the list of games
        public void AddGame(string game)
        {
            gameList.Add(game);
            using (StreamWriter w = File.AppendText(App.GameListFile))
            {
                w.WriteLine(game);
            }
        }

        //Representsthe list of games that the application has stored
        public ObservableCollection<string> GameList
        {
            get
            {
                return this.gameList;
            }
        }

    }


    
}
