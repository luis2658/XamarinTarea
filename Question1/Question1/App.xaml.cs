using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Question1.Services;
using Question1.Views;
using Question1.Data;
using System.IO;

namespace Question1
{
    public partial class App : Application
    {
        static TareasDB database;

        public static TareasDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new TareasDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TareasDB.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();            

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
