﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace SinglyLinkedLists
{
    public class SinglyLinkedListNode : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<SinglyLinkedListNode> allNodes = new List<SinglyLinkedListNode>();

        // READ: http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        private SinglyLinkedListNode _next;

        public SinglyLinkedListNode Next
        {
            get { return this._next; }
            set {
                if(value == this)
            {
                throw new ArgumentException();
            }
             this._next = value;
        }
    }

        public string _value;
        public string Value 
        {
            get { return _value; }
            set { _value = value; }
        }

      




        public static bool operator <(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            int test = string.Compare(node1.Value, node2.Value);
            if (test == -1) return true;
            return false;
            // This implementation is provided for your convenience.
            //return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            int test = string.Compare(node1.Value, node2.Value);
            if (test == 1) return true;
            return false;
            // This implementation is provided for your convenience.
            //return node1.CompareTo(node2) > 0;
        }

        public SinglyLinkedListNode(string value) // Constructor
        {
            Value = value;
            Next = null;
            //throw new NotImplementedException();
            // Used by the visualizer:
            allNodes.Add(this);
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx
        public int CompareTo(object obj)
        {
            //if(this.Value < obj.value.ToString()) { return -1}
            // return  CompareTo(obj) < 0;
            throw new NotImplementedException();

            //Brian Unsucsessful attempt 03142016
            //if (obj == null) return 1;

            //SinglyLinkedListNode othernode = obj as SinglyLinkedListNode;
            //if (othernode != null)
            //    return this.CompareTo(othernode);
            //else
            //    throw new ArgumentException("Object is not a SinglyLinkedListNode");
        }

        public bool IsLast()
        {
            return Next == null;
            // throw new NotImplementedException();
        }

        public override string ToString()
        {           
                return this.Value;           
        }

        public override bool Equals(object obj)
        {
            if (obj is SinglyLinkedListNode) // if a node object is passed in
            {
                var node = (SinglyLinkedListNode)obj;
                return this.Value == node.Value;
            }
            else { return false; }            
        }

        //public override object

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void AddLast(string value)
        {
            if (Next == null)
            {
                Next = new SinglyLinkedListNode(value);
            }
            else
            {
                Next.AddLast(value);
            }
        }
    }
}
