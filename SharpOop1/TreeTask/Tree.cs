using System;
using System.Collections.Generic;
using System.Text;

namespace Academits.Dorosh.TreeTask
{
    class Tree<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;

        public int Count { get; private set; }

        public Tree()
        {
        }

        public Tree(T data)
        {
            _root = new TreeNode<T>(data);

            Count++;
        }

        private TreeNode<T> GetNextNode(TreeNode<T> current, T data)
        {
            if (data.CompareTo(current.Data) < 0)
            {
                return current.Left;
            }
            else
            {
                return current.Right;
            }
        }

        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentException($"Значение аргумента не может быть null", nameof(data));
            }

            if (_root == null)
            {
                _root = new TreeNode<T>(data);

                Count++;

                return;
            }

            TreeNode<T> current = _root;

            while (true)
            {
                if (data.CompareTo(current.Data) < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new TreeNode<T>(data);

                        Count++;

                        return;
                    }

                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new TreeNode<T>(data);

                        Count++;

                        return;
                    }

                    current = current.Right;
                }
            }
        }

        public bool IsContains(T data)
        {
            TreeNode<T> current = _root;

            while (current != null)
            {
                if (data.CompareTo(current.Data) == 0)
                {
                    return true;
                }

                current = GetNextNode(current, data);
            }

            return false;
        }

        private void ReplaceNode(TreeNode<T> parentNode, TreeNode<T> removedNode, TreeNode<T> insertNode, bool insertNodeIsSubtree)
        {
            if (parentNode == null) //удаление корня
            {
                _root = insertNode;
            }
            else
            {
                if (ReferenceEquals(parentNode.Left, removedNode))  //определить removedNode это левый или правый узел
                {
                    parentNode.Left = insertNode;
                }
                else
                {
                    parentNode.Right = insertNode;
                }
            }

            if (!insertNodeIsSubtree) //если встраиваемый узел не является поддеревом, то нужно обновить связи
            {
                insertNode.Left = removedNode.Left;
                insertNode.Right = removedNode.Right;
            }
        }

        public bool Remove(T data)
        {
            if (!IsContains(data))
            {
                return false;
            }

            TreeNode<T> removedNode = _root;
            TreeNode<T> parentRemovedNode = null;

            while (data.CompareTo(removedNode.Data) != 0)
            {
                parentRemovedNode = removedNode;
                removedNode = GetNextNode(removedNode, data);
            }

            if (removedNode.Right == null)                                  // узел с одним ребенком или без детей
            {
                ReplaceNode(parentRemovedNode, removedNode, removedNode.Left, true);

                Count--;

                return true;
            }

            if (removedNode.Left == null)                                   // узел с одним ребенком
            {
                ReplaceNode(parentRemovedNode, removedNode, removedNode.Right, true);

                Count--;

                return true;
            }

            TreeNode<T> insertNode = removedNode.Right;                             // узел с двумя детьми
            TreeNode<T> parentInsertNode = removedNode;

            while (insertNode.Left != null)                                         // находим самый левый узел в правом поддереве
            {
                parentInsertNode = insertNode;
                insertNode = insertNode.Left;
            }

            ReplaceNode(parentInsertNode, insertNode, insertNode.Right, true);     // удаляем самый левый узел, и ставим на его место его правого ребенка, если он есть
            ReplaceNode(parentRemovedNode, removedNode, insertNode, false);         // на место удаляемого элемента записываем самый левый элемент

            Count--;

            return true;
        }

        public void BreadthFirstTraversal(Action<T> action) //  обход в ширину
        {
            var queue = new Queue<TreeNode<T>>(Count);

            queue.Enqueue(_root);

            while (queue.Count != 0)
            {
                TreeNode<T> treeNode = queue.Dequeue();

                action(treeNode.Data);

                if (treeNode.Left != null)
                {
                    queue.Enqueue(treeNode.Left);
                }

                if (treeNode.Right != null)
                {
                    queue.Enqueue(treeNode.Right);
                }
            }
        }

        public void RecursiveDepthFirstTraversal(Action<T> action) // обход в глубину с рекурсией 
        {
            RecursiveDepthFirstTraversal(_root, action);
        }

        private void RecursiveDepthFirstTraversal(TreeNode<T> treeNode, Action<T> action)
        {
            action(treeNode.Data);

            if (treeNode.Left != null)
            {
                RecursiveDepthFirstTraversal(treeNode.Left, action);
            }

            if (treeNode.Right != null)
            {
                RecursiveDepthFirstTraversal(treeNode.Right, action);
            }
        }


        public void DepthFirstTraversal(Action<T> action) // обход в глубину без рекурсии
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>(Count);

            stack.Push(_root);

            while (stack.Count != 0)
            {
                TreeNode<T> treeNode = stack.Pop();

                action(treeNode.Data);

                if (treeNode.Right != null)  //положить в стек всех детей элемента в обратном порядке
                {
                    stack.Push(treeNode.Right);
                }

                if (treeNode.Left != null)
                {
                    stack.Push(treeNode.Left);
                }
            }
        }

        private string ToString(TreeNode<T> node, List<StringBuilder> list, int level)
        {
            int stringLength = level * 4 + 3;

            StringBuilder stringLeft = new StringBuilder();
            stringLeft.Insert(0, " ", stringLength);

            StringBuilder stringRight = new StringBuilder();
            stringRight.Insert(0, " ", stringLength);

            if (node.Right != null)
            {
                list.Insert(list.Count, stringRight.Append($"[R]: {ToString(node.Right, list, level + 1)}"));
            }

            if (node.Left != null)
            {
                list.Insert(list.Count, stringLeft.Append($"[L]: {ToString(node.Left, list, level + 1)}"));
            }

            return node.Data.ToString();
        }

        public override string ToString()
        {
            List<StringBuilder> list = new List<StringBuilder>(Count)
            {
                new StringBuilder("[root]: ")
            };

            if (_root == null)
            {
                list[0].Append("null");
            }
            else
            {
                list[0].Append(ToString(_root, list, 1));
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Количество элементов в дереве - {Count}");

            for (int i = 0; i < list.Count; i++)
            {
                stringBuilder.AppendLine(list[i].ToString());
            }

            return stringBuilder.ToString();
        }
    }
}