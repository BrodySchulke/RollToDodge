using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using RollToDodge.Models;
using RollToDodge.ViewModels;


namespace RollToDodge.Views
{
    /// <summary>
    /// Interaction logic for GamesListView.xaml
    /// </summary>
    public partial class GamesListView : Page
    {
        public GamesListView()
        {
            InitializeComponent();
            this.DataContext = new GamesListViewModel(new GamesListModel());
        }
    }
}
