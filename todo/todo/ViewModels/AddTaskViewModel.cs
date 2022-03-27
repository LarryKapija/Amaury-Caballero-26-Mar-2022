using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using todo.Models;
using todo.Services.Interfaces;

namespace todo.ViewModels
{
    public class AddTaskViewModel : BaseViewModel
    {
        public Tasks Task { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DelegateCommand SaveTaskCommand { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IDialogServices _dialogServices;
        private readonly IDBService _dbService;

        public AddTaskViewModel(INavigationService navigationService, IDialogServices dialogServices, IDBService dBService)
        {
            _navigationService = navigationService;
            _dialogServices = dialogServices;
            _dbService = dBService;

            RegisterCommands();
        }

        private void RegisterCommands()
        {
            SaveTaskCommand = new DelegateCommand(async () => await SaveTask()) ;
        }

        private async Task SaveTask()
        {
            if (string.IsNullOrEmpty(Title))
            {
                _dialogServices.DisplayAlert(title: "ERROR", message:"The title must not be empty", cancel: "Accept") ;
                return;

            }
            Task = new Tasks() { Title = Title, Description = Description };

            await _dbService.SaveTask(Task);

            await _navigationService.GoBackAsync();
        }
    }
}
