using System;


namespace singly_linked_list
{
    //each node consist of the information part and link to the next mode

    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNote() // add a node in the list
        {
            int nim;
            string nm;
            Console.Write("\nEnter the roll number of the student : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student : ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = nim;
            newnode.name = nm;
            if (START == null || nim <= START.rollNumber)
            {
                if ((START != null) && (nim == START.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            // locate the position of the new node in the list
            Node Previous, current;
            Previous = START;
            current = START;

            while ((current != null) && (nim >= current.rollNumber))
            {
                if (nim == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                Previous = current;
                current = current.next;
            }

            //*once the above for loop is executed, prev and current are positioned in such a manner that the position for the new node *//
            newnode = current;
            Previous.next = newnode;
        }
        public void traverse()
        {
            if (listEmpty())
               Console.WriteLine("\nList is empty.\n");
            else
            {
                Console.WriteLine("\nThe records in the list are : ");
                Node CurrentNode;
                for (CurrentNode = START; CurrentNode != null;
                    CurrentNode = CurrentNode.next);

                    Console.Write(CurrentNode.rollNumber + "" + CurrentNode.name + "\n");

                Console.WriteLine();
            }
        }
        public bool delNode(int nim)
        {
            Node previous, current;
            previous = current = null;
            //check if the spisified node is present in the list or not
            if (Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            return true;
        }
    }
}