using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2pod2.DTOs
{
    public class ParticularTeam
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string OrganizationName { get; set; }
        public IEnumerable<MemberList>List { get; set; }
    }
}
