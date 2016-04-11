using System;
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
            Head = null;
        }

        public SinglyLinkedListNode Head
        {
            get { return head; }
            set { head = value; }
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
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
            //throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int index] // This is the Indexer
        {
            //get { return this[index]; /*throw new NotImplementedException()*/}
            get { return ElementAt(index); /*throw new NotImplementedException()*/}
            set
            {
                SinglyLinkedListNode current = Head;
                if (Head == null)
                    throw new ArgumentOutOfRangeException();
                else
                    for (int i = 0; i < index; i++)
                    {
                        current = current.Next;
                    }
                current.Value = value; /*throw new NotImplementedException()*/
            }
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode current = Head;
        loop:
            if (current == null)
                throw new ArgumentException("Not in list", "current");
            else if (current.Value == existingValue)
            {
                SinglyLinkedListNode temp = new SinglyLinkedListNode(value);
                temp.Next = current.Next;
                current.Next = temp;
                return;
            }
            else
                current = current.Next;
            goto loop;
            //throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
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
            //throw new NotImplementedException();
        }

        public void AddLast(string value)
        {
            if(Head == null)
            {
                Head  = new SinglyLinkedListNode(value);
            }
            else
            {
               Head.AddLast(value);
            }
           // throw new NotImplementedException();
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
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
            //throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            SinglyLinkedListNode current = Head;
            int size = this.Count();
            if (index > size)
                throw new ArgumentOutOfRangeException();
            if (Head == null)
                throw new ArgumentOutOfRangeException();
            else
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
            return current.Value;
            //throw new NotImplementedException();
        }

        public string First()
        {
            SinglyLinkedListNode current = Head;
            if (current == null)
                return null;
            else
                return current.Value;
            //throw new NotImplementedException();
        }

        public int IndexOf(string value)
        {
            SinglyLinkedListNode current = Head;
            int x = Count();
            for (int i = 0; i < x; i++)
            {
                if (current.Value.Equals(value))
                    return i;
                current = current.Next;
            }
            return -1;
            //throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            if (Head == null)
                return true;
            SinglyLinkedListNode current = Head;
            int size = this.Count();
            if (size == 1)
                return true;
            for(int i = 0; i < size; i++)
            {
                if (String.Compare(current.Value, current.Next.Value) > 0)
                    return false;
            }
            return true;           
            //throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...

        public int LastNode()
        {
            int end = IndexOf(null);
            return end;
        }

        public string Last()
        {
            SinglyLinkedListNode current = Head;
            int size = this.Count();
                for (int i = 0; i < size -1 ; i++)
                {
                    current = current.Next;
                }
            try
            {
                return current.Value;
            } 
            catch
            {
                return null;
            }
            //throw new NotImplementedException();
        }

        public void Remove(string value)
        {
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
            // throw new NotImplementedException();
        }

        public void Sort()
        {
            if (Head == null || Head.Next == null)
                return;
            SinglyLinkedListNode current = Head;
            string temp = "";
            int size = this.Count();
            int cycles = size;
        loop:
            for (int i = 1; i < size;) 
            {
                if (string.Compare(current.Value, current.Next.Value) > 0)
                {
                    temp = current.Value;
                    current.Value = current.Next.Value;
                    current.Next.Value = temp;                  
                }
                current = current.Next;
                size--;
            }
            cycles--;
            size = cycles;
            current = Head;
            if (cycles == 1)
                return;
            goto loop;
        }

        public string[] ToArray()
        {
            SinglyLinkedListNode current = Head;
            int size = this.Count();
            string[] SLLArray = new string[size];
            for (int i = 0; i < size; i++)
            {
                SLLArray[i] = current.Value;
                current = current.Next;
            }
            return SLLArray;
            // throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (Head == null)
                return "{ }";
            else
            {
                int size = this.Count();
                SinglyLinkedListNode current = Head;
                StringBuilder result = new StringBuilder();
                result.Append("{ ");
                //result.Append("\\");
                while (current != null)
                {
                    result.Append("\"");
                    result.Append(current.Value);
                    if (current.Next != null)
                        result.Append("\"\x2C ");
                    else
                    { 
                        result.Append("\"");
                   // if(current.Next == null)
                        //{
                        result.Append(" }");
                        // return Convert.ToString(result);
                        // }
                        // result.Append("\x2C \\");
                    }
                    current = current.Next;
                }
                return Convert.ToString(result);
            }
        }
    }
}
