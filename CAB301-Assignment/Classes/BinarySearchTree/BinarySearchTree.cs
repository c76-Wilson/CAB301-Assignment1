using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment.Classes.BinarySearchTree
{
    public class BinarySearchTree
    {
        #region Properties

        private BinarySearchNode _TreeRoot;

        public BinarySearchNode TreeRoot
        {
            get { return _TreeRoot; }
            set { this._TreeRoot = value; }
        }

        #endregion

        #region Implementation

        // Check if tree is empty - return boolean
        public bool IsTreeEmpty()
        {
            return TreeRoot == null;
        }

        // Insert value into tree - check if root exists, if not create, otherwise do insert logic
        public void Insert(IComparable item)
        {
            // Create Tree Node from item
            BinarySearchNode node = new BinarySearchNode(item);

            // Check if root is null, if so create
            if (this.TreeRoot == null)
            {
                this.TreeRoot = node;
            }
            // Else insert into next available spot
            else
            {
                BinarySearchNode currentNode = this.TreeRoot;
                BinarySearchNode parent;

                while (true)
                {
                    parent = currentNode;

                    // Check if value to insert is less than the parent
                    if (item.CompareTo(parent.Data) < 0)
                    {
                        currentNode = currentNode.LeftNode;

                        if (currentNode == null)
                        {
                            parent.LeftNode = node;
                            break;
                        }
                    }
                    else
                    {
                        currentNode = currentNode.RightNode;

                        if (currentNode == null)
                        {
                            parent.RightNode = node;
                            break;
                        }
                    }
                }
            }
        }        

        #endregion

        #region Constructor

        public BinarySearchTree()
        {
            TreeRoot = null;
        }

        #endregion
    }
}
