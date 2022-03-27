using System;
using System.Collections.Generic;
using SQLite;
using todo.Models.Enums;

namespace todo.Models
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class Tasks
    {
        public Tasks()
        {
            ID = new Guid().ToString();
            CreationDate = DateTime.Now;
        }

        [PrimaryKey]
        public string ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public TasksStatusType TaskStatus { get; set; }


        public static List<Tasks> TasksFactory()
        {
            return new List<Tasks>()
            {
                new Tasks()
                {
                    Title = "Pasear el perro",
                    Description = "Ir al parque con el perro",
                    TaskStatus = TasksStatusType.Incompleted,
                },
                new Tasks()
                {
                    Title = "Lavar el vehiculo",
                    Description = "Ir al car wash para hacer un lavado profundo",
                    TaskStatus = TasksStatusType.Completed,
                },
                new Tasks()
                {
                    Title = "Cocinar",
                    Description = "",
                    TaskStatus = TasksStatusType.Incompleted,
                }
            };
        }
    }
}
