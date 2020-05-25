using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment.Classes
{
    public class MemberCollection

    {
        private Member[] _Members;

        public Member[] Members
        {
            get { return _Members; }
            set { _Members = value; }
        }
        public void AddMember(Member member)
        {
            // Get first empty entry in Members array
            int firstEmptyIndex = Array.FindIndex(this.Members, x => x == null);

            // If there are no member slots left, resize current array to fit new member
            if (firstEmptyIndex == -1)
            {
                Member[] members = this.Members;

                Array.Resize(ref members, Members.Length + 1);
                this.Members = members;

                // call this method again now that the array has space
                AddMember(member);
            }
            else
            {
                this.Members[firstEmptyIndex] = member;
            }
        }

        public String GetPhoneNumber(String fullName)
        {
            Member foundMember = Array.Find(this.Members, x => x != null && x.FullName == fullName);

            // Return null if no member found with given name
            if (foundMember == null)
            {
                return null;
            }
            else
            {
                return foundMember.PhoneNumber;
            }
        }

        public MemberCollection(int maxMembers)
        {
            this.Members = new Member[maxMembers];
        }
    }
}
