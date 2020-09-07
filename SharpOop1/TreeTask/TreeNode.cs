namespace Academits.Dorosh.TreeTask
{
    class TreeNode<T>
    {
        // private TreeNode<T>[] children;   // для небинарного дерева

        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public T Data { get; set; }

        public TreeNode(T data)
        {
            Left = null;
            Right = null;
            Data = data;
        }
        // убрать, если не нужно

        /*public TreeNode(T data, TreeNode<T> left, TreeNode<T> right)
        {
            Left = left;
            Right = right;
            Data = data;
        }*/
    }
}
