using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFMiniProject {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public PersonModel person = new PersonModel();
        public BindingList<PersonModel> pepole = new BindingList<PersonModel>();


        public MainWindow() {
            InitializeComponent();
            addressListBox.ItemsSource = pepole;
            firstNameTextBox.Focus();
            //addressListBox.DisplayMemberPath = nameof(PersonModel.FullInfoDisplay);
        }

        private void addAddressButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(firstNameTextBox.Text)) {
                MessageBox.Show("You didnt enter a first name, Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                firstNameTextBox.Focus();
            } else if (string.IsNullOrEmpty(lastNameTextBox.Text)) {
                MessageBox.Show("You didnt enter a last name, Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                lastNameTextBox.Focus();
            } else {
                person.FirstName = CaptilizeLetters(firstNameTextBox.Text);
                //firstNameTextBox.Text.Substring(0, 1).ToUpper() + firstNameTextBox.Text.Substring(1);
                person.LastName = CaptilizeLetters(lastNameTextBox.Text);
                //lastNameTextBox.Text.Substring(0, 1).ToUpper() + lastNameTextBox.Text.Substring(1);
                AddressEntry address = new AddressEntry(person);
                address.Show();
                Hide();
            }
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            firstNameTextBox.Focus();
        }

        private void removeEntryButton_Click(object sender, RoutedEventArgs e) {
            int selectedItemToRemove = addressListBox.SelectedIndex;
            if (selectedItemToRemove == -1) {
                MessageBox.Show("You didnt select an entry to remove", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                pepole.RemoveAt(selectedItemToRemove);
            }
        }

        public string CaptilizeLetters(string text) {
            string output = "";
            int counter = 0;
            //for(int i=0; i < text.Length; i++) {
            //    if (Char.IsDigit(text[i]) || counter > 0 || char.IsWhiteSpace(text[i])) {
            //        output += text[i];
            //    } else if (Char.IsLetter(text[i]) && counter == 0 && !char.IsWhiteSpace(text[i])) {
            //        output += text[i].ToString().ToUpper();
            //        counter++;
            //    }  
            //}
            foreach (var letter in text) {
                if (Char.IsDigit(letter) || counter > 0 || char.IsWhiteSpace(letter)) {
                    output += letter;
                } else if (Char.IsLetter(letter) && counter == 0 && !char.IsWhiteSpace(letter)) {
                    output += letter.ToString().ToUpper();
                    counter++;
                }
            }
            return output;
        }
    }
}
