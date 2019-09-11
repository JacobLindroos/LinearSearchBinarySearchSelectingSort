
using System;

namespace AssignmentsGoThrough
{
	class Program
	{
		static void Main(string[] args)
		{
			//creates a array w. id arr
			int[] values;
			//declear how many elements in array
			int count = 10;

			//calls the fillArray method and fills it with random number
			FillArray(count, out values, 1, 10);
			//calls the PrintArray method and prints the array
			PrintArray(ref values);
			
			//sets a variable of data type int w. id lookFor and sets it´s value equal to 4
			int lookFor = 4;
			//sets a variable of data type int w. id foundPos, that holds the value of found position in array
			int foundPos;

			#region Linear Search
			Console.WriteLine("\n\nLinear search");
			if(LinearSearch(ref values, lookFor, out foundPos))
			{
				Console.WriteLine($"{lookFor} was found at position {foundPos}");
			}
			else
			{
				Console.WriteLine($"{lookFor} was not found in the array.");
			}
			#endregion

			#region Selecction sort
			Console.WriteLine("\n\nSelection Sort");
			SelectionSort(ref values);
			PrintArray(ref values);
			#endregion

			#region Binary iterative
			Console.WriteLine("\n\nBinary iterative search");
			if (BinarySearchIterative(ref values, lookFor, out foundPos))
			{
				Console.WriteLine($"{lookFor} was found at position {foundPos}");
			}
			else
			{
				Console.WriteLine($"{lookFor} was not found in the array.");
			}
			#endregion

			#region Binary recursive
			Console.WriteLine("\n\nBinary recursive search");
			if (BinarySearchRecursive(ref values, lookFor, 0, values.Length - 1, out foundPos))
			{
				Console.WriteLine($"{lookFor} was found at position {foundPos}");
			}
			else
			{
				Console.WriteLine($"{lookFor} was not found in the array.");
			}
			#endregion

			Console.ReadKey();
		}

		/// <summary>
		/// Fills the array w. random numbers
		/// </summary>
		/// <param name="count"> sets the amount of elements </param>
		/// <param name="array"> to fill w. numbers </param>
		/// <param name="min"> value to fill array w. </param>
		/// <param name="max"> value to fill array w. </param>
		static void FillArray(int count, out int[] array, int min = 0, int max = int.MaxValue ) //all defualt values need to be last 
		{
			//creates a new int array with int count value of elements
			array = new int[count];
			//creates a random objekt from specified seed value 100
			Random rnd = new Random(100);

			//for-loop that loops through the array length
			for (int i = 0; i < array.Length; i++)
			{
				//and fills the array w. random numbers between min and max value
				array[i] = rnd.Next(min, max);
			}
		}

		/// <summary>
		/// Fills the array w. random numbers
		/// </summary>
		/// <param name="array"> to print out </param>
		static void PrintArray(ref int[] array)
		{
			Console.WriteLine(string.Join(", ", array));
		}

		/// <summary>
		/// Searches after a value in the array
		/// </summary>
		/// <param name="array"> which we search </param>
		/// <param name="searchFor"> value in array </param>
		/// <param name="foundIndex"> value found on position in array </param>
		/// <returns></returns>
		static bool LinearSearch(ref int[] array, int searchFor, out int foundIndex)
		{
			//for-loop that loops through the whole array
			for (int i = 0; i < array.Length; i++)
			{
				//IF value on position "i" in array is equal to value for searchFor 
				if(array[i] == searchFor)
				{
					//return true beacuse the value was found, and sets value for foundindex is set to "i"
					foundIndex = i;
					return true;
				}
			}
			//no int value was found in the list, -1 is returned
			foundIndex = -1;
			return false;
		}

		/// <summary>
		/// Sorts the array w. selection sort method
		/// </summary>
		/// <param name="array"> to sort </param>
		static void SelectionSort(ref int[] array)
		{
			//creates two int variables w. id minElement and temp
			int minElement, temp;

			//for-loop that sets the minElement value
			for (int i = 0; i < array.Length - 1; i++)
			{
				minElement = i;
				//finding the lowest value in the rest of the array
				for (int j = i + 1; j < array.Length; j++)
				{
					//IF value on position array-j is less then value on position array-minelement
					if(array[j] < array[minElement])
					{
						//the value for minelement is set equal to value for j;
						minElement = j;
					}
				}
				if (minElement != i) //IF minelement value now is not equal to i swap values.
				{
					temp = array[minElement];
					array[minElement] = array[i];
					array[i] = temp;
				}
			}
		}

		/// <summary>
		/// Searches array in a binary iterative way
		/// </summary>
		/// <param name="array"> to binary search </param>
		/// <param name="searchFor"> value searched for </param>
		/// <param name="foundIndex"> value serached for found on index </param>
		/// <returns></returns>
		static bool BinarySearchIterative(ref int[] array, int searchFor, out int foundIndex)
		{
			//search area in array
			int min = 0;
			int max = array.Length - 1;

			//while-loop that loops as long value for min is less or equal to max value
			while(min <= max)
			{
				//sets int mid value equal to (min + max)/2
				int mid = (min + max) / 2;
				//IF the value for int searchFor is equal to the value on array[mid]
				if(searchFor == array[mid])
				{
					//return true and sets int foundIndex to the value of mid
					foundIndex = mid;
					return true;
				}
				else if(searchFor < array[mid]) //ELSE IF int searchFor value is less then array[mid] value, searching for a lower value
				{
					//change max value to int mid - 1, so the new max is reduced
					max = mid - 1;
				}
				else //ELSE int searchFor value is greater then array[mid] value, searching for a higher value
				{
					//change min value to int mid + 1, so the new max is increased
					min = mid + 1;
				}
			}
			//if value searchFor is not found in array return false and -1
			foundIndex = - 1;
			return false;
		}

		/// <summary>
		/// Searches array in a binary recursive way 
		/// </summary>
		/// <param name="array"> searched through </param>
		/// <param name="searhFor"> value in the array </param>
		/// <param name="min"> position in array to start searching from </param>
		/// <param name="max"> position in array to end search at </param>
		/// <param name="foundIndex"> value on position </param>
		/// <returns></returns>
		static bool BinarySearchRecursive(ref int[] array, int searhFor, int min, int max, out int foundIndex)
		{
			//IF value for min is greater then value for max, then we didn´t find the search for value in the array
			if (min > max)
			{
				//return false and value -1
				foundIndex = -1;
				return false;
			}
			else //ELSE continue searching through array
			{
				//int mid value is set to (min + max)/2
				int mid = (min + max) / 2;
				//IF value for int searchFor is equal to the value for array[mid], then we did find the search for value in array
				if (searhFor == array[mid])
				{
					//return true and value for foundIndex which in that case is the value on position array[mid]
					foundIndex = mid;
					return true;
				}
				else if(searhFor < array[mid]) //ELSE IF value int serachFor is less then value on position array[mid]
				{
					//then we use the method it self but change the max position to mid position minus 1
					return BinarySearchRecursive(ref array, searhFor, min, mid - 1, out foundIndex);
				}
				else //ELSE the value int searchFor is greater then the value on position array[mid]
				{
					//then we use the method it self but change the min position to mid position plus 1
					return BinarySearchRecursive(ref array, searhFor, mid + 1, max, out foundIndex);
				}
			}
		}
	}
}
