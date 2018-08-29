using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    class Part1
    {
        public bool CheckSumDigits(int num_digits, int num1, int num2)
        {
            bool result1 = true;//using boolean to determine if sum of digits equal each other
            int k = 1;//initialize variables
            int prev_sum = num1 % 10 + num2 % 10;
            int cur_sum = 0;
            while (result1 && k < num_digits)
            {
                num1 /= 10;//integer division cuts off most right digit
                num2 /= 10;
                cur_sum = num1 % 10 + num2 % 10;
                if (cur_sum != prev_sum)//previous sum doesn't equal current sum
                {
                    result1 = false;
                }
                else
                {
                    prev_sum = cur_sum;
                    k++;
                }
            }
            return result1;
        }
        static void Main(string[] args)
        {
            String num1_str = null;
            int num1 = -1;
            int num1_len = 0;
            bool validUserInput = false;


            while (validUserInput == false)
            {
                try
                {
                    Console.Write("Enter 1st integer between 0 and 2,147,483,647:");//integers
                    num1_str = Console.ReadLine();
                    num1 = int.Parse(num1_str); //try to parse the user input to an int variable
                }
                catch (Exception)//enter in letter instead of number
                {
                    Console.WriteLine("Exception occurred");

                }
                if (num1 >= 0)
                {
                    validUserInput = true;
                    num1_len = num1_str.Length;
                }
                else
                {
                    Console.WriteLine("Invalid input.");//if number of digits don't match
                }// end while
                String num2_str = null;
                int num2 = -1;
                int num2_len = 0;
                validUserInput = false;

                String message2 = "Enter 2nd integer of Length " + num1_len.ToString() +  " between 0 and 2,147,483,647:";//letting user know how long the digit should be to match 

                while (validUserInput == false)
                {
                    try
                    {
                        Console.Write(message2);
                        num2_str = Console.ReadLine();
                        num2 = int.Parse(num2_str);//try to parse the user input to an int variable
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Exception occurred");
                    }
                    num2_len = num2_str.Length;
                    if (num2 >= 0 && num2_len == num1_len)//must use same number of integers
                    {
                        validUserInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }//end while

                Part1 cs1 = new Part1();
                bool result1 = cs1.CheckSumDigits(num1_len, num1, num2);//if sum is same it is true if sum different false

                Console.WriteLine(("result =" + result1.ToString()));
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}

