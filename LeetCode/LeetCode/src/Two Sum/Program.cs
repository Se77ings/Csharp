using System.Security.Cryptography.X509Certificates;

namespace Two_Sum
{
	public class Program
	{
		static void Main(string[] args)
		{
			// Case 1:
			int[] result = TwoSum([2, 7, 11, 15], 9); // Output: [0, 1]

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
			//int[] result = TwoSum([1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1], 11);

			Console.WriteLine($"[{result[0]},{result[1]}] ");
		}

		public static int[] TwoSum(int[] nums, int target)
		{
			var map = new Dictionary<int, int>();
			for (int i = 0; i < nums.Length; i++)
			{
				int complement = target - nums[i];
				if (map.ContainsKey(complement))
				{
					return new int[] { map[complement], i };
				}
				map[nums[i]] = i;
			}

			return new int[] { -1, -1 };
		}
	}
}
