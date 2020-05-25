using CAB301_Assignment.MovieClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301_Assignment.Classes
{
    public class QuickSortSystem
    {
        public static Movie[] QuickSortArray(Movie[] array)
        {
            QuickSort(array, 0, array.Length - 1);

            return array;
        }

        private static void QuickSort(Movie[] array, int leftIndex, int rightIndex)
        {
            // Base condition - array must be larger than 0
            if (leftIndex > rightIndex)
            {
                return;
            }

            // Get initial pivot
            int piviotIndex = Partition(array, leftIndex, rightIndex);

            // Run quicksort on subarray smaller than pivot
            QuickSort(array, leftIndex, piviotIndex - 1);

            // Run quicksort on subarray larger than pivot
            QuickSort(array, piviotIndex + 1, rightIndex);

        }

        private static int Partition(Movie[] array, int leftIndex, int rightIndex)
        {
            //Get the movie at left index as a pivot
            Movie pivot = array[rightIndex];

            // Grab smallest element to begin with
            int pIndex = leftIndex;

            for (int i = leftIndex; i < rightIndex; i++)
            {
                // If element is less than or equal to pivot, swap them and increment pIndex
                if (array[i].NumberOfBorrows <= pivot.NumberOfBorrows)
                {
                    // Swap them and increment
                    Swap(array, i, pIndex);

                    pIndex++;
                }
            }

            Swap(array, rightIndex, pIndex);

            return pIndex;
        }

        private static void Swap(Movie[] array, int i, int j)
        {
            Movie temp1 = array[i];
            array[i] = array[j];
            array[j] = temp1;
        }
    }
}
