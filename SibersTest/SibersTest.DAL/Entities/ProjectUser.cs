using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.DAL.Entities
{
    /// <summary>
    /// EF core 5 - many to many
    /// </summary>
    public class ProjectUser
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
