using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UAS_154;

namespace UAS_154
{
    class node
    {
        public int rollnumber;
        public string name;
        public node next;
        public node prev;
        
        
    }
}
class DoubleLikedList
{
    node START;
    public DoubleLikedList()
    {
        START = null;

    }
    public void addNode()
    {
        int rollnumber;
        string name;
        Console.Write("\nAdd number: ");
        rollnumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nAdd name:  ");
        name = Console.ReadLine();
        node newnode = new node();
        newnode.rollnumber = rollnumber;
        newnode.name = name;
        if (START == null || rollnumber <= START.rollnumber)
        {
            if ((START != null) && (rollnumber == START.rollnumber))
            {
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }
            node previous, current;
            for (current = previous = START; current != null &&
                rollnumber <= current.rollnumber; previous = current, current = current.next)
            {
                if (rollnumber == current.rollnumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers no allowed");
                    return;
                }
                newnode.next = current;
                newnode.prev = previous;

                if (current == null)
                {
                    newnode.next = null;
                    previous.next = newnode;
                    return;
                }
                current.prev = newnode;
                previous.next = newnode;
            }
            
        }
      

    }
    public bool Search(int rollnumber, ref node previous, ref node current)
    {
        for (previous = current = START; current != null &&
            rollnumber != current.rollnumber; previous = current,
            current = current.next)
        {
            return (current != null);
        }
    }
    public bool delNode(int rollnumber)
    {
        node previous, current;
        previous = current = null;
        if (Search(rollnumber, ref previous, ref current) == false)
            return false;
        if (current == START)
        {
            START = START.next;
            if (START != null)
                START.prev = null;
            return true;
        }
        if (current.next == null)
        {
            previous.next = null;
            return true;
        }
        return true;
    }
    public void travers()
    {
        if (listEmpty())
            Console.WriteLine("\nList is empty");
        else
        {
            Console.WriteLine("\nRecord in the ascending order of " +
                "roll numbers are:\n");
            node currentNode;
            for (currentNode = START; currentNode != null;
                currentNode = currentNode.next)
                Console.WriteLine(currentNode.rollnumber + " "
                    + currentNode.name + "\n");
        }
    }

    public void revtravers()
    {
        if (listEmpty())
            Console.Write("\nList is Empty");
        else
        {
            Console.WriteLine("\nRecords in the descending order of " +
                "roll numbers are:\n");
            node currentNode;
            for (currentNode = START; currentNode.next != null;
                currentNode = currentNode.next)
            {
                while (currentNode != null)
                {
                    Console.Write(currentNode.rollnumber + " "
                        + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
      
    }
    public bool listEmpty()
    {
        if (START == null)
            return true;
        else
            return false;
    }
    static void Main(string[] args)
    {
        DoubleLikedList obj = new DoubleLikedList();
        while (true)
        {
            try
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Add nomor buku");
                Console.WriteLine("2. Add judul buku");
                Console.WriteLine("3. Add nama pengarang");
                Console.WriteLine("4. Add Tahun terbit");
                Console.Write("\nEnter your choice (1-4: ");
                char ch = Convert.ToChar(Console.ReadLine());
                switch (ch)
                {
                    case '1':
                        {
                            obj.travers();
                        }
                        break;
                    case '2':
                        {
                            if (obj.listEmpty() == true)
                            {
                                Console.WriteLine("\nList is empty");
                                break;
                            }
                            node prev, curr;
                            prev = curr = null;
                            Console.Write("\nEnter the roll number whose record is to be searched: ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            if (obj.Search(num, ref prev, ref curr) == false)
                                Console.WriteLine("\nRecord not found");
                            else
                            {
                                Console.WriteLine("\nRecord found");
                                Console.WriteLine("\nRoll number: " + curr.rollnumber);
                                Console.WriteLine("\nName: " + curr.name);
                            }
                        }
                        break;
                    case '3':
                        {
                            obj.addNode();
                        }
                        break;
                    case '4':
                        return;
                    default:
                        {
                            Console.WriteLine("invalid option");
                            break;
                        }

                }
                catch (Exception e)
                { 
                    Console.WriteLine("check for the values entered. ");
                }
        }
    }
}

