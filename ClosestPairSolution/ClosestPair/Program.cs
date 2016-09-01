using System;
using System.Net;

namespace ClosestPair
{
    public  class Program
    {   
        static void Main(string[] args)
        {
            try
            {
                MinimalCostPathFinder.TestMinCostPath();
                ClosestPairFinder.Process("input.txt");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                Console.ReadLine();
            }
        }

    }

    
}