using SibersTest.Model.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.Model.Models
{
    public class UTaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public int? Priority { get; set; }
        public string AuthorId { get; set; }
        public string TaskPerfomerId { get; set; }
        public int? ProjectId { get; set; }
        public TaskStatusEnum TaskStatus { get; set; }

    }
}
