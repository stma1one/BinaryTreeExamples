using System;
using DataStructure;
namespace BinaryTreeExamples
{
    class Program
    {
        /// <summary>
        /// פעולה המייצרת עץ בינארי של מספרים שלמים המוגרלים בטווח של מין ומקס בגובה הייט
        /// </summary>
        /// <param name="height"></param>
        /// <param name="r"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static BinNode<int> RandomCreateTree(int height, Random r, int min, int max)
        {
            if (height < 0)
                return null;
            BinNode<int> root = new BinNode<int>(r.Next(min, max + 1));
            BinNode<int> left = RandomCreateTree(height - 1, r, min, max);
            BinNode<int> right = RandomCreateTree(height - 1, r, min, max);
            root.SetLeft(left);
            root.SetRight(right);
            return root;
        }
        public static BinNode<string> CreateStringTree()
        {
            Console.WriteLine("Please enter value for Root:");
            string val = Console.ReadLine();
            //תנאי עצירה רקורסיבי
            if (val == "")
                return null;
            BinNode<string> root = new BinNode<string>(val);
            Console.WriteLine("Enter Left tree:" );
            BinNode<string> left = CreateStringTree();
            Console.WriteLine("Enter right tree:");
            BinNode<string> right = CreateStringTree();
            root.SetLeft(left);
            root.SetRight(right);
            return root;


        }

        public static void InOrderTree<T>(BinNode<T> tree)
        {
            //option 2: if(tree==null)
                     //     return;
            if(tree!=null)
            {
                InOrderTree(tree.GetLeft());
                T val = tree.GetValue();
                ///יבוא קוד שאני רוצה לבצע על הצומת.
                ///{}

                InOrderTree(tree.GetRight());

            }

        }

        public static void PreOrderTree<T>(BinNode<T> tree)
        {
            //option 2: if(tree==null)
            //     return;
            if (tree != null)
            {  
                T val = tree.GetValue();
                ///יבוא קוד שאני רוצה לבצע על הצומת.
                ///{}
                PreOrderTree(tree.GetLeft());
              

                PreOrderTree(tree.GetRight());

            }

        }
        public static void PostOrderTree<T>(BinNode<T> tree)
        {
            //option 2: if(tree==null)
            //     return;
            if (tree != null)
            {

                PostOrderTree(tree.GetLeft());


                PostOrderTree(tree.GetRight());
                T val = tree.GetValue();
                ///יבוא קוד שאני רוצה לבצע על הצומת.
                ///{}

            }
        }

            public static void PrintInOrderTree(BinNode<int> tree)
        {
            if (tree != null)
            {
                PrintInOrderTree(tree.GetLeft());
                int val = tree.GetValue();
                ///יבוא קוד שאני רוצה לבצע על הצומת.
                Console.Write(val+"--->");

                PrintInOrderTree(tree.GetRight());

            }
        }

        static void Main(string[] args)
        {
            //BinNode<int> root = new BinNode<int>(1);
            //BinNode<int> left = new BinNode<int>(2);
            //BinNode<int> right = new BinNode<int>(3);

            //root.SetLeft(left);
            //root.SetRight(right);
            //Console.WriteLine(root);

            //            BinNode<string> root = CreateStringTree();
            BinNode<int> tree = RandomCreateTree(2,new Random(),10,80);
            Console.WriteLine(tree);
            PrintInOrderTree(tree);

           
        }
    }
}
