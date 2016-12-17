using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Filmskikatalog
{
    /// <summary>
    /// Interaction logic for Editmovie.xaml
    /// </summary>
    public partial class Editmovie : Window
    {
        private Film _movie;
        private Film _oldMovie;

        public Film Film
        {
            get
            {
                return _movie;
            }
            set
            {
                _movie = value;
                RaisePropertyChanged();
            }
        }
        public Editmovie(Film movie)
        {
            DataContext = this;
            _oldMovie = movie;
            Film = movie;

            InitializeComponent();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public List<MovieTypeEnum> Genres
        {
            get
            {
                return Enum.GetValues(typeof(MovieTypeEnum)).Cast<MovieTypeEnum>().ToList<MovieTypeEnum>();
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Film.Genre = (MovieTypeEnum)comboBox.SelectedItem;
            //_oldMovie = CopyProperties(Film);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(
            [CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));

            }
        }
    }
}