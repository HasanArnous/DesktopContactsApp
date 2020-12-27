using DesktopContactsApp.Classes;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> MyContacts;
        public MainWindow()
        {
            MyContacts = new List<Contact>();
            InitializeComponent();
            ReadDB();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            ReadDB();
        }

        void ReadDB()
        {
            using (SQLite.SQLiteConnection con = new SQLite.SQLiteConnection(App.DB_path))
            {
                con.CreateTable<Contact>();
                MyContacts = con.Table<Contact>().ToList();
                MyContacts = MyContacts.OrderBy(c => c.Name).ToList();

                // Or Using Linq: Language Integrated Query
                List<Contact> MyContact2 = (from c2 in MyContacts
                                            orderby c2.Name
                                            select c2).ToList();
            }
            if (MyContacts != null)
            {
                contactsListView.ItemsSource = MyContacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox filterBox = sender as TextBox;
            List<Contact> filteredList = MyContacts.Where(c => c.Name.ToLower().Contains(filterBox.Text.ToLower())).ToList();

            // Or Using Linq: Language Integrated Query

            List<Contact> filteredList2 = (from c2 in MyContacts where c2.Name.ToLower().Contains(filterBox.Text.ToLower()) select c2).ToList();

            contactsListView.ItemsSource = filteredList;
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactsListView.SelectedItem;
            if(selectedContact != null)
            {
                ContactDetailsWindoww contactDetailsWindoww = new ContactDetailsWindoww(selectedContact);
                contactDetailsWindoww.ShowDialog();
                ReadDB();
            }
        }
    }
}
