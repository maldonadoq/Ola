using Phonebook.Data;
using Phonebook.Model;
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

namespace Phonebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string operation = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact();
            contact.name = txtName.Text;
            contact.phone = txtPhone.Text;
            contact.email = txtEmail.Text;
            switch (operation)
            {

                case "add":
                    ContactData.AddToDb(contact);
                    break;
                case "edit":
                    ContactData.EditToDb(Convert.ToInt32(txtId.Text), contact);
                    break;
                default:
                    Console.WriteLine("Nothing");
                    break;
            }

            ListContacts();
            CleanFields();
            ActivateButtons(1);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            operation = "add";
            ActivateButtons(2);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            operation = "edit";
            ActivateButtons(2);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            operation = "cancel";
            CleanFields();
            ActivateButtons(1);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListContacts();
            ActivateButtons(1);
        }

        private void ListContacts()
        {
            dgContacts.ItemsSource = ContactData.FindFromDb();
        }

        private void CleanFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }

        private void ActivateButtons(int btn)
        {
            btnAdd.IsEnabled = false;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnSearch.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;

            switch (btn)
            {
                case 1:
                    btnAdd.IsEnabled = true;
                    btnSearch.IsEnabled = true;
                    break;
                case 2:
                    btnCancel.IsEnabled = true;
                    btnSave.IsEnabled = true;
                    break;
                case 3:
                    btnEdit.IsEnabled = true;
                    btnDelete.IsEnabled = true;
                    break;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Trim().Count() > 0)
            {
                try
                {
                    dgContacts.ItemsSource = ContactData.FindByNameFromDb(txtName.Text);
                }
                catch { }
            }
        }

        private void dgContacts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dgContacts.SelectedIndex >= 0)
            {
                Contact contact = (Contact)dgContacts.SelectedItem;

                txtId.Text = contact.id.ToString();
                txtName.Text = contact.name.ToString();
                txtPhone.Text = contact.phone.ToString();
                txtEmail.Text = contact.email.ToString();
                ActivateButtons(3);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ContactData.DeleteFromDb(Convert.ToInt32(txtId.Text));
            ListContacts();
            ActivateButtons(1);
            CleanFields();
        }
    }
}
