using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private F_StoreContext _storeContext;

        public MemberRepository(F_StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public MemberRepository()
        {
            this._storeContext = new F_StoreContext();
        }
        public IEnumerable<Member> GetAllMembers()
        {
            return this._storeContext.Members.ToList();
        }

        public void CreateMember(Member member)
        {
            if(member is not null)
            {
                this._storeContext.Members.Add(member);
                this._storeContext.SaveChanges();
            }
        }

        public Member? GetMember(string email)
        {
            return this._storeContext.Members.Where(c => c.Email.Equals(email)).FirstOrDefault();
        }   

        public bool DeleteMember(string email)
        {
            var memberDelete = GetMember(email);
            if(memberDelete != null)
            {
                _storeContext.Remove(memberDelete);
                _storeContext.SaveChanges();
            }
            var memberChecked = GetMember(email);
            if (memberChecked == null)
            {
                return true;
            }
            return false;
        }
    }
}
