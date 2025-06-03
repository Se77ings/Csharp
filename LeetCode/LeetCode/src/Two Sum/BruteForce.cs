namespace Two_Sum
{
	public class BruteForce
	{
		static void Inicial(string[] args)
		{
			// Case 1:
			//int[] result = TwoSum([2, 7, 11, 15], 9); // Output: [0, 1]

			// Case 2:
			//int[] result = TwoSum([3,
			//, 4], 6); // Output: [1, 2]

			// Case 3:
			//int[] result = TwoSum([3, 3], 6); // Output: [0, 1]

			// Case 4:
			//int[] result = TwoSum([3, 2, 3], 6); // Output: [1, 2]

			// Case 5:
			//int[] result = TwoSum([2, 7, 11, 15], 9); // Output: [1, 2]

			// Case 6 :
			//int[] result = TwoSum([3, 2, 4], 6); // Output: [1, 2]

			// Case 7:
			int[] result = TwoSum([1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1], 11);

			Console.WriteLine($"[{result[0]},{result[1]}] ");
		}

		public static int[] TwoSum(int[] nums, int target)
		{
			bool success = false;
			int[] result = new int[2];
			for (int i = 0; i <= nums.Length - 1 && !success; i++)
			{
				for (int j = 0; j < nums.Length - 1 && !success; j++)
				{
					if (j == i)
					{
						j++;
					}
					var foo = nums[i] + nums[j];
					if (foo == target)
					{
						result[0] = i;
						result[1] = j;
						success = true;
						break;
					}

				}
			}

			return result;
		}
	}
}
