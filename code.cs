using System;
using System.Collections;

namespace Assignment
{
    public class SupportCenter
    {
        public class Customer
        {
            public int Id { get; set; }
            public DateTime IssueCreated { get; set; }
            public bool IssueClosed { get; set; }
            public int IssueSeverity { get; set; }

            public Customer()
            {
            }

            public Customer(int SubscriptionID, DateTime DateCreated, bool IsClosed, int Severity)
            {
                Id = SubscriptionID;
                IssueCreated = DateCreated;
                IssueClosed = IsClosed;
                IssueSeverity = Severity;
            }


            public void PrintRecord()
            {
                Console.WriteLine("Client Id: " + Id);
                Console.WriteLine("Severity " + IssueSeverity);
                Console.WriteLine("Created " + IssueCreated);
                Console.WriteLine("Closed " + IssueClosed);
                Console.WriteLine("\n******************************");
            }
        }

        public class Node
        {
            public Customer CustomerNode { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node()
            {
            }

            public Node(Customer CustomerRecord)
            {
                this.CustomerNode = new Customer(CustomerRecord.Id, CustomerRecord.IssueCreated, CustomerRecord.IssueClosed,
                                                                CustomerRecord.IssueSeverity);
            }
        }

        public class BinaryTree
        {
            private Node Root;

            public BinaryTree()
            {
                Root = null;
            }

            public void Insert(Customer Cust)
            {
                Node newNode = new Node();
                newNode.CustomerNode = Cust;
                if (Root == null)
                    Root = newNode;
                else
                {
                    Node CurrentNode = Root;
                    Node ParentNode;
                    while (true)
                    {
                        ParentNode = CurrentNode;
                        if (Cust.IssueCreated < CurrentNode.CustomerNode.IssueCreated)
                        {
                            CurrentNode = CurrentNode.Left;
                            if (CurrentNode == null)
                            {
                                ParentNode.Left = newNode;
                                return;
                            }
                        }
                        else
                        {
                            CurrentNode = CurrentNode.Right;
                            if (CurrentNode == null)
                            {
                                ParentNode.Right = newNode;
                                return;
                            }
                        }
                    }
                }
            }

            public void Delete(Customer Item)
            {
                Root = DeleteNode(Root, Item);
            }

            /* A recursive function to insert a new key in BST */
            Node DeleteNode(Node RootNode, Customer Item)
            {
                /* Base Case: If the tree is empty */
                if (RootNode == null) return RootNode;

                /* Otherwise, recur down the tree */
                if (Item.Id < RootNode.CustomerNode.Id)
                    RootNode.Left = DeleteNode(RootNode.Left, Item);
                else if (Item.Id > RootNode.CustomerNode.Id)
                    RootNode.Right = DeleteNode(RootNode.Right, Item);

                // if key is same as root's key, then This is the node to be deleted  
                else
                {
                    // node with only one child or no child  
                    if (RootNode.Left == null)
                        return RootNode.Right;
                    else if (RootNode.Right == null)
                        return RootNode.Left;

                    // node with two children: Get the inorder successor (smallest in the right subtree)  
                    RootNode.CustomerNode.Id = minValue(RootNode.Right);

                    // Delete the inorder successor  
                    RootNode.Right = DeleteNode(RootNode.Right, RootNode.CustomerNode);
                }
                return RootNode;
            }

            int minValue(Node root)
            {
                int minv = root.CustomerNode.Id;
                while (root.Left != null)
                {
                    minv = root.Left.CustomerNode.Id;
                    root = root.Left;
                }
                return minv;
            }


            private void PrintTree(Node root)
            {
                if (root == null) return;

                PrintTree(root.Left);
                Console.WriteLine("Client Id: " + root.CustomerNode.Id);
                Console.WriteLine("Severity " + root.CustomerNode.IssueSeverity);
                Console.WriteLine("Created " + root.CustomerNode.IssueCreated);
                Console.WriteLine("Closed " + root.CustomerNode.IssueClosed);
                Console.WriteLine("\n");

                PrintTree(root.Right);
            }
            public void DisplayTree()
            {
                Console.WriteLine("Items in the binary tree");
                Console.WriteLine("========================");
                PrintTree(Root);
            }

        }

        public static void DisplayQueue(Queue myQ)
        {
            Customer item;

            Console.WriteLine("Items in the Queue");
            Console.WriteLine("===================");
            foreach (Object obj in myQ)
            {
                item = (Customer)obj;
                Console.WriteLine("Client Id: " + item.Id);
                Console.WriteLine("Severity " + item.IssueCreated);
                Console.WriteLine("Created " + item.IssueSeverity);
                Console.WriteLine("Closed " + item.IssueClosed);
                Console.WriteLine();
            }
        }
        public static void DisplayStack(Stack myStack)
        {
            Console.WriteLine("Items in the Stack");
            Console.WriteLine("===================");
            for (int i = 0; i < myStack.Count; i++)
            {
                Customer item = (Customer)myStack.Peek();
                Console.WriteLine("Client Id: " + item.Id);
                Console.WriteLine("Created " + item.IssueCreated);
                Console.WriteLine("Sevrity " + item.IssueSeverity);
                Console.WriteLine("Closed " + item.IssueClosed);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            BinaryTree bst = new BinaryTree();
            Queue myQ = new Queue();
            Stack mystack = new Stack();

            // Create customer record
            Customer MyCustomer1 = new Customer(100, new DateTime(2020, 5, 1, 8, 30, 52), false, 2);
            Customer MyCustomer2 = new Customer(200, new DateTime(2020, 6, 1, 9, 31, 52), false, 2);
            Customer MyCustomer3 = new Customer(300, new DateTime(2020, 7, 1, 10, 32, 52), false, 1);
            Customer MyCustomer4 = new Customer(400, new DateTime(2020, 8, 1, 11, 33, 52), false, 2);
            Customer MyCustomer5 = new Customer(500, new DateTime(2020, 10, 1, 13, 35, 52), false, 1);

            // Severity 1 cases are added to Queue (FIFO)
            myQ.Enqueue(MyCustomer3);
            myQ.Enqueue(MyCustomer5);

            // Severity 2 cases are added to binary tree
            bst.Insert(MyCustomer1);
            bst.Insert(MyCustomer2);
            bst.Insert(MyCustomer4);

            // Display items in the binary tree and queue
            bst.DisplayTree();
            DisplayQueue(myQ);

            // Mark an item closed in the binary tree and remove it from binary tree
            // Add the deleted item to the stack
            MyCustomer2.IssueClosed = true;
            bst.Delete(MyCustomer2);
            mystack.Push(MyCustomer2);


            // Mark an item closed in the queue (FIFO)
            // Remove the case from the Queue (FIFO)
            // Add the dequeued item to the stack
            MyCustomer3.IssueClosed = true;
            myQ.Dequeue();
            mystack.Push(MyCustomer3);

            // Print binary tree, queue, and stack
            bst.DisplayTree();
            DisplayQueue(myQ);
            DisplayStack(mystack);
            Console.ReadKey();
        }
    }
}
