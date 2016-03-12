using System;

namespace Lesson03HomeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode tree = CreateTree();

            bool contains = tree.Contains(10);
            if (!contains)
                throw new Exception("Contains is false.");

            TreeNode find = tree.Find(10);
            if (find == null)
                throw new Exception("Contains is true.");

            bool remove = tree.Remove(10);
            if (!remove)
                throw new Exception("Remove is false.");

            contains = tree.Contains(10);
            if (contains)
                throw new Exception("Contains is true, but item was removed.");

            find = tree.Find(10);
            if (find != null)
                throw new Exception("Item was removed.");
        }


        private static TreeNode CreateTree()
        {
            // Kořen stromu
            TreeNode root = new TreeNode(-1);

            for (int i = 0; i < 20; i++)
            {
                root.Add(i);
            }

            return root;
        }
    }
}
