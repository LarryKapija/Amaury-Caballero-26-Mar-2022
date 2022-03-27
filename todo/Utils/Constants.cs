using System;
using todo.Pages;
using Xamarin.Forms;

namespace todo.Utils
{
    public static class Constants
    {
        public static class Pages
        {
            public static string AbsoluteToHome = $"{navigationPage}/{homePage}/";

            public const string navigationPage = nameof(NavigationPage);
            public const string homePage = nameof(HomePage);
            public const string addTaskPage = nameof(AddTaskPage);
        }
    }
}
