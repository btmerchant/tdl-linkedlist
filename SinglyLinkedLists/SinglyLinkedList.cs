﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinglyLinkedLists;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode head;
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
            // BT
            Head = null;
            // BT
        }

        public SinglyLinkedListNode Head
        {
            get { return head; }
            set { head = value; }
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            //BT
            Head = null;
            int size = values.Length;
            string[] x = new string[size];
            if (values != null)
            {
                for (int i = 0; i <= size - 1; i++)
                {
                    x[i] = values[i].ToString();
                    AddLast(x[i]);
                }
            }
            // BT
            //throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i] // This is the Indexer
        {
            // BT
            get { return this[i]; /*throw new NotImplementedException()*/}
            set { this[i] = value; /*throw new NotImplementedException()*/; }
            // BT
        }

        public void AddAfter(string existingValue, string value)
        {
            // BT
            SinglyLinkedListNode current = Head;
                while(current.Value != existingValue)
            {
                if (current == null)
                    return;
                current = current.Next;
            }
            current = current.Next;
            SinglyLinkedListNode temp = new SinglyLinkedListNode(value);
            temp = current.Next;
            current = temp;
            // BT
            //throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            // BT
            if (Head == null)
            {
                Head = new SinglyLinkedListNode(value);
            }
            else
            {
                SinglyLinkedListNode temp = new SinglyLinkedListNode(value);
                temp.Next = Head;
                Head = temp;
            }
            // BT
            //throw new NotImplementedException();
        }

        public void AddLast(string value)
        {
            // BT Looks Good!
            if(Head == null)
            {
                Head  = new SinglyLinkedListNode(value);
            }
            else
            {
               Head.AddLast(value);
            }
            // BT

           // throw new NotImplementedException();
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            // BT
            SinglyLinkedListNode current = Head;
            int count = 0;
            loop:
            if (current == null)
            {
                return count;
            }
            else
            {
                count++;
                current = current.Next;
                goto loop;
            }
            // BT

            //throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            throw new NotImplementedException();
        }

        public string First()
        {
            //BT
            SinglyLinkedListNode current = Head;
            if (current == null)
                return null;
            else
                return current.Value;
            //BT
            //throw new NotImplementedException();
        }

        public int IndexOf(string value)
        {
            //BT
            SinglyLinkedListNode current = Head;
            int x = Count();
            for (int i = 0; i < x; i++)
            {
                if (current.Value.Equals(value))
                    return i;
                current = current.Next;
            }
            return -1;
            // BT

            //throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...

        // BT returns the index of the last node
        public int LastNode()
        {
            int end = IndexOf(null);
            return end;
        }
        // BT

        public string Last()
        {           
            throw new NotImplementedException();
        }

        public void Remove(string value)
        {
            // BT
            SinglyLinkedListNode current = Head;
            int index = IndexOf(value);
            if (index == -1)
                return;
            int x = Count();

            if (index < 0 || index >= x)
                throw new  ArgumentOutOfRangeException("Size of List: " + x + "    Index: " + index);

            string result = null;

            if (index == 0)
            {
                result = current.Value;
                Head = current.Next;
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;

                result = current.Next.Value;
                current.Next = current.Next.Next;
            }
            // BT
            // throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            // BT
            SinglyLinkedListNode current = this.Head;
            int size = this.Count();
            string[] SLLArray = new string[size];
            for (int i = 0; i < size; i++)
            {
                SLLArray[i] = current.Value;
                current = current.Next;
            }
            return SLLArray;
            // BT
            // throw new NotImplementedException();
        }
    }
}
