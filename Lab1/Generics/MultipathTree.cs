using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class MultipathTree<T> where T : IComparable
    {
        private Node<T> Root { get; set; } = null;
        private int Degree { get; set; }
        public int Count = 0;

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
                        Previous = pos,
                        FatherLeft = pos.FatherLeft,
                        FatherRight = pos.FatherRight
                    };
                    Count++;
                }
            }
            else if (value.CompareTo(pos.Value) < 0)
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
                            Next = pos,
                            FatherLeft = pos.FatherLeft,
                            FatherRight = pos.FatherRight
                        };
                        pos.Previous = pos.Previous.Next;
                    }
                    else
                    {
                        pos.Previous = new Node<T>(value)
                        {
                            Next = pos,
                            FatherLeft = pos.FatherLeft,
                            FatherRight = pos.FatherRight
                        };
                        if (pos.FatherLeft != null)
                            pos.FatherLeft.Right = pos.Previous;
                        if (pos.FatherRight != null)
                            pos.FatherRight.Left = pos.Previous;
                        if (Root == pos)
                            Root = pos.Previous;
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

        public List<T> Preorden()
        {
            if (Root != null)
            {
                List<T> path = new List<T>();
                Preorden(Root, path);
                return path;
            }
            else
                return new List<T>();
        }

        private void Preorden(Node<T> pos, List<T> path)
        {
            Node<T> aux = pos;
            while (pos != null)
            {
                path.Add(pos.Value);
                pos = pos.Next;
            }
            if (aux.Left != null)
                Preorden(aux.Left, path);
            while (aux != null)
            {
                if (aux.Right != null)
                    Preorden(aux.Right, path);
                aux = aux.Next;
            }
        }

        public List<T> Inorden()
        {
            if (Root != null)
            {
                List<T> path = new List<T>();
                Inorden(Root, path);
                return path;
            }
            else
                return new List<T>();
        }

        private void Inorden(Node<T> pos, List<T> path)
        {
            if (pos.Left != null)
                Inorden(pos.Left, path);
            while (pos != null)
            {
                path.Add(pos.Value);
                if (pos.Right != null)
                    Inorden(pos.Right, path);
                pos = pos.Next;
            }
        }

        public List<T> Postorden()
        {
            if (Root != null)
            {
                List<T> path = new List<T>();
                Postorden(Root, path);
                return path;
            }
            else
                return new List<T>();
        }

        private void Postorden(Node<T> pos, List<T> path)
        {
            Node<T> aux = pos;
            if (aux.Left != null)
                Postorden(aux.Left, path);
            while (aux != null)
            {
                if (aux.Right != null)
                    Postorden(aux.Right, path);
                aux = aux.Next;
            }
            while (pos != null)
            {
                path.Add(pos.Value);
                pos = pos.Next;
            }
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
