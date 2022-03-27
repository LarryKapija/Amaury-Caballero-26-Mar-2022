using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using todo.Pages;
using todo.Services;
using todo.Services.Interfaces;
using todo.Utils;
using todo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todo
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer)
        {

        }

        protected override async void OnInitialized()
        {
            InitialConfiguration();

            await NavigationService.NavigateAsync(Constants.Pages.AbsoluteToHome);
        }

        private void InitialConfiguration()
        {
            InitializeComponent();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDBService, DBService>();
            containerRegistry.Register<IDialogServices, DialogServices>();


            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>();
            containerRegistry.RegisterForNavigation<AddTaskPage, AddTaskViewModel>();
        }
    }
}
