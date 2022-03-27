using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using todo.Models;
using todo.Models.Enums;
using todo.Services.Interfaces;
using todo.Utils;

namespace todo.ViewModels
{
    public class HomeViewModel : BaseViewModel ,  INavigatedAware
    {
        public ObservableCollection<Tasks> TasksList { get; set; }
        public bool ContainsTask { get; set; }

        public DelegateCommand GoToAddTaskPageCommand { get; set; }
        public DelegateCommand<Tasks> DeleteTaskCommand { get; set; }
        public DelegateCommand<Tasks> CompleteTaskComand { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IDBService _dbService;

        public HomeViewModel(INavigationService navigationService, IDBService dBService)
        {
            _navigationService = navigationService;
            _dbService = dBService;

            RegisterCommands();
        }

        private void RegisterCommands()
        {
            GoToAddTaskPageCommand = new DelegateCommand(async () => await GoToAddTaskPage());
            DeleteTaskCommand = new DelegateCommand<Tasks>(async (obj) => await DeleteTask(obj));
            CompleteTaskComand = new DelegateCommand<Tasks>(async (obj) => await CompleteTask(obj));
        }

        private async Task DeleteTask(Tasks task)
        {
            if (task.TaskStatus == TasksStatusType.Incompleted)
            {
                // Ask before delete
            }
            await _dbService.DeleteTask(task);

            await GetTasks();
        }

        private async Task GetTasks()
        {
            var tasksList = await _dbService.GetTasks();

            TasksList = new ObservableCollection<Tasks>(tasksList);
            ContainsTask = tasksList.Any();
        }

        private async Task CompleteTask(Tasks task)
        {
            task.TaskStatus = TasksStatusType.Completed;

            await _dbService.UpdateTask(task);

            await GetTasks();
        }

        private async Task GoToAddTaskPage()
        {
            await _navigationService.NavigateAsync(Constants.Pages.addTaskPage, animated: true);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            await GetTasks();
        }
    }
}
