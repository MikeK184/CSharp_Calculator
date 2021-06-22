using System;
using System.Text.RegularExpressions;

namespace Calculator
{

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Console Calculator in C#");
            Console.WriteLine(@"######           #     #                 
#     # #   #    ##   ## # #    # ###### 
#     #  # #     # # # #   #   #  #      
######    #      #  #  # # ####   #####  
#     #   #      #     # # #  #   #      
#     #   #      #     # # #   #  #      
######    #      #     # # #    # ###### ");

            while (!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                int result1 = 0;
                int cleanNum1 = 0;
                int cleanNum2 = 0;
                int numofRuns = 0;

                userInput1(out numInput1, out cleanNum1);
                userInput2(out numInput2, out cleanNum2);
                string op = userOperator();

                static int DoMagic(int num1, int num2, string op, int result1, int numofRuns)
                {
                    int result = 0;

                    if (numofRuns > 0)
                    {
                        switch (op)
                        {
                            case "+":
                                result = result1 + num2;
                                break;
                            case "-":
                                result = result1 - num2;
                                break;
                            case "*":
                                result = result1 * num2;
                                break;
                            case "\\":
                                if (num2 != 0)
                                {
                                    result = result1 / num2;
                                }
                                break;
                            case "%":
                                result = result1 % num2;
                                break;
                            default:
                                break;
                        }
                        return result;
                    } else
                    {
                        switch (op)
                        {
                            case "+":
                                result = num1 + num2;
                                break;
                            case "-":
                                result = num1 - num2;
                                break;
                            case "*":
                                result = num1 * num2;
                                break;
                            case "\\":
                                if (num2 != 0)
                                {
                                    result = num1 / num2;
                                }
                                break;
                            case "%":
                                result = num1 % num2;
                                break;
                            default:
                                break;
                        }
                        return result;
                    }
                    
                }

                try
                {
                    result1 = DoMagic(cleanNum1, cleanNum2, op, result1, numofRuns);
                    Console.WriteLine("Your Result: " + result1);                    
                    Console.WriteLine("------------------------\n");
                    numofRuns++;
                    Console.Write("Press 'x' to close the app, or any other key to continue: ");
                    string askUserforAction = Console.ReadLine();
                    if (askUserforAction == "x")
                    {
                        endApp = true;
                    }
                    else
                    {
                        bool endSecondRun = false;
                        while(!endSecondRun)
                        {
                            userInput2(out numInput2, out cleanNum2);
                            string op1 = userOperator();
                            DoMagic(cleanNum1, cleanNum2, op1, result1, numofRuns);
                            result1 = DoMagic(cleanNum1, cleanNum2, op1, result1, numofRuns);
                            Console.WriteLine("Your Result: " + result1);
                            Console.Write("Press 'x' to close the app, or any othe" +
                                "r key to continue: ");
                            string askToContinue = Console.ReadLine();
                            if (askToContinue == "x")
                            {
                                endSecondRun = true;
                                endApp = true;
                            }

                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Sheeet something went wrong brother \n - Details: " + e.Message);
                }


            }
        }

        public static string userOperator()
        {
            Console.WriteLine("What kind of operation: +, -, *, \\, %");
            string op = Console.ReadLine();
            return op;
        }
        public static void userInput1(out string numInput1, out int cleanNum1)
        {
            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();
            while (!int.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput1 = Console.ReadLine();
            }
        }
        public static void userInput2(out string numInput2, out int cleanNum2)
        {
            // Number 2
            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();
            // Playing around with some regex for project in the second semester :).
            while (!Regex.IsMatch(numInput2, @"^\d+$")) // 0 is allowed, kinda risky but nvm
            {
                Console.Write("This is not valid input. Please enter an integer value: ");
                numInput2 = Console.ReadLine();
            }
            // This can't fail due to Regex above
            cleanNum2 = int.Parse(numInput2);
        }
    }
}
