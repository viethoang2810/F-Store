using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();
        bool DeleteMember(string email);
        void CreateMember(Member  member);
        Member GetMember(string email);

        bool UpdateMember(Member member);
    }
}
