using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.DAL.Entities
{
    public class Project
    {
        public int Id { get; set; }
        /// <summary>
        /// Имя проекта
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// Название компании-заказчика
        /// </summary>
        public string CustomerCompany { get; set; }
        /// <summary>
        /// Название компании-исполнителя
        /// </summary>
        public string ExecutingCompany { get; set; }
        /// <summary>
        /// Сотрудники которые состоят в проекте
        /// </summary>
        public ICollection<ProjectUser> Employees { get; set; }
        /// <summary>
        /// Дата начала проекта
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Дата конца проекта
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Приоритет проекта
        /// </summary>
        public int ProjectPriority { get; set; }
        /// <summary>
        /// Задачи проекта
        /// </summary>
        public ICollection<UTask> UTasks { get; set; }
    }
}
