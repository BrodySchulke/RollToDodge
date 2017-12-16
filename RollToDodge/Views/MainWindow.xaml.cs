//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Brody Schulke">
//     Brody Schulke
// </copyright>
//-----------------------------------------------------------------------
namespace RollToDodge.Views
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Represents the full window that contains other pages representing game information
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            Page mainMenu = new MainMenu();
            this.MainFrame.Navigate(mainMenu);
        }
    }
}
