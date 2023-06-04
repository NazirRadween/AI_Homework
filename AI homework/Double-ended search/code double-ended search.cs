using System;

class Program {
    static void Main(string[] args) {
        int[] nums = { 1, 3, 5, 7, 9 };

        Console.WriteLine("Enter a number to search for:");
        int search = Convert.ToInt32(Console.ReadLine());

        int result = DoubleEndedSearch(nums, search);
        if (result == -1) {
            Console.WriteLine("Sorry, the number was not found.");
        } else {
            Console.WriteLine("The number was found at index " + result);
        }

        Console.ReadLine();
    }

    static int DoubleEndedSearch(int[] nums, int search) {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right) {
            if (nums[left] == search) {
                return left;
            } else if (nums[right] == search) {
                return right;
            }

            left++;
            right--;
        }

        return -1;
    }
}

