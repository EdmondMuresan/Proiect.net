using Angajati.Data;
using Microsoft.Maui.Controls; 
using System;
using System.IO;

namespace Angajati
{
    public partial class App : Application
    {
        static AngajatDatabase angajatDatabase;

        public static AngajatDatabase AngajatDatabase
        {
            get
            {
                if (angajatDatabase == null)
                {
                    angajatDatabase = new AngajatDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Angajati.db3"));
                }
                return angajatDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
