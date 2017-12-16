//-----------------------------------------------------------------------
// <copyright file="GameListView.xaml.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge.Views
{
    using System.Windows.Controls;
    using RollToDodge.Models;
    using RollToDodge.ViewModels;

    /// <summary>
    /// Interaction logic for GameListView.xaml
    /// Represents the view of the list of games stored by the application
    /// </summary>
    public partial class GameListView : Page
    {
        /// <summary>
        /// Initializes a new instance of the GameListView class
        /// </summary>
        public GameListView()
        {
            this.InitializeComponent();
            this.DataContext = new GameListViewModel(new GameListModel());
        }
    }
}
