using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class MultipathTree<T> where T : IComparable
    {
        private Node<T> Root { get; set; } = null;
        private int Degree { get; set; }
        private int Count = 0;

        public MultipathTree(int degree)
        {
            Degree = degree;
        }

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
                Count++;
            }
            else
                Add(value, Root);
        }

        private void Add(T value, Node<T> pos)
        {
            while (value.CompareTo(pos.Value) > 0)
            {
                if (pos.Next != null)
                    pos = pos.Next;
                else
                    break;
            }
            if (value.CompareTo(pos.Value) > 0)
            {
                if (IsFull(pos))
                {
                    if (pos.Right == null)
                    {
                        pos.Right = new Node<T>(value)
                        {
                            FatherLeft = pos
                        };
                        Count++;
                    }
                    else
                        Add(value, pos.Right);
                }
                else
                {
                    pos.Next = new Node<T>(value)
                    {
                        Previous = pos
                    };
                    Count++;
                }
            }
            else
            {
                if (IsFull(pos))
                {
                    if (pos.Left == null)
                    {
                        pos.Left = new Node<T>(value)
                        {
                            FatherRight = pos
                        };
                        if (pos.Previous != null)
                        {
                            pos.Previous.Right = pos.Left;
                            pos.Left.FatherLeft = pos.Previous;
                        }
                        Count++;
                    }
                    else
                        Add(value, pos.Left);
                }
                else
                {
                    if (pos.Previous != null)
                    {
                        pos.Previous.Next = new Node<T>(value)
                        {
                            Previous = pos.Previous,
                            Next = pos
                        };
                        pos.Previous = pos.Previous.Next;
                    }
                    else
                    {
                        pos.Previous = new Node<T>(value)
                        {
                            Next = pos
                        };
                    }
                    Count++;
                }
            }
        }

        private bool IsFull(Node<T> pos)
        {
            int NodeCount = 1;
            Node<T> pos1 = pos.Previous;
            Node<T> pos2 = pos.Next;
            while (pos1 != null)
            {
                pos1 = pos1.Previous;
                NodeCount++;
            }
            while (pos2 != null)
            {
                pos2 = pos2.Next;
                NodeCount++;
            }
            if (NodeCount < Degree - 1)
                return false;
            else
                return true;
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public void Clear(int newDegree)
        {
            Root = null;
            Degree = newDegree;
            Count = 0;
        }
    }
}
