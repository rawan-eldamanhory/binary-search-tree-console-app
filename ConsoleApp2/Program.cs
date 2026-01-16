using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public class Node
        {
            public int data;
            public Node left;
            public Node right;

            public Node(int value)
            {
                data = value;
                left = null;
                right = null;
            }
        }

        public class BST
        {
            public Node root;

            public BST()
            {
                root = null;
            }

            //insertion
            Node insert(Node r,int item)
            {
                if (r == null)
                {
                    Node newnode = new Node(item);
                    r = newnode;
                }
                else if(item < r.data)
                {
                    r.left = insert(r.left, item);
                }
                else
                {
                    r.right = insert(r.right, item);
                }
                return r;
            }

            public void insert(int item)
            {
                root=insert(root, item);
            }

            public void inorder(Node r)   // left > root > right
            {
                if (r == null)
                    return;
                inorder(r.left);
                Console.WriteLine(r.data);
                inorder(r.right);
            }

            public void preorder(Node r)  // root > left > right
            {
                if (r == null)
                    return;
                Console.WriteLine(r.data);
                preorder(r.left);
                preorder(r.right);
            }

            public void postorder(Node r)  // left > right > root
            {
                if (r == null)
                    return;
                postorder(r.left);
                postorder(r.right);
                Console.WriteLine(r.data);
            }

            //searching
            Node Search(Node r, int key)
            {
                if (r == null)
                    return null;
                else if (r.data == key)
                    return r;
                else if (key < r.data)
                    return Search(r.left, key);
                else
                    return Search(r.right, key);
            }

            public bool Search(int key)
            {
                Node result = Search(root, key);
                if (result == null)
                    return false;
                else
                    return true;
            }

            public Node FindMin(Node r)
            {
                if (r == null)
                    return null;
                else if (r.left == null)
                    return r;
                else
                    return FindMin(r.left);
            }

            public Node FindMax(Node r)
            {
                if (r == null)
                    return null;
                else if (r.right == null)
                    return r;
                else
                    return FindMax(r.right);
            }

            //deletion
            public Node Delete(Node r, int key)
            {
                if (r == null)
                    return null;
                if (key < r.data)
                    r.left = Delete(r.left, key);
                else if (key > r.data)
                    r.right=Delete(r.right, key);
                else
                {
                    if (r.left == null && r.right == null)  //leaf node
                        r = null;
                    else if(r.left!=null && r.right == null)  // one child on the left
                    {
                        //r.data = r.left.data;
                        //r.left = null;
                        return r.left;
                    }
                    else if (r.left == null && r.right != null)  // one child on the right
                    {
                        //r.data = r.right.data;
                        //r.right = null;
                        return r.right;
                    }
                    else
                    {
                        Node max =FindMax(r.left);
                        r.data = max.data;
                        r.left = Delete(r.left, max.data);
                    }
                }
                return r;
            }

            //Check if tree is balanced or not
            public bool isBalanced(Node node)
            {
                int HeightOfLeftSubTree;
                int HeightOfRightSubTree; 

                if (node == null)   //tree is empty
                {
                    return true;
                }

                HeightOfLeftSubTree = height(node.left);
                HeightOfRightSubTree = height(node.right);

                if (Math.Abs(HeightOfLeftSubTree - HeightOfRightSubTree) <= 1 && isBalanced(node.left) && isBalanced(node.right))
                {
                    return true;
                }

                return false;
            }

            //get the height
            public int height(Node node)
            {
                if (node == null)    //tree is empty
                {
                    return -1;
                }

                return 1 + Math.Max(height(node.left), height(node.right));
            }
        }
        static void Main(string[] args)
        {
            BST tree = new BST();
            tree.insert(31);
            tree.insert(25);
            tree.insert(47);
            tree.insert(17);
            tree.insert(29);
            tree.insert(33);
            tree.insert(30);
           

            Console.WriteLine("Display the Tree content (inorder) : ");
            tree.inorder(tree.root);        // 10 12 15 20 45 50 55 79 90

            Console.WriteLine("Display the Tree content (preorder) : ");
            tree.preorder(tree.root);      // 45 15 10 12 20 79 55 50 90

            Console.WriteLine("Display the Tree content (postorder) : ");
            tree.postorder(tree.root);    // 12 10 20 15 50 55 90 79 45 

            int key;
            Console.WriteLine("Enter item that you want to search for : ");
            key = int.Parse(Console.ReadLine());
            if (tree.Search(key))
                Console.WriteLine("Item Found.");
            else
                Console.WriteLine("Item Not Found !");

            Console.WriteLine("Find Minimum Item : ");
            Node min = tree.FindMin(tree.root);
            if (min == null)
                Console.WriteLine("No Items Exists.");
            else
                Console.WriteLine("Minimum Item = " + min.data);

            Console.WriteLine("Find Maximum Item : ");
            Node max = tree.FindMax(tree.root);
            if (max == null)
                Console.WriteLine("No Items Exists.");
            else
                Console.WriteLine("Maximum Item = " + max.data);

            int Item;
            Console.WriteLine("Enter item that you want to delete : ");
            Item = int.Parse(Console.ReadLine());
            Node result = tree.Delete(tree.root, Item);
            Console.WriteLine("Content After Deletion (inorder) : ");
            tree.inorder(result);
            Console.WriteLine("Content After Deletion (preorder) : ");
            tree.preorder(result);
            Console.WriteLine("Content After Deletion (postorder) : ");
            tree.postorder(result);

            if (tree.isBalanced(tree.root))
            {
                Console.WriteLine("Tree is balanced");
            }
            else
            {
                Console.WriteLine("Tree is not balanced");
            }

            Console.ReadKey();
        }
    }
}
