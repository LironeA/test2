using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes.Algorithms
{
    public class QuickSort : ISortAlgorithm
    {
        public string Name => "Quick Sort";

        public int Sort(int[] array)
        {
            return QuickSortRecursive(array, 0, array.Length - 1);
        }

        private void Swap(int[] arr, int i, int j)
        {
            if (i == j) return;
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private int Partition(int[] arr, int low, int high, out int iterations)
        {
            iterations = 0;
            int pivot = arr[high];
            int i = low;

            for (int j = low; j < high; j++)
            {
                iterations++;
                if (arr[j] <= pivot)
                {
                    Swap(arr, i, j);
                    i++;
                }
            }
            Swap(arr, i, high);
            return i;
        }

        private int QuickSortRecursive(int[] arr, int low, int high)
        {
            int iterations = 0;
            if (low < high)
            {
                int pivot = Partition(arr, low, high, out int partitionIterations);
                iterations += partitionIterations;
                iterations += QuickSortRecursive(arr, low, pivot - 1);
                iterations += QuickSortRecursive(arr, pivot + 1, high);
            }
            return iterations;
        }
    }
}



