using System;

namespace DataStructureCore
{
    public class Stack<T>
    {
        private Node<T> head;

        public Stack()
        {
            this.head = null;
        }

        public void Push(T x)
        {
            Node<T> temp = new Node<T>(x);
            temp.SetNext(head);
            head = temp;
        }

        public T Pop()
        {
            T x = head.GetValue();
            head = head.GetNext();
            return x;
        }

        public T Top()
        {
            return head.GetValue();
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public override string ToString()
        {
            if (!IsEmpty())
            {
                string temp = head.ToString();
                return "top -> " + temp.Substring(0, temp.Length - 4) + " bottom";
            }
            return null;
        }


    }
}
