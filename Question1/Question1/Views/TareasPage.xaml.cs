using Question1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Question1.Views
{    
    public partial class TareasPage : ContentPage
    {
        TareasViewModel _viewModel;
        public TareasPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new TareasViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}