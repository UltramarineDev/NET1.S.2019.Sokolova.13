using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsManipulations
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private class Node<T>
        {
            public Node<T> leftChild;//?
            public Node<T> rightChild;//?
            public T Value { get; private set; }

            public Node(T value)//?
            {
                Value = value;
            }

        }
        
        private Node<T> head;
        public int CountOfNodes { get; private set; }
        private IComparer<T> comparer;

        #region Constructors
        public BinarySearchTree(IEnumerable<T> arrayOfValues, IComparer<T> comparer)
        {
            if (comparer == null)
            {
                if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
                {
                    this.comparer = Comparer<T>.Default;
                }

                if (this.comparer == null)
                {
                    throw new InvalidOperationException("Default comparer is not found.");
                }
            }
            else
            {
                this.comparer = comparer;
            }

            if (arrayOfValues != null)
            {
                foreach (var value in arrayOfValues)
                {
                    Add(value);
                }
            }
        }

        public BinarySearchTree(IComparer<T> comparer) : this(null, comparer) { }

        public BinarySearchTree(IEnumerable<T> arrayOfValues) : this(arrayOfValues, null) { }

        public BinarySearchTree() : this(null, null) { }
        #endregion

        public void Add(T value)//add range!
        {
            if (head == null)
            {
                head = new Node<T>(value);
            }
            else
            {
                AddNode(head, value);
            }

            CountOfNodes++;
        }

        public void AddRange(IEnumerable<T> values)
        {
            if(values == null)
            {
                throw new ArgumentNullException("Values can not be null.", nameof(values));
            }

            foreach(var value in values)
            {
                Add(value);
            }
        }

        private void AddNode(Node<T> node, T value)
        {
            if (comparer.Compare(value, node.Value) < 0)
            {
                if (node.leftChild == null)
                {
                    node.leftChild = new Node<T>(value);
                }
                else
                {
                    AddNode(node.leftChild, value);
                }
            }
            else
            {
                if (node.rightChild == null)
                {
                    node.rightChild = new Node<T>(value);
                }
                else
                {
                    AddNode(node.rightChild, value);
                }
            }
        }

        public void Clear()
        {
            head = null;
            CountOfNodes = 0;
        }

        public bool Contains(T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (comparer.Compare(value, current.Value) == 0)
                {
                    return true;
                }

                if (comparer.Compare(value, current.Value) > 0)
                {
                    current = current.rightChild;
                }
                else
                {
                    current = current.leftChild;
                }
            }

            return false;
        }

        public IEnumerable<T> Preorder()
        => PreorderImplement(head);

        public IEnumerable<T> Postorder()
        => PostorderImplement(head);

        public IEnumerable<T> Inorder()
        => InorderImplement(head);

        private IEnumerable<T> PreorderImplement(Node<T> node)
        {
            yield return node.Value;

            if (node.leftChild != null)
            {
                foreach (var item in PreorderImplement(node.leftChild))
                {
                    yield return item;

                }
            }

            if (node.rightChild != null)
            {
                foreach (var item in PreorderImplement(node.rightChild))
                {
                    yield return item;

                }
            }
        }

        private IEnumerable<T> PostorderImplement(Node<T> node)
        {
            if (node.leftChild != null)
            {
                foreach (var item in PostorderImplement(node.leftChild))
                {
                    yield return item;

                }
            }

            if (node.rightChild != null)
            {
                foreach (var item in PostorderImplement(node.rightChild))
                {
                    yield return item;

                }
            }

            yield return node.Value;
        }

        private IEnumerable<T> InorderImplement(Node<T> node)
        {
            if (node.leftChild != null)
            {
                foreach (var item in InorderImplement(node.leftChild))
                {
                    yield return item;

                }
            }

            yield return node.Value;

            if (node.rightChild != null)
            {
                foreach (var item in InorderImplement(node.rightChild))
                {
                    yield return item;

                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        => Inorder().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}
