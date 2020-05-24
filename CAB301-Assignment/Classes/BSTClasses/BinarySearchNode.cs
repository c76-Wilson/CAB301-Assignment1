using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment.Classes.BSTClasses
{
    public class BinarySearchNode
    {
        #region Properties

        private IComparable _Data;

        public IComparable Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        private BinarySearchNode _LeftNode;

        public BinarySearchNode LeftNode
        {
            get { return _LeftNode; }
            set { _LeftNode = value; }
        }

        private BinarySearchNode _RightNode;

        public BinarySearchNode RightNode
        {
            get { return _RightNode; }
            set { _RightNode = value; }
        }

        #endregion

        #region Constructors

        public BinarySearchNode() { }

        public BinarySearchNode(IComparable data)
        {
            this.Data = data;
        }

        #endregion
    }
}
