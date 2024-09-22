using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1.Classes.Algorithms
{
    public class MergeSort : ISortAlgorithm
    {
        public string Name => "Merge Sort";

        public int Sort(int[] array)
        {
            return MergeSortRecursive(array, 0, array.Length - 1);
        }

        private int Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            int iterations = 0;
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while (left <= middleIndex && right <= highIndex)
            {
                iterations++;
                if (array[left] < array[right])
                {
                    tempArray[index++] = array[left++];
                }
                else
                {
                    tempArray[index++] = array[right++];
                }
            }

            while (left <= middleIndex)
            {
                tempArray[index++] = array[left++];
            }

            while (right <= highIndex)
            {
                tempArray[index++] = array[right++];
            }

            for (int i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
                iterations++;
            }

            return iterations;
        }

        private int MergeSortRecursive(int[] array, int lowIndex, int highIndex)
        {
            int iterations = 0;
            if (lowIndex < highIndex)
            {
                int middleIndex = (lowIndex + highIndex) / 2;
                iterations += MergeSortRecursive(array, lowIndex, middleIndex);
                iterations += MergeSortRecursive(array, middleIndex + 1, highIndex);
                iterations += Merge(array, lowIndex, middleIndex, highIndex);
            }
            return iterations;
        }
    }
}

