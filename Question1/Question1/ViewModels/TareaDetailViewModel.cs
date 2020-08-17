using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using Question1.Views;

namespace Question1.ViewModels
{
    [QueryProperty(nameof(TareaId), nameof(TareaId))]
    public class TareaDetailViewModel: BaseViewModel
    {
        public Command DeleteTareaCommand { get; }

        private string tareaId;
        private string task;
        private string description;
        public bool isCompleted;
        public string Id { get; set; }

        public string Task
        {
            get => task;
            set => SetProperty(ref task, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public bool IsCompleted
        {
            get => isCompleted;
            set => SetProperty(ref isCompleted, value);
        }

        public string TareaId
        {
            get
            {
                return tareaId;
            }
            set
            {
                tareaId = value;
                LoadtareaId(value);
            }
        }        

        public TareaDetailViewModel()
        {
            DeleteTareaCommand = new Command(() => OnDeleteTareaCommand(TareaId));
        }

        public async void LoadtareaId(string tareaId)
        {
            try
            {
                var tarea = await App.Database.GetTareaAsync(Convert.ToInt32(tareaId));
                Id = tarea.Id.ToString();
                Task = tarea.Task;
                Description = tarea.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load tarea");
            }
        }

        private async void OnDeleteTareaCommand(string tareaId)
        {
            try
            {
                var tarea = await App.Database.GetTareaAsync(Convert.ToInt32(tareaId));
                var res = await App.Database.DeleteTareaAsync(tarea);                                
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load tarea");
            }
            finally
            {
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
