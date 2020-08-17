using System;
using System.Collections.Generic;
using Question1.ViewModels;
using Question1.Views;
using Xamarin.Forms;

namespace Question1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();            
            Routing.RegisterRoute(nameof(TareaAddPage), typeof(TareaAddPage));
            Routing.RegisterRoute(nameof(TareaDetailPage), typeof(TareaDetailPage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
