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

namespace Phonebook
{
    /// <summary>
    /// Lógica de interacción para TypeWindow.xaml
    /// </summary>
    public partial class TypeWindow : Window
    {
        public TypeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GroupTypeContacts();
        }

        private void GroupTypeContacts()
        {
            lvContacts.ItemsSource = ContactData.FindFromDb();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvContacts.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("category");
            view.GroupDescriptions.Add(groupDescription);
        }

    }
}
