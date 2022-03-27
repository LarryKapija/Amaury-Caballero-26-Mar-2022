using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo.Models;

namespace todo.Services.Interfaces
{
    public interface IDBService
    {
        Task SaveTask(Tasks task);

        Task UpdateTask(Tasks task);

        Task DeleteTask(Tasks task);

        Task<IEnumerable<Tasks>> GetTasks();

    }
}
