using CAB301_Assignment.Enums;
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
                // Need to keep track of parent so we can move children to it later.
                BinarySearchNode parentOfNodeToDelete = null;
                // Get the node to delete
                while (item.CompareTo(nodeToDelete.Data) != 0)
                {
                    parentOfNodeToDelete = nodeToDelete;
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
                else
                {
                    // Get the child node (or null if no children) of the node to be deleted
                    BinarySearchNode childNode;
                    if (nodeToDelete.LeftNode != null)
                    {
                        childNode = nodeToDelete.LeftNode;
                    }
                    else
                    {
                        childNode = nodeToDelete.RightNode;
                    }

                    // Check if the node to delete is the tree root - if so replace it with the child
                    if (nodeToDelete == TreeRoot)
                    {
                        TreeRoot = childNode;
                    }
                    else
                    {
                        // If not tree root, replace node to delete with its child (or null if it has no children)
                        if (nodeToDelete == parentOfNodeToDelete.LeftNode)
                        {
                            parentOfNodeToDelete.LeftNode = childNode;
                        }
                        else
                        {
                            parentOfNodeToDelete.RightNode = childNode;
                        }
                    }
                }
            }
        }

        public Movie BorrowMovie(IComparable item)
        {
            // Search to see if movie exists
            if (Search(item))
            {
                BinarySearchNode nodeToBorrow = this.TreeRoot;
                while (item.CompareTo(nodeToBorrow.Data) != 0)
                {
                    if (item.CompareTo(nodeToBorrow.Data) < 0) // Go to left node
                    {
                        nodeToBorrow = nodeToBorrow.LeftNode;
                    }
                    else
                    {
                        nodeToBorrow = nodeToBorrow.RightNode;
                    }
                }

                return ((Movie)nodeToBorrow.Data);                
            }
            else
            {
                return null;
            }
        }

        public void ReturnMovie(IComparable item)
        {
            // Search to see if movie exists in system - if not create it (edge case for if movie is deleted while it is borrowed)
            if (Search(item))
            {
                BinarySearchNode nodeToReturn = this.TreeRoot;
                while (item.CompareTo(nodeToReturn.Data) != 0)
                {
                    if (item.CompareTo(nodeToReturn.Data) < 0) // Go to left node
                    {
                        nodeToReturn = nodeToReturn.LeftNode;
                    }
                    else
                    {
                        nodeToReturn = nodeToReturn.RightNode;
                    }
                }

                ((Movie)nodeToReturn.Data).Quantity++;
            }
            else
            {
                Insert(item);
            }
        }

        public void InOrderTraverseWriteDetails()
        {
            if (TreeRoot != null)
            {
                InOrderTraverseWriteDetails(TreeRoot);
            }
        }

        public void InOrderTraverseWriteDetails(BinarySearchNode node)
        {
            if (node != null)
            {
                // Turn IComparable into movie
                Movie movie = ((Movie)node.Data);

                //Traverse left tree if not null
                if (node.LeftNode != null)
                {
                    InOrderTraverseWriteDetails(node.LeftNode);
                }

                // Print current movie details
                Console.WriteLine("Title: \t\t{0}\r\n" +
                    "Genre: \t\t{1}\r\n" +
                    "Rating: \t{2}\r\n" +
                    "Starring: \t{3}\r\n" +
                    "Director: \t{4}\r\n" +
                    "Duration: \t{5}\r\n" +
                    "Release Date: \t{6}\r\n" +
                    "AVAILABLE: \t{7}\r\n",
                    movie.Title,
                    (movie.Genre == Genre.SciFi ? "Sci-Fi" : movie.Genre.ToString()),
                    ((movie.Rating == Rating.M15 || movie.Rating == Rating.MA15) ? (movie.Rating == Rating.M15 ? "M15+" : "MA15+") : movie.Rating.ToString()),
                    movie.Starring,
                    movie.Director,
                    movie.Duration,
                    movie.ReleaseDate.ToString("dd/MM/yyyy"),
                    movie.Quantity.ToString());

                if (node.RightNode != null)
                {
                    InOrderTraverseWriteDetails(node.RightNode);
                }
            }
        }

        public void InOrderTraverseWriteList()
        {
            if (TreeRoot != null)
            {
                InOrderTraverseWriteList(TreeRoot);
            }
        }

        public void InOrderTraverseWriteList(BinarySearchNode node)
        {
            if (node != null)
            {
                // Turn IComparable into movie
                Movie movie = ((Movie)node.Data);

                //Traverse left tree if not null
                if (node.LeftNode != null)
                {
                    InOrderTraverseWriteList(node.LeftNode);
                }

                // Print current movie details
                Console.WriteLine("Title: \t\t{0}\r\n", movie.Title);

                if (node.RightNode != null)
                {
                    InOrderTraverseWriteList(node.RightNode);
                }
            }
        }

        public Movie[] ConvertToArray(int arraySize)
        {
            if (TreeRoot != null)
            {
                Movie[] unsortedArray = new Movie[arraySize];
                ExtractNodeData(TreeRoot, unsortedArray, 0);
                return unsortedArray;
            }
            return null;
        }

        public int ExtractNodeData(BinarySearchNode node, Movie[] unsortedArray, int index)
        {
            //Traverse left tree if not null
            if (node.LeftNode != null)
            {
                index = ExtractNodeData(node.LeftNode, unsortedArray, index);
            }

            if (node.RightNode != null)
            {
                index = ExtractNodeData(node.RightNode, unsortedArray, index);
            }

            unsortedArray[index] = (Movie)node.Data;

            return index + 1;
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
