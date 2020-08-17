using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Question1.Models;
using Question1.Views;
using Question1.Data;

namespace Question1.ViewModels
{
    public class TareasViewModel : BaseViewModel
    {
        private Tarea _selectedTarea;
        public ObservableCollection<Tarea> Tareas { get; }
        public Command LoadTareasCommand { get; }
        public Command AddTareaCommand { get; }
        public Command<Tarea> TareaTapped { get; }
        public TareasViewModel()
        {
            Title = "Lista de Tareas";
            Tareas = new ObservableCollection<Tarea>();

            LoadTareasCommand = new Command(async () => await ExecuteLoadTareasCommand());

            TareaTapped = new Command<Tarea>(OnTareaSelected);

            AddTareaCommand = new Command(OnAddTarea);
        }

        async Task ExecuteLoadTareasCommand()
        {
            IsBusy = true;

            try
            {
                Tareas.Clear();
                var data = await App.Database.GetTareasAsync();
                foreach (var i in data)
                {
                    Tareas.Add(i);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedTarea = null;
        }

        public Tarea SelectedTarea
        {
            get => _selectedTarea;
            set
            {
                SetProperty(ref _selectedTarea, value);
                OnTareaSelected(value);
            }
        }

        private async void OnAddTarea(object obj)
        {
            await Shell.Current.GoToAsync(nameof(TareaAddPage));
        }

        async void OnTareaSelected(Tarea Tarea)
        {
            if (Tarea == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(TareaDetailPage)}?{nameof(TareaDetailViewModel.TareaId)}={Tarea.Id}");
        }
    }
}