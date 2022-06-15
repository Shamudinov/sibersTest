using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace SibersTest.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилие
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Проекты в которых он состоит
        /// </summary>

        public ICollection<ProjectUser> Projects { get; set; }

        /// <summary>
        /// Задача сотрудника
        /// </summary>
        public UTask EmployeeTask { get; set; }
        /// <summary>
        /// Созданная задача менеджером или руководителем
        /// </summary>
        public UTask CreateTask { get; set; }
    }
}
