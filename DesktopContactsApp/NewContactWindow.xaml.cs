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
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Save Contact
            if (Valid_in())
            {
                string name = name_TextBox.Text.Trim();
                string email = email_TextBox.Text.Trim();
                string phone = phone_TextBox.Text.Trim();
                Contact contact = new Contact(name, email, phone);
                using (SQLiteConnection con = new SQLiteConnection(App.DB_path))
                {
                    con.CreateTable<Contact>();
                    con.Insert(contact);
                }
            }
            Close();
        }

        private bool Valid_in()
        {
            return (!(string.IsNullOrEmpty(name_TextBox.Text.Trim()) || string.IsNullOrEmpty(email_TextBox.Text.Trim()) || string.IsNullOrEmpty(phone_TextBox.Text.Trim()) ));
        }

    }
}
