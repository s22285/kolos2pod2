using kolos2pod2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolos2pod2.DTOs;

namespace kolos2pod2.Services
{
    public interface IDbService
    {
        public Task<Member> AddMember(int MemberId);
        public Task<bool> CheckMember(int MemberID);
        public Task<ParticularTeam> GetTeam(int TeamId);
        public Task<bool> CheckTeam(int TeamId);
    }
}
