using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calculator
            Console.WriteLine("+++++++++++++++++++++++++++");
            Console.WriteLine("+++++++ CALCULATOR ++++++++");
            Console.WriteLine("+++++++++++++++++++++++++++");
            Console.WriteLine("\t+ - Add");
            Console.WriteLine("\t- - Subtract");
            Console.WriteLine("\t* - Multiply");
            Console.WriteLine("\t/ - Divide");
            Console.WriteLine("\t% - Modulo");
            // We repeat operations until the users enters other that Y or y
            bool repeat = true;
            do
            {
                String firstNumberString;
                bool isNumber;
                // We loop until the user enters a valid number
                // The user is allowed to enter "." for example 34.54
                // If the user enters for example 34.54. it is not 
                // a valid float number, it will be rejected
                do
                {
                    isNumber = true;
                    Console.WriteLine("Enter the First Number: ");
                    firstNumberString = Console.ReadLine();
                    isNumber =  checkValidityOfNumber(firstNumberString, isNumber);
                } while (isNumber == false);
                
                String operation = "";
                // We loop until the user enters a valid operator
                // Anything except "+" or "-" or "*" or "/" or "%" is not accepted
                do
                {
                    Console.WriteLine("Enter A Valid Operator: ");
                    operation = Console.ReadLine();
                } while (operation != "+" && operation != "-" && operation != "*" &&
                         operation != "/" && operation != "%");

                String secondNumberString;

                // We check the number validity of the second entered number
                do
                {
                    isNumber = true;
                    Console.WriteLine("Enter The Second Number: ");
                    secondNumberString = Console.ReadLine();
                    isNumber = checkValidityOfNumber(secondNumberString, isNumber);
                } while (isNumber == false);

                // firstNumberString and secondNumberString are converted to float to
                // make operations 
                float firstNumberFloat  = (float)Convert.ToDouble(firstNumberString);
                float secondNumberFloat = (float)Convert.ToDouble(secondNumberString);

                float result = 0;
                String resultDivision = "";
                if (operation == "+")
                    {
                        result = firstNumberFloat + secondNumberFloat;
                    }
                else if (operation == "-")
                    {
                        result = firstNumberFloat - secondNumberFloat;
                    }
                else if (operation == "*")
                    {
                        result = firstNumberFloat * secondNumberFloat;
                    }
                else if (operation == "/")
                    {
                    if (secondNumberFloat == 0)
                        {
                            resultDivision = "Divsion By 0 Impossible";
                        }
                    else
                            result = firstNumberFloat / secondNumberFloat;
                    }
                    else if (operation == "%")
                    {
                        result = firstNumberFloat % secondNumberFloat;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Result: ");
                    if (resultDivision != "")
                        Console.WriteLine(resultDivision);
                    else
                        Console.WriteLine(result);

                String anotherOp = "";
                Console.WriteLine("Another Operation?: Y Or y for Yes or enter to quit: ");
                anotherOp = Console.ReadLine();
                if(anotherOp == "Y" || anotherOp == "y")
                    {
                        repeat = true;
                    }
                else
                    {
                        repeat = false;
                    }
                
        } while (repeat == true);

        static bool checkValidityOfNumber(String strNumber, bool isNumber){

                int nbrOfDots = 0;
                foreach (char c in strNumber)
                {
                    if (!char.IsDigit(c))
                    {
                        if (c == '.')
                        {
                            nbrOfDots++;
                            if (nbrOfDots > 1)
                                // Only one "." is accepted
                            {
                                isNumber = false;
                                continue;
                            }
                        }
                        else
                        {
                            isNumber = false;
                            continue;
                        }
                    }
                }
                return isNumber;
            }
        }
    }
}
