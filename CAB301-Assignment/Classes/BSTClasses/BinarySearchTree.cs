using CAB301_Assignment.MovieClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment.Classes.BSTClasses
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

        // Search function - returns true if the inputted item exists
        public bool Search(IComparable item)
        {
            if (this.TreeRoot != null)
            {
                BinarySearchNode currentNode = this.TreeRoot;

                while (true)
                {
                    if (item.CompareTo(currentNode.Data) == 0)
                    {
                        return true;
                    }
                    else if (item.CompareTo(currentNode.Data) < 0)
                    {
                        if (currentNode.LeftNode != null)
                        {
                            currentNode = currentNode.LeftNode;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (currentNode.RightNode != null)
                        {
                            currentNode = currentNode.RightNode;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
        }

        // Insert value into tree - check if root exists, if not create, otherwise do insert logic
        public void Insert(IComparable item)
        {
            // Check to see if movie exists already - if so add qty
            if (Search(item))
            {
                BinarySearchNode currentNode = this.TreeRoot;

                while (true)
                {
                    if (item.CompareTo(currentNode.Data) == 0)
                    {
                        ((Movie)currentNode.Data).Quantity += ((Movie)item).Quantity;
                    }
                    else if (item.CompareTo(currentNode.Data) < 0)
                    {
                        if (currentNode.LeftNode != null)
                        {
                            currentNode = currentNode.LeftNode;
                        }
                    }
                    else
                    {
                        if (currentNode.RightNode != null)
                        {
                            currentNode = currentNode.RightNode;
                        }
                    }
                }
            }
            else
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
        }

        public void Delete(IComparable item)
        {
            // Check to see if the item exists
            if (Search(item))
            {
                BinarySearchNode nodeToDelete = this.TreeRoot;
                // Get the node to delete
                while (item.CompareTo(nodeToDelete.Data) != 0)
                {
                    if (item.CompareTo(nodeToDelete.Data) < 0) // Go to left node
                    {
                        nodeToDelete = nodeToDelete.LeftNode;
                    }
                    else
                    {
                        nodeToDelete = nodeToDelete.RightNode;
                    }
                }

                // Node to delete has 2 children
                if (nodeToDelete.LeftNode != null && nodeToDelete.RightNode != null)
                {
                    // If the right child of the left subtree is null
                    if (nodeToDelete.LeftNode.RightNode == null)
                    {
                        nodeToDelete.Data = nodeToDelete.LeftNode.Data;
                        nodeToDelete.LeftNode = nodeToDelete.LeftNode.LeftNode;
                    }
                    else
                    {
                        BinarySearchNode currentNode = nodeToDelete.LeftNode;
                        BinarySearchNode parentOfCurrentNode = nodeToDelete;

                        // Find the rightmost node in the left tree
                        while (currentNode.RightNode != null)
                        {
                            currentNode = currentNode.RightNode;
                            parentOfCurrentNode = currentNode;
                        }

                        // Copy rightmost node to deleted node
                        nodeToDelete.Data = currentNode.Data;
                        parentOfCurrentNode.RightNode = currentNode.LeftNode;
                    }
                }
            }
        }

        public void Clear()
        {
            TreeRoot = null;
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
