using Phonebook.Data;
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
using System.ComponentModel;
using System.Globalization;
using Phonebook.Model;
using Phonebook.Utils;

namespace Phonebook
{
    /// <summary>
    /// Lógica de interacción para NameWindow.xaml
    /// </summary>
    public partial class NameWindow : Window
    {
        public NameWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GroupNameContacts();
        }

        private void GroupNameContacts()
        {
            lvContacts.ItemsSource = ContactData.FindFromDb();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvContacts.ItemsSource);
            GroupDescription groupDescription = new GroupFirstCharacter();
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
