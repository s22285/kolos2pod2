using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2pod2.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public int OrganizationID { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public virtual ICollection<Membership> Membership { get; set; }
        public virtual ICollection<File> File { get; set; }
        public  Organization Organization { get; set; }
    }
}
