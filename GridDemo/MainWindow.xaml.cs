using GridDemo.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace GridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> personList = new ObservableCollection<Person>();   //Comme une liste mais plus intelligente, faite pour WPF 
        //List<Person> personList = new List<Person>(); 
        List<Countries> countriesList = new List<Countries>();
        public MainWindow()
        {
            InitializeComponent();
            BindGrid();
            BindCountries();
        }

        private void BindGrid()
        {
            personList.Add(new Person("Rik", 25, "Man", "Belgium"));
            personList.Add(new Person("Salva", 32, "Man","Germany"));
            personList.Add(new Person("Zak", 24, "Man","Italy"));
            personList.Add(new Person("Evy", 22, "Woman","Spain"));
            personList.Add(new Person("Gabi", 30, "Woman","Belgium"));
            personList.Add(new Person("Hugo", 25, "Man","Germany"));
            personList.Add(new Person("Ole", 24, "Woman","Italy"));

            dataGrid.ItemsSource = personList;  //Pas besoin de foreach avec WPF
        }
        private void BindCountries()
        {
            countriesList.Add(new Countries("Belgium"));
            countriesList.Add(new Countries("Germany"));
            countriesList.Add(new Countries("Italy"));
            countriesList.Add(new Countries("Spain"));

            cmbCountry.ItemsSource = countriesList;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            txtName.Focus();
            string name = txtName.Text;
            int age = int.Parse(txtAge.Text);
            string gender = txtGender.Text;
            string country = cmbCountry.SelectedValue.ToString();

            try
            {
                personList.Add(new Person(name, age , gender , country));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //dataGrid.Items.Refresh();  //A utiliser avec la liste pour montrer le nouvel élément ajouté

            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtGender.Text = string.Empty;
            cmbCountry.Text = string.Empty;
        }
        public void Search(string searchFor)
        {
            var result = personList.Where(p => p.Country.Equals(searchFor)).ToList();
            dataGrid.ItemsSource = result;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person person = dataGrid.SelectedItem as Person;
            txtName.Text = person.Name;
            txtAge.Text = person.Age.ToString();
            txtGender.Text = person.Gender;
            cmbCountry.Text = person.Country;

            //dataGrid.Items.Clear();
            //BindGrid();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search(cmbCountry.SelectedValue.ToString());
        }
    }
}