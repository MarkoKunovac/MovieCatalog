using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace Filmskikatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        FilmContext ctx;

        ObservableCollection<Film> movies;
        ObservableCollection<Film> Movies
        {
            get
            {
                string text = TextBox.Text;
                if (string.IsNullOrEmpty(text))
                    return movies;

                ObservableCollection<Film> filtered = new ObservableCollection<Film>();
                foreach (var movie in movies)
                {
                    if (movie.Name.StartsWith(text) || movie.Genre.ToString().StartsWith(text))
                    {
                        filtered.Add(movie);
                    }
                }
                return filtered;
            }
            set
            {
                movies = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            ctx = new FilmContext();


            //Movies = Film.getMovie();
            Movies = new ObservableCollection<Film>(ctx.Filmovi);

            dataGrid.ItemsSource = Movies;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddMovie win2 = new AddMovie();
            bool val = win2.ShowDialog().Value;
            if (val == true)
            {
                Movies.Add(win2.Film);
                dataGrid.Items.Refresh();
            }
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if
                (dataGrid.SelectedItem == null)
            {
                MessageBox.Show("Nothing is selected", "Error", MessageBoxButton.OK);
            }
            else
            {
                Editmovie win2 = new Editmovie((Film)dataGrid.SelectedItem);
                win2.Show();
            }
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
                    Movies.Remove((Film)dataGrid.SelectedItem);
                }
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //Microsoft.Win32.SaveFileDialog SaveFile = new Microsoft.Win32.SaveFileDialog();
            //SaveFile.FileName = "Movies";
            //SaveFile.DefaultExt = ".xml"; // Default file extension
            //SaveFile.Filter = "XML Files (.xml)|*.xml|JSON Files (*.json)|*.json"; // Filter by extension

            //// Process save file dialog box results
            //if (SaveFile.ShowDialog() == true)
            //{
            //    // Save
            //    string filename = SaveFile.FileName;
            //    // izvlacenje extenzije (ubaci u if else)

            //    string ext = System.IO.Path.GetExtension(filename);

            //    // Serializer
            //    if (ext.Equals(".xml"))
            //    {

            //        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Film>));

            //        using (FileStream writer = new FileStream(filename, FileMode.OpenOrCreate))
            //        {
            //            serializer.Serialize(writer, Movies);
            //        }
            //    }
            //    else if (ext == ".json")
            //    {
            //        string json = JsonConvert.SerializeObject(Movies, Formatting.Indented);

            //        File.WriteAllText(filename, json);
            //    }
            //}

            ctx.SaveChanges();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = Movies;
        }
    }
}