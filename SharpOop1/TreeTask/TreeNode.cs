using System;

namespace Academits.Dorosh.TreeTask
{
    internal class TreeNode<T>
    {
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public T Data { get; set; }

        public TreeNode(T data)
        {
            if (data == null)
            {
                throw new ArgumentException($"Значение аргумента не может быть null", nameof(data));
            }

            Left = null;
            Right = null;
            Data = data;
        }

        public override string ToString()
        {
            if (Data != null)
            {
                return Data.ToString();
            }

            return "null";
        }
    }
}