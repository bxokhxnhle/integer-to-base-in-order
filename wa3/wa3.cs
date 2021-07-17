using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
            Write("Enter an integer of three or more: ");
            int num = int.Parse(ReadLine());
            
            if (num < 0)
            { 
                throw new ArgumentOutOfRangeException("num",  
                    "The number must be nonnegative."); 
            }
            
            int firstBaseNum = 2;
            while(firstBaseNum < num)
            {
                int[] a = Convert(num, firstBaseNum);
                int k = 0;
                bool nonIncreasing = true;
                while (nonIncreasing && k < a.Length - 1)
                {
                    if (a[k+1] > a[k]) nonIncreasing = false; 
                    else k++;
                }
                if (nonIncreasing) 
                {
                    Write("The base-10 number {0} expressed in base {1} is ", num, firstBaseNum);
                    Display(num, firstBaseNum);
                }
                firstBaseNum++;
            }
        }
    
        static void Display(int num, int firstBaseNum)
        {
            int[] digits = Convert(num, firstBaseNum);
            int index = 0;
            if (firstBaseNum <= 10)
            {
                while (index < digits.Length)
                {
                    Write(digits[index]);
                    index++;
                }
            }
            else
            {
                while (index <= digits.Length - 1)
                {
                    if (index < digits.Length - 1)
                    {
                        Write(digits[index]);
                        Write(",");
                        index++;
                    }
                    else
                    {
                        Write(digits[index]);
                        index++;
                    }
                }
            }
            WriteLine();
        }
        
        static int[] Convert(int num, int basenum)
        {
            if (basenum < 2)
            {
                throw new ArgumentOutOfRangeException("basenum", 
                    "The base must be two or more.");
            }
            int i = num / basenum;
            int size = 2;
            while(i >= basenum)
            {
                i = i / basenum;
                size++;
            }
                
            
            int j = num;
            int[] result = new int[size];
            
            int index = result.Length - 1;
            bool notDone = true;
            while(notDone && index < result.Length)
            {
                if (j >= basenum)
                {
                    result[index] = j % basenum;
                    j = j / basenum;
                    index--;
                }
                else
                {
                    result[index] = j;
                    notDone = false;
                }
            }
            return result;
        }
        
    }
}
