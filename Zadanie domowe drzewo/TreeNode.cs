using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drzewo
{
    public class TreeNode
    {
        private int data;
        public int Data
        {
            get { return data; }
        }
        private TreeNode rightNode;
        public TreeNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }
        private TreeNode leftNode;
        public TreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }
        private bool isDeleted;
        public bool IsDeleted
        {
            get { return isDeleted; }
        }
        public TreeNode(int value)
        {
            data = value;
        }
        public void Delete()
        {
            isDeleted = true;
        }
        public TreeNode Find(int value)
        {
            TreeNode currentNode = this;
            while (currentNode != null)
            {
                if(value == currentNode.data && isDeleted == false)
                {
                    return currentNode;
                }
                else if(value == currentNode.data && isDeleted == false)
                {
                    currentNode = currentNode.rightNode;
                }
                else
                {
                    currentNode = currentNode.leftNode;
                }
            }
            return null;
        }

        public void Insert(int value)
        {
            if (value >= data)
            {
                if(rightNode == null)
                {
                    rightNode = new TreeNode(value);
                }
                else
                {
                    rightNode.Insert(value);
                }
            }
            else
            {
                if (leftNode == null)
                {
                    leftNode = new TreeNode(value);
                }
                else
                {
                    leftNode.Insert(value);
                }
            }
        }

        public void InOrderTraversal()
        {
            if (leftNode != null)
                leftNode.InOrderTraversal();
            MessageBox.Show(data + " ");
            if (rightNode != null)
                rightNode.InOrderTraversal();
        }
    }
}
