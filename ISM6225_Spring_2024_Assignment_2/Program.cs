using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Store result in list
                List<int> result = new List<int>();

                // Iterate through array elements
                for (int i = 0; i < nums.Length; i++)
                {
                    // Calculate index based on value
                    int index = Math.Abs(nums[i]) - 1;  

                    // Check if number at that index is positive
                    if (nums[index] > 0)                
                        nums[index] = -nums[index];     // Mark the number as visited by negating it
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    // If positive, the index + 1 is a missing number
                    if (nums[i] > 0) result.Add(i + 1); 
                }
                // Return list of missing numbers
                return result;                          
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Initialize two pointers for left from staring index and right from ending index
                int left = 0, right = nums.Length - 1; 

                // Loop until pointers meet     
                while (left < right)                        
                {
                    // Swap if the left pointer points to odd number and right pointer points to even number
                    if (nums[left] % 2 > nums[right] % 2)
                    {
                        //Perform swapping
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }

                    // Move left pointer if number is even
                    if (nums[left] % 2 == 0) left++; 

                    // Move right pointer if number is odd     
                    if (nums[right] % 2 == 1) right--;    
                }

                // Return sorted array
                return nums;                             
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Create dictionary to store number and its index
                Dictionary<int, int> map = new Dictionary<int, int>();   

                // Iterate through array elements
                for (int i = 0; i < nums.Length; i++)
                {
                    // Calculate the complement of the current number
                    int complement = target - nums[i];  

                    // Check if the complement exists in the dictionary
                    if (map.ContainsKey(complement))
                        return new int[] { map[complement], i }; // Return the indices of the complement and current number

                    // Store current number with its index in the dictionary
                    map[nums[i]] = i;
                }

                // Return an empty array if no solution is found
                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Sort array to access the largest and smallest values
                Array.Sort(nums);
                int n = nums.Length;

                // Return the maximum product from either the two smallest and the largest number or the three largest numbers
                return Math.Max(nums[0] * nums[1] * nums[n - 1],
                                nums[n - 1] * nums[n - 2] * nums[n - 3]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0) return "0";

                // Initialize empty string for binary result
                string binary = "";

                // Loop until decimal number is reduced to zero
                while (decimalNumber > 0)
                {
                    // Prepend the remainder to binary string
                    binary = (decimalNumber % 2) + binary;

                    // Divide number by 2 for next iteration
                    decimalNumber /= 2;
                }

                // Return final binary representation
                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Initialize pointers for binary search with left as starting index & right as ending index
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    // Calculate the middle index
                    int mid = left + (right - left) / 2;

                    // If mid is greater than right, minimum is in right half
                    if (nums[mid] > nums[right])
                        left = mid + 1;             // Move left pointer to mid + 1
                    else
                        right = mid;                // Move right pointer to mid
                }

                // Return minimum element found at left pointer
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Negative numbers are not palindromes
                if (x < 0) return false;

                // Store original number and initialize reversed
                int origin = x, reverse = 0;

                // Loop through all values
                while (x != 0)
                {
                    // Get last digit of x and build reversed number
                    reverse = reverse * 10 + x % 10;

                    // Remove the last digit from x
                    x = x/10;
                }

                // Check if original and reversed numbers are same
                return origin == reverse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n <= 1) return n;

                // Initialize first two Fibonacci numbers
                int a = 0, b = 1;

                // Calculate Fibonacci numbers from 2 to n
                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b;           // Calculate next Fibonacci number
                    a = b;                      // Move forward in sequence
                    b = temp;                   // Update last number to new Fibonacci number
                }

                // Return nth Fibonacci number
                return b;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
