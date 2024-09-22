using Laba1.Classes.Algorithms;
using Laba1.Models;
using System.Collections.Generic;
using System.Linq;
using Laba1.Models;


namespace Laba1.Classes
{
    public class SortManager
    {
        private List<ISortAlgorithm> _algorithms;

        public SortManager()
        {
            _algorithms = new List<ISortAlgorithm>
            {
                new BubbleSort(),
                new InsertionSort(),
                new MergeSort(),
                new QuickSort(),
                new SelectionSort()
            };
        }

        public List<SortResult> SortAll(int[] array)
        {
            var results = new List<SortResult>();
            foreach (var algorithm in _algorithms)
            {
                int[] arrayCopy = (int[])array.Clone();
                int iterations = algorithm.Sort(arrayCopy);
                results.Add(new SortResult
                {
                    AlgorithmName = algorithm.Name,
                    Iterations = iterations,
                    SortedArray = arrayCopy
                });
            }
            return results;
        }

        public SortResult GetMostEfficient(int[] array)
        {
            var results = SortAll(array);
            return results.OrderBy(r => r.Iterations).FirstOrDefault();
        }
    }
}


