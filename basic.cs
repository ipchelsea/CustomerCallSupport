using System;
using System.Collections;
using System.Collections.Generic;
using static MajorAssignment3.Program;

namespace MajorAssignment3
{

    class Program
    {
        public class ListNode
        {
            public int data;
            public ListNode next;
            public ListNode(int d)
            {
                data = d;
                next = null;
            }
        }

        // A binary tree node 
        public class BinaryTreeNode
        {
            public int data;
            public BinaryTreeNode left, right = null;
            public BinaryTreeNode(int data)
            {
                this.data = data;
                left = right = null;
            }
        }

        public class BinaryTree
        {
            ListNode head;
            BinaryTreeNode root;

            // Function to insert a node at  
            // the beginning of the Linked List 
            void push(int new_data)
            {
                // allocate node and assign data 
                ListNode new_node = new ListNode(new_data);

                // link the old list off the new node 
                new_node.next = head;

                // move the head to point to the new node 
                head = new_node;
            }

            // converts a given linked list representing a  
            // complete binary tree into the linked  
            // representation of binary tree. 
            BinaryTreeNode convertList2Binary(BinaryTreeNode node)
            {
                // queue to store the parent nodes 
                Queue<BinaryTreeNode> q =
                            new Queue<BinaryTreeNode>();

                // Base Case 
                if (head == null)
                {
                    node = null;
                    return null;
                }

                // 1.) The first node is always the root node, and 
                //     add it to the queue 
                node = new BinaryTreeNode(head.data);
                q.Enqueue(node);

                // advance the pointer to the next node 
                head = head.next;

                // until the end of linked list is reached, 
                //  do the following steps 
                while (head != null)
                {
                    // 2.a) take the parent node from the q and  
                    //     remove it from q 
                    BinaryTreeNode parent = q.Peek();
                    BinaryTreeNode pp = q.Dequeue();

                    // 2.c) take next two nodes from the linked list. 
                    // We will add them as children of the current  
                    // parent node in step 2.b. Push them into the 
                    // queue so that they will be parents to the  
                    // future nodes 
                    BinaryTreeNode leftChild = null, rightChild = null;

                    leftChild = new BinaryTreeNode(head.data);
                    q.Enqueue(leftChild);
                    head = head.next;

                    if (head != null)
                    {
                        rightChild = new BinaryTreeNode(head.data);
                        q.Enqueue(rightChild);
                        head = head.next;
                    }

                    // 2.b) assign the left and right children of 
                    //     parent 
                    parent.left = leftChild;
                    parent.right = rightChild;
                }
                Console.WriteLine();

                return node;

            }

            void casecreated(int a, int b, DateTime created, Boolean set)
            {
                int ClientID = a;
                int Severity = b;
                DateTime create = created;
                Boolean closed = set;

                Console.WriteLine("Client ID: " + ClientID);
                Console.WriteLine("Severity: " + Severity);
                Console.WriteLine("Created: " + create);
                Console.WriteLine("Closed: " + closed);
                Console.WriteLine();
            }


            // Utility function to traverse the binary tree  
            // after conversion 
            void inorderTraversal(BinaryTreeNode node)
            {
                if (node != null)
                {
                    inorderTraversal(node.left);
                    Console.Write(node.data + " ");
                    inorderTraversal(node.right);
                }
            }


            public virtual void printLevelOrder()
            {
                int h = height(root);
                int i;
                for (i = 1; i <= h; i++)
                {
                    printGivenLevel(root, i);
                }
            }

            /* Compute the "height" of a tree -- 
            the number of nodes along the longest 
            path from the root node down to the
            farthest leaf node.*/
            public virtual int height(BinaryTreeNode root)
            {
                if (root == null)
                {
                    return 0;
                }
                else
                {
                    /* compute height of each subtree */
                    int lheight = height(root.left);
                    int rheight = height(root.right);

                    /* use the larger one */
                    if (lheight > rheight)
                    {
                        return (lheight + 1);
                    }
                    else
                    {
                        return (rheight + 1);
                    }
                }
            }

            /* Print nodes at the given level */
            public virtual void printGivenLevel(BinaryTreeNode root,
                                                int level)
            {
                if (root == null)
                {
                    return;
                }
                if (level == 1)
                {
                    Console.Write(root.data + " ");
                }
                else if (level > 1)
                {
                    printGivenLevel(root.left, level - 1);
                    printGivenLevel(root.right, level - 1);
                }
            }

            void casecreatedinqueue(int a, int b, DateTime created, Boolean set)
            {
                int ClientID = a;
                int Severity = b;
                DateTime create = created;
                Boolean closed = set;

                Console.WriteLine("Client ID: ");
                Console.WriteLine("Severity: " + Severity);
                Console.WriteLine("Created: " + create);
                Console.WriteLine("Closed: " + closed);
                Console.WriteLine();
            }

            static void printStack(Stack s, int b, DateTime created, Boolean set)
            {
                int Severity = b;
                DateTime create = created;
                Boolean closed = set;

                foreach (Object obj in s)
                {
                    Console.WriteLine("Client ID: " + obj + " ");
                    Console.WriteLine("Severity: " + Severity + " ");
                    Console.WriteLine("Created: " + create + " ");
                    Console.WriteLine("Closed: " + closed + " ");
                }
                Console.WriteLine();
            }


            static void Main(string[] args)
            {


                static void printSorted(int[] arr, int start,int end)
                {
                    if (start > end)
                        return;

                    // print left subtree 
                    printSorted(arr, start * 2 + 1, end);

                    // print root 
                    Console.Write(arr[start] + " ");

                    // print right subtree 
                    printSorted(arr, start * 2 + 2, end);
                }

                DateTime date1 = new DateTime(2020, 7, 1, 10, 32, 52);

                DateTime date2 = new DateTime(2020, 6, 1, 7, 50, 0);
                //   casecreated(200, 2, date2, false);
                DateTime date3 = new DateTime(2020, 5, 1, 8, 32, 52);
                //    casecreated(100, 2, date3, false);
                DateTime date4 = new DateTime(2020, 7, 1, 9, 47, 23);
                //   casecreated(400, 2, date4, false);
                DateTime date5 = new DateTime(2020, 10, 1, 1, 35, 52);

                //Queue queue = new Queue(); //to store severity cases 1
                Queue my_queue = new Queue();
              
                //my_queue.casecreated(300, 1, date1, true);
                //my_queue.Enqueue(500);
                
                // "Pop" items from the queue in FIFO order

                //my_stack.casecreated(my_stack.Peek, 1, date1, true);
                //my_queue.casecreated(my_queue.Dequeue(), 2, date5, true);

                BinaryTree tree = new BinaryTree(); //to store severity cases 2

                /* Last node of Linked List */
                tree.push(100);
                tree.casecreated(100, 2, date3, false);
                tree.push(200);
                tree.casecreated(200, 2, date2, false);
                tree.push(400);
                tree.casecreated(400, 2, date4, false);

                /* First node of Linked List */

                BinaryTreeNode node = tree.convertList2Binary(tree.root);

                //Console.WriteLine("Inorder Traversal of the" +
                                //" constructed Binary Tree is:");
                //tree.inorderTraversal(node);
                /* Last node of Linked List */

                Stack my_stack = new Stack();

                my_stack.Push(300);
                //Console.WriteLine("Stack elements are...");
                printStack(my_stack, 2, date1, true);

                // Print inoder traversal of the BS
                Console.ReadKey();
            }
        }
    }
}

/*
using System;

namespace classes
{
    public class CustomerRecord
    {
        public int ClientID { get; }
        public string Owner { get; set; }
        public Boolean IssueClosed { get; }
        public int Severity { get;  }

        public DateTime Date { get; }

        public void MakeDeposit(int amount, DateTime date, string note)
        {
        }
    }
}*/
