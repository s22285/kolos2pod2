using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2pod2.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public int OrganizationID { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }

        public string MemberNickName { get; set; }
        public virtual ICollection<Membership> Membership { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
