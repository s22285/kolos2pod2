using kolos2pod2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolos2pod2.DTOs;
using kolos2pod2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolos2pod2.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _context;

        public DbService(MainDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckTeam(int TeamId)
        {
            return await _context.Team.AnyAsync(m => m.TeamID.Equals(TeamId));
        }

        public async Task<ParticularTeam> GetTeam(int TeamId)
        {
            return await _context.Member
                .Include(m => m.Membership)
                .Select(m => new ParticularTeam
                {
                    //TeamName = m.TeamName,
                   // TeamDescription = m.TeamDescription,
                   // OrganizationName = m.OrganizationName,
                   // List = m.Member.Select(mt => new MemberList
                    //{
                        //MemberName = mt.Member.MemberName,
                       // MemberSurname = mt.Member.MemberSurname
                   // }).OrderBy(mt => mt.MembershipDate)
                })
                .SingleOrDefaultAsync();
        }

        public async Task<bool> CheckMember(int MemberID)
        {
            var tracks = _context.Organization.Where(mt => mt.OrganizationID.Equals(MemberID)).Select(e => e.OrganizationID)
                .Intersect(_context.Member.Where(t => t.MemberID.Equals(null)).Select(t => t.MemberID));
            return await tracks.AnyAsync();
        }

        public async Task<Member> AddMember(int MemberId)
        {
            var member = _context.Member.SingleOrDefaultAsync(m => m.MemberID.Equals(MemberId));
            _context.Add(member);
            await _context.SaveChangesAsync();
            return await member;
        }
    }
}
