using System;
using System.Collections.Generic;
using System.IO;

namespace ClosestPair
{
    public class MinimalCostPathFinder
    {
        public static void TestMinCostPath()
        {
            //input
            /*
            1,2,3
            4,5,6
            7,8,9
            */
            var ret = ProcessInput();
            Console.WriteLine(ret);
        }


        public static int Find(int[,] a)
        {
            var solution = new int[a.GetLength(0), a.GetLength(1)];

            solution[0, 0] = a[0, 0];
            // fill the first row
            for (int i = 1; i < a.GetLength(0); i++)
            {
                solution[0, i] = a[0, i] + solution[0, i - 1];
            }

            // fill the first column
            for (int i = 1; i < a.GetLength(0); i++)
            {
                solution[i, 0] = a[i, 0] + solution[i - 1, 0];
            }

            // path will be either from top or left, choose which ever is minimum
            for (int i = 1; i < a.GetLength(0); i++)
            {
                for (int j = 1; j < a.GetLength(0); j++)
                {
                    int val1 = a[i, j];
                    int val2 = Math.Min(solution[i - 1, j], solution[i, j - 1]);
                    solution[i, j] = val1 + val2;
                }
            }
            return solution[a.GetLength(0) - 1, a.GetLength(0) - 1];
        }

        public static void TestStr()
        {   
            int[,] a = new int[3, 3]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            TestStr(a);
        }
        public static void TestStr(int[,] prmAry)
        {
            Console.WriteLine("Minimum Cost Path " + Find(prmAry));
        }

        public  static int ProcessInput()
        {
            int counter = 1;
            var lst = new List<string>();
            using (var reader = new StreamReader(Console.OpenStandardInput()))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line)) continue;

                    if (lst.Count == 0)
                    {
                        counter = int.Parse(line);
                    }
                    lst.Add(line);
                    if (lst.Count >= counter + 1)
                        break;
                }
            int[,] tst = PaseInput(lst);
            int ret = Find(tst);
            return ret;
        }

        private static int[,] PaseInput(IEnumerable<string> prmList)
        {
            int length = 0;
            int counter = 0;
            int[,] retAry = null;
            foreach (string str in prmList)
            {
                if (counter == 0)
                {
                    length = int.Parse(str);
                    retAry = new int[length, length];
                }
                else
                {
                    string[] arry = str.Split(',');
                    int x = counter - 1;
                    for (int i = 0; i < length; ++i)
                    {
                        if (retAry != null) retAry[x, i] = int.Parse(arry[i]);
                    }
                }
                ++counter;

            }
            return retAry;
        }

    }
}
