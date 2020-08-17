using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Question1.Models;
using Xamarin.Forms;

namespace Question1.ViewModels
{
    class NewTareaViewModel: BaseViewModel
    {
        private string task;
        private string description;

        public NewTareaViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(task)
                && !String.IsNullOrWhiteSpace(description);
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Tarea newTarea = new Tarea()
            {
                //Id = Guid.NewGuid().ToString(),
                Task = Task,
                Description = Description
            };

            await App.Database.SaveTareaAsync(newTarea);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
