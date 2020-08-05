using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_1
{   /// <Summary>
    /// Class that represents Linked List.
    /// </Summary>
    public class LinkedList
    {
        private Node _head;
        /// <Summary>
        /// Mehtod to add new element in Linked List
        /// </Summary>
        public void Add(Object data)
        {
            if (_head == null)
            {
                _head = new Node();
                _head.data = data;
            }
            else
            {
                Node thisNode = new Node();
                thisNode.data = data;

                Node last = _head;
                while(last.next != null)
                {
                    last = last.next;
                }

                last.next = thisNode;
            }  
        }

        public override string ToString()
        {
            string output = "";
            Node each = _head;
            while (each != null)
            {
                if(each.next == null)
                {
                    output += each.data.ToString();

                }
                else
                {
                    output += each.data.ToString() + ",";
                }
                each = each.next;
            }
            return output;
        }
        /// <Summary>
        /// Function to check if Linked List is Empty
        /// </Summary>
        public bool isEmpty()
        {
            return _head == null;
        }

    
    }
    /// <Summary>
    /// Class that represents element of the Linked List with the data and link
    /// to next element.
    /// </Summary>
    internal class Node
    {
        public Node next;
        public Object data;
    }
}
