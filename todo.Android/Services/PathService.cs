using System;
using System.IO;
using todo.Droid.Services;
using todo.Services.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathService))]
namespace todo.Droid.Services
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            return Path.Combine(path, "todo.db");
        }
    }
}
