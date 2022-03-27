using System;
using System.IO;
using todo.iOS.Services;
using todo.Services.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathService))]
namespace todo.iOS.Services
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, "todo.db");
        }
    }
}
