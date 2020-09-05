using System;

namespace Generics
{
    class Node<T> where T : IComparable
    {
        public Node<T> FatherLeft { get; set; } = null;
        public Node<T> FatherRight { get; set; } = null;
        public Node<T> Previous { get; set; } = null;
        public Node<T> Next { get; set; } = null;
        public Node<T> Left { get; set; } = null;
        public Node<T> Right { get; set; } = null;
        public T Value { get; set; } = default;

        public Node(T value)
        {
            Value = value;
        }
    }
}
