using System;
using DataStructureCore;
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


        /// <summary>
        /// h- גובה העץ
        /// n- מספר הצמתים בעץ
        /// O(h*n)
        /// h=n-1 worst case (עץ שרשרת)
        /// =~O(n^2)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int BinTreeWidth<T>(BinNode<T> t)
        {
            int maxWidth = 0;
            int treeHeight = BinTreeHight(t);

            for (int i = 0; i <= treeHeight; i++)
            {
                int nodesInLevel = CountNodesInLevel(t, i, 0);
                if (nodesInLevel > maxWidth)
                    maxWidth = nodesInLevel;
            }
            return maxWidth;

        }

        /// <summary>
        /// h=גובה של העץ
        /// n=מספר הצמתים
        /// o(h) + o(n) = > o(n)
        /// (ראו את הקשר בין 
        /// h ל n 
        /// בפעולה הקודמת
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int BinTreeWidthV2<T>(BinNode<T> t)
        {
           
            int treeHeight = BinTreeHight(t);
            int[] countLevels = new int[treeHeight + 1];
            int maxWidth = 0;

            CountNodesInLevel(t, countLevels, 0);
            for (int i =0; i < countLevels.Length; i++)
            {
                if (countLevels[i] > maxWidth)
                    maxWidth = countLevels[i];
            }
            return maxWidth;

               
        }
        /// <summary>
        ///פעולה מקבלת מצביע לראש עץ, מערך מונים המייצג את הרמות בעץ והרמה הנוכחית שנבדקת
        ///הפעולה תוסיף 1 בתא המייצג את הרמה הנוכחית בכל פעם שנקלת בצומת
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">עץ</param>
        /// <param name="countLevels">מערך מונים המייצג את הרמות בעץ</param>
        /// <param name="currLevel">הרמה הנוכחית שנבדקת</param>
        private static void CountNodesInLevel<T>(BinNode<T> t, int[] countLevels, int currLevel)
        {
            //עץ ריק/הגענו לסוף מסלול
            if (t == null)
                return;
            //ספור את הצומת הנוכחי והוסף 1 לתא המייצג את הרמה הנוכחית בעץ
            countLevels[currLevel]++;
            //רק לרמה הבאה בתת עץ שמאל
            CountNodesInLevel(t.GetLeft(), countLevels, currLevel + 1);
            //רק לרמה הבאה בתת עץ ימין
            CountNodesInLevel(t.GetRight(), countLevels, currLevel + 1);



        }

     

        
        /// <summary>
        /// הפעולה מקבלת שורש של עץ, רמה לבדיקה ורמה נוכחית בעץ ומחזירה כמה צמתים יש ברמה לבדיקה
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">שורש העץ</param>
        /// <param name="level">רמה לבדיקה</param>
        /// <param name="currLevel">רמה נוכחית</param>
        /// <returns></returns>
        private static int CountNodesInLevel<T>(BinNode<T> t, int level,int currLevel)
        {
            //תנאי עצירה אם עץ ריק
            if (t == null)
                return 0;
            //אם הגענו לרמה נספור את הצומת הנוכחית
            if(currLevel==level)
            {
                return 1;
            }
            //כל עוד לא הגענו לרמה שהבדיקה- נמשיך בסריקה
            return CountNodesInLevel(t.GetLeft(), level, currLevel + 1) + CountNodesInLevel(t.GetRight(), level, currLevel + 1);
        }

        public static void BreadthScan<T>(BinNode<T> t)
        {
            //תור עזר של צמתים
            Queue<BinNode<T>> qNodes = new Queue<BinNode<T>>();
            //הכנסת השורש
            qNodes.Insert(t);
            while(!qNodes.IsEmpty())
            {
                //נשלוף את הצומת
                BinNode<T> temp = qNodes.Remove();
                //....קוד שנרצה לבצע על הצומת
                //הכנסה לתור הילד השמאלי
                if (temp.HasLeft())
                    qNodes.Insert(t.GetLeft());
                //הכנסה לתור הילד הימני
                if (temp.HasRight())
                    qNodes.Insert(t.GetRight());
            }
        }

        public static void PrintTreeLevels<T>(BinNode<T> t)
        {
            //תור עזר של צמתים
            Queue<BinNode<T>> qNodes = new Queue<BinNode<T>>();
            //הכנסת השורש
            qNodes.Insert(t);
            while (!qNodes.IsEmpty())
            {
                //נשלוף את הצומת
                BinNode<T> temp = qNodes.Remove();
                //קוד לביצוע
                Console.WriteLine(temp.GetValue());
                if (temp.HasLeft())
                    qNodes.Insert(t.GetLeft());
                if (temp.HasRight())
                    qNodes.Insert(t.GetRight());
            }
        }

        public static void PrintTreeWithLevels<T>(BinNode<T> t)
        {
            //תור עזר של צמתים
            Queue<BinNode<T>> qNodes = new Queue<BinNode<T>>();
            Queue<int> levels = new Queue<int>();
            //הכנסת השורש
            qNodes.Insert(t);
            int currLevel = 0;
            levels.Insert(currLevel);
            while (!qNodes.IsEmpty())
            {
                //נשלוף את הצומת
                BinNode<T> temp = qNodes.Remove();
                currLevel = levels.Remove();
                //קוד לביצוע
                Console.WriteLine(temp.GetValue()+"-"+"level:" +currLevel );
                if (temp.HasLeft())
                {
                    qNodes.Insert(t.GetLeft());
                    levels.Insert(currLevel + 1);
                }
                if (temp.HasRight())
                {
                    qNodes.Insert(t.GetRight());
                    levels.Insert(currLevel + 1);
                }
            }
        }


        public static int GetWidthBinTreeLevelSearch<T>(BinNode<T> t)
        {
            //תור עזר של צמתים
            Queue<BinNode<T>> qNodes = new Queue<BinNode<T>>();
            Queue<int> levels = new Queue<int>();
            
            //מקסימום הכולל
            int max = 0;
            //מונה צמתים ברמה
            int currNodesInLevel = 0;
            //רמה נוכחית שכרגע נספרת
            int currLevel = 0;
            
            //הכנסת השורש
            qNodes.Insert(t);
                     
            levels.Insert(currLevel);
            
            while (!qNodes.IsEmpty())
            {
                //נשלוף את הצומת
                BinNode<T> temp = qNodes.Remove();
                //נשלוף את הרמה של הצומת
                int level = levels.Remove();


                //קוד לביצוע
                //אם הרמה זהה
              if(currLevel==level)
                {
                    currNodesInLevel++;
                    if (currNodesInLevel > max)
                        max = currNodesInLevel;
                                          
                }
                //החלפת רמה
                 
                {
                    currNodesInLevel = 0;
                    currLevel = level;
                }

                if (temp.HasLeft())
                {

                    qNodes.Insert(t.GetLeft());
                    levels.Insert(currLevel + 1);
                    

                }
                if (temp.HasRight())
                {
                    qNodes.Insert(t.GetRight());
                    levels.Insert(currLevel + 1);
                   
                }
                
                

            }
            return max;
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
