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
        public static int CountNodesInTree<T> (BinNode<T> t)
        {
            if (t == null)
                return 0;
            int current = 1;
            int left = CountNodesInTree(t.GetLeft());
            int right = CountNodesInTree(t.GetRight());
            return current + left + right;
            //return 1+CountNodesInTree(t.GetLeft())+CountNodesInTree(t.GetRight());
        }

        public static bool SearchBinTree<T>(BinNode<T> t,T val)
        {
            if (t == null)
                return false;

            if (t.GetValue().Equals(val))
                return true;
            return SearchBinTree(t.GetLeft(), val) || SearchBinTree(t.GetRight(), val);

            //(t.GetValue().Equals(val)||SearchBinTree(t.GetLeft(), val) || SearchBinTree(t.GetRight(), val);

        }

        public static bool IsFullBinTree<T>(BinNode<T> t)
        {
            if (t == null)
                return true;

            if((t.HasLeft()&&!t.HasRight())||(!t.HasLeft()&&t.HasRight()))
                return false;

            return IsFullBinTree(t.GetLeft()) && IsFullBinTree(t.GetRight());
        }

        public static int BinTreeHight<T> (BinNode<T> t)
        {
            if (t == null)
                return 0;
            if (!t.HasLeft() && !t.HasRight())
                return 0;

            return 1 + Math.Max(BinTreeHight(t.GetLeft()), BinTreeHight(t.GetRight()));


        }

        public static void PrintEvenNodes(BinNode<int> t)
        {
            if (t != null)
            {
                if (t.GetValue() % 2 == 0)
                    Console.WriteLine(t.GetValue());
                PrintEvenNodes(t.GetLeft());
                PrintEvenNodes(t.GetRight());
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
            PrintEvenNodes(tree);

           // PrintInOrderTree(tree);

           
        }
    }
}
