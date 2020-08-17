using System.ComponentModel;
using Xamarin.Forms;
using Question1.ViewModels;

namespace Question1.Views
{    
    public partial class TareaDetailPage : ContentPage
    {
        public TareaDetailPage()
        {
            InitializeComponent();
            BindingContext = new TareaDetailViewModel();
        }
    }
}