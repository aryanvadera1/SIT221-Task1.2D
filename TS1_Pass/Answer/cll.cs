using System;

namespace CircularSinglyLinkedListNamespace
{
    public class CircularSinglyLinkedList<T>
    {
        private class Node<K> : INode<K>
        {
            public K Value { get; set; }
            public Node<K> Next { get; set; }

            public Node(K value)
            {
                Value = value;
                Next = null;
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        private Node<T> head;
        private Node<T> tail;
        private int count;

        public CircularSinglyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        // Your task starts here and is to implement all these functions below
        // Sample implementation has been given as the answer

        public INode<T> First => head as INode<T>;
        public INode<T> Last => tail as INode<T>;
        public int Count => count;

        public INode<T> AddFirst(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (count == 0)
            {
                head = newNode;
                tail = newNode;
                newNode.Next = head;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
                tail.Next = head;
            }
            count++;
            return newNode as INode<T>;
        }

        public INode<T> AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (count == 0)
            {
                head = newNode;
                tail = newNode;
                newNode.Next = head;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
                tail.Next = head;
            }
            count++;
            return newNode as INode<T>;
        }

        public INode<T> AddAfter(INode<T> node, T value)
        {
            Node<T> currentNode = node as Node<T>;
            if (currentNode == null)
                throw new ArgumentNullException(nameof(node));

            Node<T> newNode = new Node<T>(value);
            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;

            if (currentNode == tail)
                tail = newNode;

            count++;
            return newNode as INode<T>;
        }

        public INode<T> Find(T value)
        {
            Node<T> current = head;
            for (int i = 0; i < count; i++)
            {
                if (current.Value.Equals(value))
                    return current as INode<T>;
                current = current.Next;
            }
            return null;
        }

        public void Remove(INode<T> node)
        {
            Node<T> currentNode = node as Node<T>;
            if (currentNode == null)
                throw new ArgumentNullException(nameof(node));

            if (count == 0)
                throw new InvalidOperationException("The list is empty.");

            Node<T> previous = null;
            Node<T> current = head;

            do
            {
                if (current == currentNode)
                {
                    if (previous == null)
                    {
                        head = head.Next;
                        tail.Next = head;
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current == tail)
                            tail = previous;
                    }
                    count--;
                    return;
                }
                previous = current;
                current = current.Next;
            } while (current != head);

            throw new InvalidOperationException("The node does not exist in the list.");
        }

        public void RemoveFirst()
        {
            if (count == 0)
                throw new InvalidOperationException("The list is empty.");

            head = head.Next;
            tail.Next = head;
            count--;
        }

        public void RemoveLast()
        {
            if (count == 0)
                throw new InvalidOperationException("The list is empty.");

            if (count == 1)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current.Next = head;
                tail = current;
            }
            count--;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public override string ToString()
        {
            if (count == 0)
                return "[]";

            Node<T> current = head;
            string result = "[";

            do
            {
                result += current.Value.ToString() + " -> ";
                current = current.Next;
            } while (current != head);

            result = result.Substring(0, result.Length - 4);
            result += "]";

            return result;
        }
    }
}
