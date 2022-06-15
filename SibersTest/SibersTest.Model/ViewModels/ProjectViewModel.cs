using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.Model.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string CustomerCompany { get; set; }
        public string ExecutingCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectPriority { get; set; }

    }
}
