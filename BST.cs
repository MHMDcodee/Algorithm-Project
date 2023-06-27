using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgoProj2
{
    class BST
    {
        int z = 0;
        List<int> ptr1 = new List<int>();
        List<int> ptr2 = new List<int>();

        public Node Root;
        public BST()
        {
            Root = null;
        }

        public Node Search(Node root, int key)
        {
            while (root != null && root.Data != key)
            {
                if (root.Data > key)
                {
                    root = root.LC;
                }
                else
                    root = root.RC;
            }
            return root;
        }

        Node insert(Node root, int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }
            if (key < root.Data)
                root.LC = insert(root.LC, key);
            else if (key > root.Data)
                root.RC = insert(root.RC, key);
            return root;
        }
        public void Insert(int x)
        {
            Root = insert(Root, x);
        }
        public Node DeleteNode(Node root, int k)
        {
            if (root == null)
                return root;
            if (root.Data > k)
            {
                root.LC = DeleteNode(root.LC, k);
                return root;
            }
            else if (root.Data < k)
            {
                root.RC = DeleteNode(root.RC, k);
                return root;
            }

            if (root.LC == null)
            {
                Node temp = root.RC;
                root = null;
                return temp;
            }
            else if (root.RC == null)
            {
                Node temp = root.LC;
                root = null;
                return temp;
            }

            else //both childs exist
            {

                Node temp = root;

                Node ptr = root.RC;
                while (ptr.LC != null)
                {
                    temp = ptr;
                    ptr = ptr.LC;
                }

                if (temp != root)
                    temp.LC = ptr.RC;
                else
                    temp.RC = ptr.RC;

                root.Data = ptr.Data;

                ptr = null;
                return root;
            }
        }
        public List<int> Inorder(Node root)
        {
            if (root != null)
            {
                Inorder(root.LC);
                ptr1.Add(root.Data);
                Inorder(root.RC);
            }
            return ptr1;
        }
        public List<int> Inorder2(Node root)
        {
            if (root != null)
            {
                Inorder2(root.LC);
                ptr2.Add(root.Data);
                Inorder2(root.RC);
            }
            return ptr2;
        }
        public bool IsBST(Node root)
        {
            List<int> temp = Inorder(root);
            for (int i = 1; i < temp.Count; i++)
            {
                if (temp[i] < temp[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        public int KthBiggestNum(Node root, int k)
        {
            List<int> temp = Inorder(root);
            int counter = 0;
            int max = temp[0];
            for (int i = 1; i < temp.Count; i++)
            {
                if (temp[i]>max)
                {
                    max = temp[i];
                    counter += 1;
                }
            }
            return temp[counter];
        }
        public void PrintSortedBST(Node root)
        {
            List<int> temp = Inorder(root);
            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i]);
            }
        }
        public BST Merge(Node root1, Node root2)
        {

            List<int> temp1 = Inorder(root1);
            List<int> temp2 = Inorder2(root2);
            List<int> result = new List<int>();
            BST tree = new BST();
            int i = 0;
            int j = 0;
            while (i < temp1.Count && j < temp2.Count)
            {
                if (temp1[i] > temp2[j])
                {
                    result.Add(temp2[j]);
                    j = j + 1;
                }
                else
                {
                    result.Add(temp1[i]);
                    i = i + 1;
                }
            }
            while (i < temp1.Count)
            {
                result.Add(temp1[i]);
                i = i + 1;
            }
            while (j < temp2.Count)
            {
                result.Add(temp2[j]);
                j = j + 1;
            }

            for (int m = 0; m < result.Count; m++)
            {
                tree.Insert(result[m]);
            }
            return tree;
        }
        public void PostorderTraversal(Node root)
        {
            if (root == null)
                return;

            PostorderTraversal(root.LC);

            PostorderTraversal(root.RC);

            Console.WriteLine(root.Data);
        }
        public void InorderWalk(Node root)
        {
            if (root != null)
            {
                InorderWalk(root.LC);
                Console.WriteLine(root.Data);
                InorderWalk(root.RC);
            }
        }
        public void inorderTraversal(Node root, List<int> arr)
        {
            if (root == null)
                return;

            inorderTraversal(root.LC, arr);

            arr.Add(root.Data);

            inorderTraversal(root.RC, arr);
        }
        public void BSTToMaxHeap(Node root, List<int> arr)//LRV
        {
            if (root == null)
                return;

            BSTToMaxHeap(root.LC, arr);

            BSTToMaxHeap(root.RC, arr);

            root.Data = arr[z++];
        }
        public void ConvertToMaxHeap(Node root)
        {
            List<int> arr = new List<int>();
            inorderTraversal(root, arr);
            BSTToMaxHeap(root, arr);
        }

    }
}
