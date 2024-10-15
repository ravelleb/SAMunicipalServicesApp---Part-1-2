using System.Collections.Generic;
using System;

namespace SAMunicipalServicesApp
{
    public class CustomLinkedList<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;

        public CustomLinkedList()
        {
            head = null;
        }

        public void Add(T data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node(data);
            }
        }

        public IEnumerable<T> GetAll()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
