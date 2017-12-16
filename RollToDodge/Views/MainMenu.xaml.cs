//-----------------------------------------------------------------------
// <copyright file="MainMenu.xaml.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge.Views
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// Page that represents the MainMenu options - Continue or New Game
    /// </summary>
    public partial class MainMenu : Page, INotifyPropertyChanged
    {
        /// <summary>
        /// Boolean that controls visibility of the form for creating a new game
        /// </summary>
        private bool viewNewGameForm;

        /// <summary>
        /// Initializes a new instance of the MainMenu class
        /// </summary>
        public MainMenu()
        {
            this.InitializeComponent();
            this.viewNewGameForm = false;
        }

        /// <summary>
        /// EventHander for notifying the MainMenu page when a property changes
        /// for updating the view
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the new game form
        /// is visible
        /// </summary>
        public bool ViewNewGameForm
        {
            get
            {
                return this.viewNewGameForm;
            }

            set
            {
                this.viewNewGameForm = value;
                this.NotifyPropertyChanged("ViewNewGameForm");
            }
        }

        /// <summary>
        /// Button logic for when a user decides to continue an existing game.
        /// Loads the GamesListView page to list existing games the application has stored.
        /// </summary>
        /// <param name="sender">Continue button</param>
        /// <param name="e">Data sent</param>
        private void Button_Click_Continue(object sender, RoutedEventArgs e)
        {
            Page gamesListView = new GameListView();
            this.NavigationService.Navigate(gamesListView);
        }
        
        /// <summary>
        /// Button logic for when a user decides to create a new game.
        /// Makes the new game form visible
        /// </summary>
        /// <param name="sender">New Game button</param>
        /// <param name="e">Data sent</param>
        private void Button_Click_New_Game(object sender, RoutedEventArgs e)
        {
            this.ViewNewGameForm = true;
        }

        /// <summary>
        /// Button logic for when a user decides to save their New Game and have it created
        /// </summary>
        /// <param name="sender">Save New Game button</param>
        /// <param name="e">Data sent</param>
        private void Button_Click_Save_New_Game(object sender, RoutedEventArgs e)
        {
            if (!((App)Application.Current).AddGame(this.NewGameName.Text))
            {
                // Change this to display an error
                return;
            }

            this.ViewNewGameForm = false;
            this.NewGameName.Text = string.Empty;
        }

        /// <summary>
        /// Button logic for when decides to cancel the new game creation
        /// </summary>
        /// <param name="sender">Cancel New Game button</param>
        /// <param name="e">Data sent</param>
        private void Button_Click_Cancel_New_Game(object sender, RoutedEventArgs e)
        {
            this.ViewNewGameForm = false;
            this.NewGameName.Text = string.Empty;
        }

        /// <summary>
        /// Notifies the view that a property has changed and updates the view
        /// </summary>
        /// <param name="propertyName">Name of the property that was updated</param>
        private void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
