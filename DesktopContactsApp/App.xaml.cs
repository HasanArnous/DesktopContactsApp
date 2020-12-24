using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string DB_name = "contacts.db";
        static string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DB_path = System.IO.Path.Combine(dirPath, DB_name);
    }
}
