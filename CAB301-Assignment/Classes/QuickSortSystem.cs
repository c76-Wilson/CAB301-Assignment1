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
            if (leftIndex < rightIndex)
            {
                // Get initial pivot
                int piviotIndex = Partition(array, leftIndex, rightIndex);
                
                // Run quicksort on subarray smaller than pivot
                QuickSort(array, leftIndex, piviotIndex - 1);
                                
                // Run quicksort on subarray larger than pivot
                QuickSort(array, piviotIndex + 1, rightIndex);
            }
        }

        private static int Partition(Movie[] array, int leftIndex, int rightIndex)
        {
            //Get the movie at left index as a pivot
            Movie pivot = array[leftIndex];

            while (true)
            {
                // increase left index while the number of borrows is less than the number of borrows on the pivot
                while (array[leftIndex].NumberOfBorrows < pivot.NumberOfBorrows)
                {
                    leftIndex++;
                }

                // decrease right index while number of borrows is greater than the number of borrows on the pivot
                while(array[rightIndex].NumberOfBorrows > pivot.NumberOfBorrows)
                {
                    rightIndex--;
                }

                if (leftIndex < rightIndex)
                {
                    // Check if left and right number of borrows are the same, if so return right index
                    if (array[leftIndex].NumberOfBorrows == array[rightIndex].NumberOfBorrows)
                    {
                        return rightIndex;
                    }

                    // Else swap them and re-run while loop
                    Movie temp = array[leftIndex];
                    array[leftIndex] = array[rightIndex];
                    array[rightIndex] = temp;
                }
                else
                {
                    return rightIndex;
                }
            }
        }
    }
}
