using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFMiniProject {
    /// <summary>
    /// Interaction logic for AddressEntry.xaml
    /// </summary>
    public partial class AddressEntry : Window {
        PersonModel personToEdit;
        public AddressEntry(PersonModel person) {
            InitializeComponent();
            personToEdit = person;
            streetTextBox.Focus();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(streetTextBox.Text)) {
                MessageBox.Show("You didnt enter a Street name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (string.IsNullOrEmpty(cityTextBox.Text)) {
                MessageBox.Show("You didnt enter a City name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (string.IsNullOrEmpty(zipCodeTextBox.Text)) {
                MessageBox.Show("You didnt enter a Zip Code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (string.IsNullOrEmpty(countryTextBox.Text)) {
                MessageBox.Show("You didnt enter a Country name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                personToEdit.Street = ((MainWindow)Application.Current.MainWindow).CaptilizeLetters(streetTextBox.Text);
                personToEdit.City = ((MainWindow)Application.Current.MainWindow).CaptilizeLetters(cityTextBox.Text);
                personToEdit.Country = countryTextBox.Text.ToUpper();
                personToEdit.ZipCode = zipCodeTextBox.Text;

                ((MainWindow)Application.Current.MainWindow).pepole.Add(personToEdit);
                Application.Current.MainWindow.Show();
                Close();
            }
        }
    }
}
