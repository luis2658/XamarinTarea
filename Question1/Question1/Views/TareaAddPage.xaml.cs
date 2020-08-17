using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Question1.Models;
using Question1.ViewModels;

namespace Question1.Views
{    
    public partial class TareaAddPage : ContentPage
    {
        public Tarea tarea { get; set; }
        public TareaAddPage()
        {
            InitializeComponent();
            BindingContext = new NewTareaViewModel();
        }
    }
}