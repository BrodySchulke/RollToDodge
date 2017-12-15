using System;
using System.Windows;
using System.IO;
using System.ComponentModel;
using System.Windows.Controls;

namespace RollToDodge.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool viewNewGameForm;

        public MainMenu()
        {
            InitializeComponent();
            viewNewGameForm = false;
        }

        //Controls the visibility of the New Game form for adding new games
        public bool ViewNewGameForm
        {
            get
            {
                return this.viewNewGameForm;
            }
            set
            {
                this.viewNewGameForm = value;
                NotifyPropertyChanged("ViewNewGameForm");
            }
        }

        //Handles the continue button logic for moving to a new page
        //to display all existing games
        private void Button_Click_Continue(Object sender, RoutedEventArgs e)
        {
            Page GamesListView = new GamesListView();
            this.NavigationService.Navigate(GamesListView);
        }
        
        //Handles the new game logic for displaying the form to create
        //a new game
        private void Button_Click_New_Game(Object sender, RoutedEventArgs e)
        {
            ViewNewGameForm = true;
        }

        //Handles save new game logic for creating a new game based on the 
        //name that the user provides
        private void Button_Click_Save_New_Game(Object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).AddGame(this.NewGameName.Text))
            {
                //Change this to display an error
                return;
            }
            this.NewGameName.Text = "";
        }

        //Handles the cancel new game button if a user decides they no longer
        //want to create a new game
        private void Button_Click_Cancel_New_Game(Object sender, RoutedEventArgs e)
        {
            this.ViewNewGameForm = false;
            this.NewGameName.Text = "";
        }

        //Notifies the view if a property changes so the view can be updated
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
