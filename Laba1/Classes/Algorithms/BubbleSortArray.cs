using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba1.Models;

namespace Laba1.Classes.Algorithms
{
    public class BubbleSort : ISortAlgorithm
    {
        public string Name => "Bubble Sort";

        public int Sort(int[] arr)
        {
            int iterations = 0;
            int n = arr.Length;
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    iterations++;
                    if (arr[i - 1] > arr[i])
                    {
                        // Swap arr[i-1] and arr[i]
                        int temp = arr[i - 1];
                        arr[i - 1] = arr[i];
                        arr[i] = temp;
                        swapped = true;
                    }
                }
                n--; // Optimization: reduce the range after each pass
            } while (swapped);

            return iterations;
        }
    }
}




