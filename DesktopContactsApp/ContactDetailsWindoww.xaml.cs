using DesktopContactsApp.Classes;
using SQLite;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindoww.xaml
    /// </summary>
    public partial class ContactDetailsWindoww : Window
    {
        Contact contact;
        public ContactDetailsWindoww(Contact _contact)
        {
            InitializeComponent();
            contact = _contact;
            DisplayDetails();
        }

        void DisplayDetails()
        {
            if(contact != null)
            {
                name_TextBox.Text = contact.Name;
                email_TextBox.Text = contact.Email;
                phone_TextBox.Text = contact.Phone;
            }
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            string name = name_TextBox.Text.Trim();
            string email = email_TextBox.Text.Trim();
            string phone = phone_TextBox.Text.Trim();
            if(!(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone)))
            {
                contact.Name = name;
                contact.Email = email;
                contact.Phone = phone;
                using (SQLiteConnection con = new SQLiteConnection(App.DB_path))
                {
                    con.CreateTable<Contact>();
                    con.Update(contact);
                }
                Close();
            }
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.DB_path))
            {
                con.CreateTable<Contact>();
                con.Delete(contact);
            }
            Close();
        }
    }
}
