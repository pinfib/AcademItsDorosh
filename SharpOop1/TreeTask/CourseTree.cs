using System;
using System.Collections.Generic;
using System.Text;

namespace Academits.Dorosh.TreeTask
{
    class CourseTree<T> where T : IComparable<T>

    {
        private TreeNode<T> root;


        private int length;

        //public int Count
        //{
        //    get
        //    {
        //        return length;
        //    }
        //    set
        //    {
        //        if (value >= 0)
        //        {
        //            length = value;
        //        }
        //    }
        //}

        public CourseTree()
        {
        }

        public CourseTree(TreeNode<T> node)
        {
            root = node;
        }

        public void Add(T data)
        {
            TreeNode<T> current = root;

            while (true)
            {
                if (data.CompareTo(current.Data) < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new TreeNode<T>(data);

                        return;
                    }

                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new TreeNode<T>(data);

                        return;
                    }

                    current = current.Right;
                }
            }
        }

        public bool IsContains(T data)
        {
            TreeNode<T> current = root;

            while (true)
            {
                if (data.CompareTo(current.Data) == 0)
                {
                    return true;
                }

                if (data.CompareTo(current.Data) < 0)
                {
                    if (current.Left == null)
                    {
                        return false;
                    }

                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        return false;
                    }

                    current = current.Right;
                }
            }
        }

        public bool Remove(T data)
        {
            if(IsContains(data))
            {
                TreeNode<T> current = root;
                TreeNode<T> previous = root;

                // удаление корня

                while (true)
                {
                    if (data.CompareTo(current.Data) == 0)
                    {
                        break;
                    }

                    if (data.CompareTo(current.Data) < 0)
                    {
                        previous = current;
                        current = current.Left;
                    }
                    else
                    {
                        previous = current;
                        current = current.Right;
                    }
                }

                // удаление узла
            }
            
            throw new Exception();
        }

        public int GetElementsCount()
        {
            throw new Exception();
        }

        //  обход в ширину

        //  обход в глубину с рекурсией

        //  обход в глубину без рекурсии



        private string ToString(TreeNode<T> node, List<StringBuilder> list, int level)
        {
            int stringLength = level * 4 + 3;

            StringBuilder stringLeft = new StringBuilder();
            stringLeft.Insert(0, " ", stringLength);

            StringBuilder stringRight = new StringBuilder();
            stringRight.Insert(0, " ", stringLength);

            if (node.Right != null)
            {
                list.Insert(list.Count, stringRight.AppendFormat("[R]: {0}", ToString(node.Right, list, level + 1)));
            }

            if (node.Left != null)
            {
                list.Insert(list.Count, stringLeft.AppendFormat("[L]: {0}", ToString(node.Left, list, level + 1)));
            }

            return node.Data.ToString();
        }

        public override string ToString()
        {
            List<StringBuilder> list = new List<StringBuilder>
            {
                new StringBuilder("[root]: ")
            };

            list[0].Append(ToString(root, list, 1));

            StringBuilder tmpString = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                tmpString.AppendLine(list[i].ToString());
            }

            return tmpString.ToString();
        }
    }
}