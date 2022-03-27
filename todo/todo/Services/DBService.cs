using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using todo.Models;
using todo.Services.Interfaces;
using Xamarin.Forms;

namespace todo.Services
{
    public class DBService : IDBService
    {
        private readonly SQLiteAsyncConnection database;

        public DBService()
        {
            try
            {
                var databasePath = DependencyService.Get<IPathService>().GetDatabasePath();
                database = new SQLiteAsyncConnection(databasePath);

            }
            catch (Exception)
            {

            }
            finally
            {
                CreateTables();
            }
        }

        private async void CreateTables()
        {
            await database.CreateTableAsync<Tasks>().ConfigureAwait(false);
        }

        public async Task SaveTask(Tasks task)
        {
            await database.InsertOrReplaceAsync(task)
                .ConfigureAwait(false);
        }

        public async Task DeleteTask(Tasks task)
        {
            await database.DeleteAsync(task);
        }

        public async Task<IEnumerable<Tasks>> GetTasks()
        {
            return await database.Table<Tasks>().ToListAsync();
        }

        public async Task UpdateTask(Tasks task)
        {
            await database.UpdateAsync(task);
        }
    }
}
