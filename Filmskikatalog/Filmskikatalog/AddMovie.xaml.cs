﻿using System;
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
        public Film Film { get; set; }
        public AddMovie()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Film = new Film();
            Film.Name = nameBox.Text;
            Film.Genre = genreComboBox.Text;
            Film.Director = directorBox.Text;
            DialogResult = true;
            Close();
        }
    }
}