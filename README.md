## Problem Statement
Create a program to manage customer support calls that a support center gets from their customers. You’ll simulate the process of getting a customer call by creating a customer record with the following information:

▪ ClientID – Integer
▪ IssueCreated – Date/Time
▪ IssueClosed – Boolean (true or false)
▪ Severity – Integer (between 1 and 2)

Your program will assign a value to the customer id field. The IssueCreated is set at the time the issue was
created.
If the severity of the is 1, add it to a queue (FIFO) in the order in which they arrive. If the severity is 2, add
it to the binary tree. Implement the binary tree using linked list. Add the item in the tree sorted by the
time they arrive (date/time). To insert or print items in the binary tree, use recursion. You should also
provide methods to print items in the stack and queue.
When a case is marked as “closed” stored them in a stack and remove the item from the binary tree or
queue.
