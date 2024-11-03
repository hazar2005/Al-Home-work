using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class LinkedList<T>
    {
        private Node<T> head;

        public LinkedList()
        {
            head = null;
        }

        public void Append(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
                return;
            }
            Node<T> last = head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Next = newNode;
        }

        public void Prepend(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = head;
            head = newNode;
        }

        public void DeleteWithValue(T data)
        {
            if (head == null)
                return;

            if (head.Data.Equals(data))
            {
                head = head.Next;
                return;
            }

            Node<T> current = head;
            while (current.Next != null && !current.Next.Data.Equals(data))
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }

        public void DeleteAtPosition(int position)
        {
            if (head == null)
                return;

            Node<T> temp = head;

            if (position == 0)
            {
                head = temp.Next;
                return;
            }

            for (int i = 0; temp != null && i < position - 1; i++)
            {
                temp = temp.Next;
            }

            if (temp == null || temp.Next == null)
                return;

            temp.Next = temp.Next.Next;
        }

        public void DeleteAtEnd()
        {
            if (head == null)
                return;

            if (head.Next == null)
            {
                head = null;
                return;
            }

            Node<T> secondLast = head;
            while (secondLast.Next.Next != null)
            {
                secondLast = secondLast.Next;
            }

            secondLast.Next = null;
        }

        public void PrintList()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            LinkedList<int> ll = new LinkedList<int>();
            ll.Append(10);
            ll.Append(20);
            ll.Prepend(5);
            ll.Append(30);
            ll.PrintList();
            Console.WriteLine("After deletion:");
            ll.DeleteWithValue(20);
            ll.PrintList();
        }
    }

}
