using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Filmskikatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        List<Film> movies;
        public MainWindow()
        {
            InitializeComponent();
            movies = Film.getMovie();
            dataGrid.ItemsSource = movies;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddMovie win2 = new AddMovie();
            bool val = win2.ShowDialog().Value;
            if (val == true)
            {
                movies.Add(win2.Film);
                dataGrid.Items.Refresh();
            }
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Editmovie win2 = new Editmovie();
            win2.Show();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if
       (dataGrid.SelectedItem == null)
            {
                MessageBox.Show("Nothing is selected", "Error", MessageBoxButton.OK);
            }
            else
            {
                var result = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    movies.Remove((Film)dataGrid.SelectedItem);
                }
            }
        }
    }
}