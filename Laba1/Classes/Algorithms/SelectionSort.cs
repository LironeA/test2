using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes.Algorithms
{
    public class SelectionSort : ISortAlgorithm
    {
        public string Name => "Selection Sort";

        public int Sort(int[] arr)
        {
            int iterations = 0;
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    iterations++;
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                Swap(arr, min, i);
                iterations++; // For the comparison that breaks the inner loop
            }
            return iterations;
        }

        private void Swap(int[] arr, int i, int j)
        {
            if (i == j) return;
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}



