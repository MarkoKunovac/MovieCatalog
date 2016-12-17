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
using System.Windows.Shapes;

namespace Filmskikatalog
{
    /// <summary>
    /// Interaction logic for AddMovie.xaml
    /// </summary>
    public partial class AddMovie : Window
    {
        public DateTime dates;
        public Film Film { get; set; }
        public AddMovie()
        {
            Film = new Film();
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        public List<MovieTypeEnum> Genres
        {
            get
            {
                return Enum.GetValues(typeof(MovieTypeEnum)).Cast<MovieTypeEnum>().ToList<MovieTypeEnum>();

            }
        }
    }
}