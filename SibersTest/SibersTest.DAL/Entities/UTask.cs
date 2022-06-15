using SibersTest.Model.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.DAL.Entities
{
    public class UTask
    {
        public int Id { get; set; }
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Автор задачи
        /// </summary>
        public string AuthorId { get; set; }
        public AppUser Author { get; set; }
        /// <summary>
        /// Исполнитель задачи
        /// </summary>
        public string TaskPerfomerId { get; set; }
        public AppUser TaskPerfomer { get; set; }
        /// <summary>
        /// Комментарии к задаче
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// Статус задачи
        /// </summary>
        public TaskStatusEnum TaskStatus { get; set; }
        /// <summary>
        /// Приоритет задачи
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Проект в котором состоит задача
        /// </summary>
        public int ProjectId { get; set; }
        public Project TaskProject { get; set; }

    }
}
