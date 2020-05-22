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

        public MemberCollection(int maxMembers)
        {
            this.Members = new Member[maxMembers];
        }
    }
}
