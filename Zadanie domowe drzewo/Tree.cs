using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drzewo
{
    public class Tree
    {
        private TreeNode root;
        public TreeNode Root
        {
            get { return root; }

        }

        public TreeNode Find(int data)
        {
            if (root != null)
            {
                return root.Find(data);
            }
            else
            {
                return null;
            }
        }

        public void Insert(int data)
        {
            if (root != null)
            {
                root.Insert(data);
            }
            else
            {
                root = new TreeNode(data);
            }
        }
        public void Remove(int data)
        {
            TreeNode current = root;
            TreeNode parent = root;
            bool isLeftChild = false;
            if (current == null)
            {
                return;
            }
            while (current != null && current.Data != data)
            {
                parent = current;
                if (data < current.Data)
                {
                    current = current.LeftNode;
                    isLeftChild = true;
                }
                else
                {
                    current = current.RightNode;
                    isLeftChild = false;
                }
            }
            if (current == null)
            {
                return;
            }
            if (current.RightNode == null && current.LeftNode == null)
            {
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = null;
                    }
                    else
                    {
                        parent.RightNode = null;
                    }
                }
            }
            else if (current.RightNode == null)
            {
                if (current == root)
                {
                    root = current.LeftNode;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = current.LeftNode;
                    }
                    else
                    {
                        parent.RightNode = current.LeftNode;
                    }
                }
            }
            else if(current.LeftNode == null)
            {
                if (current == root)
                {
                    root = current.RightNode;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = current.RightNode;
                    }
                    else
                    {
                        parent.RightNode = current.RightNode;
                    }
                }
            }
            else
            {
                TreeNode succesor = GetSuccesor(current);
                if (current == root)
                {
                    root = succesor;
                }
                else if (isLeftChild)
                {
                    parent.LeftNode = succesor;
                }
                else
                {
                    parent.RightNode = succesor;
                }
            }
        }

        private TreeNode GetSuccesor(TreeNode node)
        {
            TreeNode parentOfSuccesor = node;
            TreeNode succesor = node;
            TreeNode current = node.RightNode;
            while(current != null)
            {
                parentOfSuccesor = succesor;
                succesor = current;
                current = current.LeftNode;
            }
            if (succesor != node.RightNode)
            {
                parentOfSuccesor.LeftNode = succesor.RightNode;
                succesor.RightNode = node.RightNode;
            }
            succesor.LeftNode = node.LeftNode;
            return succesor;
        }

        public void InOrderTraversal()
        {
            if (root != null)
            {
                root.InOrderTraversal();
            }

        }
    }
}